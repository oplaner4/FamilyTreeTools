using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.Entities
{
    public class FamilyMember : Human
    {
        public FamilyMember(
            string fullName, DateTime birthDate
        ) : base(fullName, birthDate)
        {
            Children = new List<FamilyMember>();
            SetValidStart(BirthDate);
        }

        [JsonConstructor]
        public FamilyMember()
        { }

        private List<FamilyMember>  _Children { get; set; }

        [JsonProperty]
        public List<FamilyMember> Children
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
        public Guid? PartnerId { get; set; }

        [JsonProperty]
        public DateTime? ValidStart { get; set; }

        [JsonProperty]
        public DateTime? ValidEnd { get; set; }

        public FamilyMember AddChild(FamilyMember child)
        {
            if (child.BirthDate < BirthDate)
            {
                throw new ArgumentException("The child's birth date before parent birth date.", nameof(child));
            }

            Children.Add(child);
            return this;
        }

        public bool HasPartner()
        {
            return PartnerId != null;
        }

        public FamilyMember SetPartner(FamilyMember arg)
        {
            PartnerId = arg?.Id;
            return this;
        }

        public FamilyMember RemovePartner()
        {
            return SetPartner(null);
        }

        public FamilyMember SetStatus(StatusOptions arg)
        {
            if (arg == StatusOptions.Married && !HasPartner())
            {
                throw new ArgumentException("The partner is not defined with status married.", nameof(arg));
            }

            Status = arg;
            return this;
        }

        public FamilyMember GotMarried(FamilyMember partner)
        {
            return SetPartner(partner).SetStatus(StatusOptions.Married);
        }

        public FamilyMember GotUnmarried()
        {
            return SetStatus(StatusOptions.Unmarried).RemovePartner();
        }

        public FamilyMember SetValidStart(DateTime? arg)
        {
            if (ValidEnd < arg)
            {
                throw new ArgumentException("Valid start date after end date.", nameof(arg));
            }

            ValidStart = arg;
            return this;
        }

        public FamilyMember SetValidEnd(DateTime? arg)
        {
            if (ValidStart > arg)
            {
                throw new ArgumentException("Valid end date before start date.", nameof(arg));
            }

            ValidEnd = arg;
            return this;
        }

        public bool IsValidAt(DateTime d)
        {
            if (AfterDeath(d))
            {
                return true;
            }

            if (ValidStart.HasValue && d < ValidStart)
            {
                return false;
            }

            if (ValidStart.HasValue && d > ValidEnd)
            {
                return false;
            }

            return true;
        }

        public bool AfterDeath(DateTime d)
        {
            return d > DeathDate;
        }

        /// <summary>
        /// Used by history.
        /// </summary>
        /// <returns></returns>
        public FamilyMember Clone()
        {
            return new FamilyMember(FullName, BirthDate)
            {
                Id = Id,
                PartnerId = PartnerId,
                Children = Children,
                Status = Status,
                DeathDate = DeathDate
            };
        }
    }
}
