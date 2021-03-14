using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    public class FamilyMember : Human
    {
        public FamilyMember(
            string fullName, DateTime birthDate
        ) : base(fullName, birthDate)
        {
            Children = new List<Guid>();

            PartnerId = new PropHistory<Guid?>().AddChange(null, BirthDate);
            Status = new PropHistory<StatusOptions>((value, since) =>
            {
                if (value == StatusOptions.Married && !HadPartner(since))
                {
                    throw new Exception("Cannot get married without any partner.");
                }
            }).AddChange(StatusOptions.Unmarried, BirthDate);

            PartnerReference = new PropHistory<FamilyMember>().AddChange(null, birthDate);
        }

        [JsonConstructor]
        public FamilyMember()
        { }

        private List<Guid> _Children { get; set; }

        [JsonProperty]
        public List<Guid> Children
        {
            get
            {
                return _Children;
            }
            set
            {
                _Children = value ?? throw new Exception("Trying to set null children.");
            }
        }

        [JsonProperty]
        public PropHistory<Guid?> PartnerId { get; set; }

        public bool HadPartner(DateTime at, FamilyMember specific = null)
        {
            Guid? partnerIdThatTime = PartnerId.ValueAt(at);

            return partnerIdThatTime.HasValue && (
                specific == null || partnerIdThatTime.Value == specific.Id
            );
        }

        public bool HadAnyPartner()
        {
            return PartnerId.Changes.Values.Any(v => v.HasValue);
        }

        public bool WasEverMarried()
        {
            return Status.Changes.Values.Any(v => v == StatusOptions.Married);
        }

        public bool WasMarried(DateTime at)
        {
            return Status.ValueAt(at) == StatusOptions.Married;
        }

        public FamilyMember HadChild(FamilyMember child)
        {
            if (child.BirthDate < BirthDate)
            {
                throw new ArgumentException("The child's birth date is before the parent's birth date.", nameof(child));
            }

            Children.Add(child.Id);
            return this;
        }

        public FamilyMember WithPartner(FamilyMember arg, DateTime since)
        {
            FamilyMember partner = PartnerReference.ValueAt(since);

            if (arg == null)
            {
                partner?.PartnerReference.AddChange(null, since);
                partner?.PartnerId.AddChange(null, since);
            }
            else {
                if (arg.BirthDate > since)
                {
                    throw new ArgumentException("Cannot set a partner who was not born that time.", nameof(arg));
                }

                if (since > arg.DeathDate)
                {
                    throw new ArgumentException("Cannot set a partner who is already dead that time.", nameof(arg));
                }

                arg.PartnerReference.AddChange(this, since);
                arg.PartnerId.AddChange(Id, since);
            }

            PartnerId.AddChange(arg?.Id, since);
            PartnerReference.AddChange(arg, since);

            return this;
        }

        public FamilyMember WithoutPartner(DateTime since)
        {
            if (!HadPartner(since))
            {
                throw new ArgumentException("Cannot remove the partner that was not set that time.", nameof(since));
            }

            return WithPartner(null, since);
        }

        public FamilyMember GotMarried(DateTime since, FamilyMember partner = null)
        {
            if (HadPartner(since))
            {
                if (!HadPartner(since, partner))
                {
                    throw new ArgumentException("Cannot get married with another partner.", nameof(partner));
                }
            }
            else if (partner != null)
            {
                WithPartner(partner, since);
            }

            Status.AddChange(StatusOptions.Married, since);
            PartnerReference.ValueAt(since)?.Status.AddChange(StatusOptions.Married, since);
            return this;
        }

        public FamilyMember GotUnmarried(DateTime since)
        {
            if (!PartnerId.ValueAt(since).HasValue)
            {
                throw new Exception("Cannot get unmarried without any partner.");
            }

            Status.AddChange(StatusOptions.Unmarried, since);
            PartnerReference.ValueAt(since)?.Status.AddChange(StatusOptions.Unmarried, since);

            return WithoutPartner(since);
        }

        public FamilyMember ChangedFullName(string arg, DateTime since)
        {
            FullName.AddChange(arg, since);
            return this;
        }

        private PropHistory<FamilyMember> PartnerReference { get; set; }

        public FamilyMember RepairPartnerReference (PropHistory<FamilyMember> arg)
        {
            if (PartnerReference.GetLatestChangeDate() > BirthDate)
            {
                throw new Exception("This method is used after the serialization.");
            }

            PartnerReference = arg;
            return this;
        }
    }
}
