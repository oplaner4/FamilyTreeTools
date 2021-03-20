using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
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

            Partner = new PropHistory<Member>();

            Children = new List<Member>();

            base.Initialize();
        }

        public Member(
            string fullName, DateTime birthDate
        ) : base(fullName, birthDate)
        {
            Initialize();

            ChildrenReference = new List<Guid>();
            PartnerReference = new PropHistory<Guid?>().AddChange(null, BirthDate);
            Status.AddChange(StatusOptions.Unmarried, BirthDate);
            Partner.AddChange(null, BirthDate);
            FullName.AddChange(fullName, BirthDate);
        }

        /// <summary>
        /// This constructor is used only during deserialization.
        /// </summary>
        [JsonConstructor]
        public Member()
        { }

        public bool HadPartner(DateTime at, Member specific = null)
        {
            Guid? partnerIdThatTime = PartnerReference.Value(at);

            return partnerIdThatTime.HasValue && (
                specific == null || partnerIdThatTime.Value == specific.Id
            );
        }

        public bool HadAnyPartner()
        {
            return PartnerReference.Changes.Values.Any(v => v.HasValue);
        }

        public bool WasEverMarried()
        {
            return Status.Changes.Values.Any(v => v == StatusOptions.Married);
        }

        public bool WasMarried(DateTime at)
        {
            return Status.Value(at) == StatusOptions.Married;
        }

        public Member HadChild(Member child)
        {
            if (child.BirthDate < BirthDate)
            {
                throw new HistoryViolationException("The child's birth date is before the parent's birth date.");
            }

            if (child.ParentReference.HasValue)
            {
                throw new HistoryViolationException("Cannot set a child who has already the parent.");
            }

            Children.Add(child);
            ChildrenReference.Add(child.Id);
            child.ParentReference = Id;
            child.Parent = this;
            return this;
        }

        private void SetNewPartner(Member arg, DateTime since)
        {
            if (arg.BirthDate > since)
            {
                throw new HistoryViolationException("Cannot set a partner who was not born that time.");
            }

            if (since > arg.DeathDate)
            {
                throw new HistoryViolationException("Cannot set a partner who is already dead that time.");
            }

            if (arg.PartnerReference.Value(since).HasValue)
            {
                throw new HistoryViolationException("Cannot set a partner who had already the partner that time.");
            }

            arg.Partner.AddChange(this, since);
            arg.PartnerReference.AddChange(Id, since);
        }

        private Member SetPartner(Member arg, DateTime since)
        {
            if (arg == null)
            {
                Member actual = Partner.Value(since);
                actual?.Partner.AddChange(null, since);
                actual?.PartnerReference.AddChange(null, since);
            }
            else
            {
                SetNewPartner(arg, since);
            }

            Partner.AddChange(arg, since);
            PartnerReference.AddChange(arg?.Id, since);

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
            else if (partner != null)
            {
                WithPartner(partner, since);
            }

            Status.AddChange(StatusOptions.Married, since);
            Partner.Value(since)?.Status.AddChange(StatusOptions.Married, since);
            return this;
        }

        public Member GotUnmarried(DateTime since)
        {
            if (!PartnerReference.Value(since).HasValue)
            {
                throw new HistoryViolationException("Cannot get unmarried without any partner.");
            }

            Status.AddChange(StatusOptions.Unmarried, since);
            Partner.Value(since)?.Status.AddChange(StatusOptions.Unmarried, since);

            return WithoutPartner(since);
        }

        public Member ChangedFullName(string arg, DateTime since)
        {
            FullName.AddChange(arg, since);
            return this;
        }

        private void RepairInitialization()
        {
            Dictionary<DateTime, StatusOptions> existingChanges = Status.Changes;
            Dictionary<DateTime, string> fullNameChanges = FullName.Changes;
            Initialize();
            Status.Changes = existingChanges;
            FullName.Changes = fullNameChanges;
        }
    }
}
