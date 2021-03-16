﻿using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    public class FamilyMember : Human
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

            PartnerReference = new PropHistory<FamilyMember>();
            ChildrenReference = new List<FamilyMember>();

            base.Initialize();
        }

        public FamilyMember(
            string fullName, DateTime birthDate
        ) : base(fullName, birthDate)
        {
            Initialize();

            Children = new List<Guid>();
            Partner = new PropHistory<Guid?>().AddChange(null, BirthDate);
            Status.AddChange(StatusOptions.Unmarried, BirthDate);
            PartnerReference.AddChange(null, BirthDate);
            FullName.AddChange(fullName, BirthDate);
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
        public Guid? Parent { get; set; }

        [JsonProperty]
        public PropHistory<Guid?> Partner { get; set; }

        public bool HadPartner(DateTime at, FamilyMember specific = null)
        {
            Guid? partnerIdThatTime = Partner.ValueAt(at);

            return partnerIdThatTime.HasValue && (
                specific == null || partnerIdThatTime.Value == specific.Id
            );
        }

        public bool HadAnyPartner()
        {
            return Partner.Changes.Values.Any(v => v.HasValue);
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
                throw new HistoryViolationException("The child's birth date is before the parent's birth date.");
            }

            if (child.Parent.HasValue)
            {
                throw new HistoryViolationException("Cannot set a child who has already the parent.");
            }

            Children.Add(child.Id);
            ChildrenReference.Add(child);
            child.Parent = Id;
            child.ParentReference = this;
            return this;
        }

        private FamilyMember SetPartner(FamilyMember arg, DateTime since)
        {
            FamilyMember partner = PartnerReference.ValueAt(since);

            if (arg == null)
            {
                partner?.PartnerReference.AddChange(null, since);
                partner?.Partner.AddChange(null, since);
            }
            else
            {
                if (arg.BirthDate > since)
                {
                    throw new HistoryViolationException("Cannot set a partner who was not born that time.");
                }

                if (since > arg.DeathDate)
                {
                    throw new HistoryViolationException("Cannot set a partner who is already dead that time.");
                }

                if (arg.Partner.ValueAt(since).HasValue)
                {
                    throw new HistoryViolationException("Cannot set a partner who had already the partner that time.");
                }

                arg.PartnerReference.AddChange(this, since);
                arg.Partner.AddChange(Id, since);
            }

            Partner.AddChange(arg?.Id, since);
            PartnerReference.AddChange(arg, since);

            return this;
        }

        public FamilyMember WithPartner(FamilyMember arg, DateTime since)
        {
            if (arg == null)
            {
                throw new ArgumentException("Trying to set null partner.");
            }

            return SetPartner(arg, since);
        }

        public FamilyMember WithoutPartner(DateTime since)
        {
            if (!HadPartner(since))
            {
                throw new HistoryViolationException("Cannot break up with the partner that was not set that time.");
            }

            return SetPartner(null, since);
        }

        public FamilyMember GotMarried(DateTime since, FamilyMember partner = null)
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
            PartnerReference.ValueAt(since)?.Status.AddChange(StatusOptions.Married, since);
            return this;
        }

        public FamilyMember GotUnmarried(DateTime since)
        {
            if (!Partner.ValueAt(since).HasValue)
            {
                throw new HistoryViolationException("Cannot get unmarried without any partner.");
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

        public PropHistory<FamilyMember> PartnerReference { get; private set; }

        public FamilyMember ParentReference { get; private set; }

        public List<FamilyMember> ChildrenReference { get; private set; }

        private void RepairInitialization()
        {
            Dictionary<DateTime, StatusOptions> existingChanges = Status.Changes;
            Dictionary<DateTime, string> fullNameChanges = FullName.Changes;
            Initialize();
            Status.Changes = existingChanges;
            FullName.Changes = fullNameChanges;
        }

        private void RepairPartnerReference(Func<Guid, FamilyMember> mapper)
        {
            foreach (DateTime since in Partner.Changes.Keys)
            {
                Guid? partnerId = Partner.Changes[since];
                if (Partner.Changes[since].HasValue)
                {
                    PartnerReference.AddChange(mapper(partnerId.Value), since);
                }
                else
                {
                    PartnerReference.AddChange(null, since);
                }
            }
        }

        public FamilyMember RepairAfterSerialization(Func<Guid, FamilyMember> mapper)
        {
            RepairInitialization();

            if (PartnerReference.Changes.Count() > 0 || ParentReference != null || ChildrenReference.Count() > 0)
            {
                throw new Exception("This method can be used only after the serialization.");
            }

            RepairPartnerReference(mapper);

            if (Parent.HasValue)
            {
                ParentReference = mapper(Parent.Value);
            }

            foreach (Guid childId in Children)
            {
                ChildrenReference.Add(mapper(childId));
            }

            return this;
        }
    }
}
