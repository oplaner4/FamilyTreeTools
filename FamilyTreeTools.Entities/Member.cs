using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Member : Human
    {
        protected override void Initialize()
        {
            Status = new PropHistory<StatusOptions>((value, since) =>
            {
                if (value == StatusOptions.Married && !HadPartner(since))
                {
                    throw new HistoryViolationException("Cannot get married without any partner.");
                }
            });

            base.Initialize();
        }

        public Member(
            string birthFullName, DateTime birthDate
        ) : base(birthFullName, birthDate)
        {
            Initialize();

            Status.AddChange(StatusOptions.Unmarried, BirthDate);
            FullName.AddChange(birthFullName, BirthDate);
            Refs = new References(this);
        }

        /// <summary>
        /// This constructor is used only during deserialization.
        /// </summary>
        [JsonConstructor]
        public Member()
        { }

        private References _Refs { get; set; }

        [JsonProperty]
        public References Refs
        {
            get
            {
                return _Refs;
            }
            set
            {
                _Refs = value ?? throw new NullReferenceException(
                    "Trying to set null references."
                );
            }
        }

        public bool HadPartner(DateTime at, Member specific = null)
        {
            Guid? partnerIdThatTime = Refs.PartnerId.Value(at);

            return partnerIdThatTime.HasValue && (
                specific == null || partnerIdThatTime.Value == specific.Id
            );
        }

        public bool HadAnyPartner()
        {
            return Refs.PartnerId.Changes.Values.Any(v => v.HasValue);
        }

        public Member HadChild(Member child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Trying to set null child.", nameof(child));
            }

            if (child.BirthDate < BirthDate)
            {
                throw new HistoryViolationException("The child's birth date is before the parent's birth date.");
            }

            if (child.Refs.ParentId.HasValue)
            {
                throw new HistoryViolationException("Cannot set a child who has already the parent.");
            }

            Refs.AddChild(child);
            return this;
        }

        private Member SetPartner(Member arg, DateTime since)
        {
            if (arg != null)
            {
                if (arg.BirthDate > since)
                {
                    throw new HistoryViolationException("Cannot set a partner who was not born that time.");
                }

                if (since > arg.DeathDate)
                {
                    throw new HistoryViolationException("Cannot set a partner who is already dead that time.");
                }

                if (arg.Refs.PartnerId.Value(since).HasValue)
                {
                    throw new HistoryViolationException("Cannot set a partner who had already the partner that time.");
                }
            }

            Refs.UpdatePartner(arg, since);
            return this;
        }

        public Member WithPartner(Member arg, DateTime since)
        {
            if (arg == null)
            {
                throw new ArgumentException("Trying to set null partner.");
            }

            return SetPartner(arg, since);
        }

        public Member WithoutPartner(DateTime since)
        {
            if (!HadPartner(since))
            {
                throw new HistoryViolationException("Cannot break up with the partner that was not set that time.");
            }

            if (WasMarried(since))
            {
                Status.AddChange(StatusOptions.Unmarried, since);

                if (Refs.TryGetPartner(out Member partner, since))
                {
                    partner.Status.AddChange(StatusOptions.Unmarried, since);
                }
            }

            return SetPartner(null, since);
        }

        public Member GotMarried(DateTime since, Member partner = null)
        {
            if (HadPartner(since))
            {
                if (!HadPartner(since, partner))
                {
                    throw new HistoryViolationException("Cannot get married with another partner.");
                }
            }
            else if (partner == null)
            {
                throw new HistoryViolationException("Cannot get married without any partner.");
            }
            else
            {
                WithPartner(partner, since);
            }

            Status.AddChange(StatusOptions.Married, since);

            if (Refs.TryGetPartner(out Member value, since))
            {
                value.Status.AddChange(StatusOptions.Married, since);
            }
            return this;
        }

        public Member GotUnmarried(DateTime since)
        {
            if (!HadPartner(since))
            {
                throw new HistoryViolationException("Cannot get unmarried without any partner.");
            }

            return WithoutPartner(since);
        }

        public Member ChangedFullName(string arg, DateTime since)
        {
            FullName.AddChange(arg, since);
            return this;
        }

        public Member Repair(Func<Guid, Member> mapper)
        {
            Dictionary<DateTime, StatusOptions> existingChanges = Status.Changes;
            Dictionary<DateTime, string> fullNameChanges = FullName.Changes;
            Initialize();
            Status.Changes = existingChanges;
            FullName.Changes = fullNameChanges;
            Refs.Repair(mapper);
            return this;
        }
    }
}
