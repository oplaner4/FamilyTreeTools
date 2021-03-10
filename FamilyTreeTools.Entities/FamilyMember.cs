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

        public List<FamilyMember> Children { get; private set; }

        public FamilyMember Partner { get; private set; }

        public FamilyMember AddChild(FamilyMember child)
        {
            if (child.BirthDate < BirthDate)
            {
                throw new ArgumentException("The child's birth date before parent birth date.", nameof(child));
            }

            Children.Add(child);
            return this;
        }

        public DateTime? ValidStart { get; private set; }
        public DateTime? ValidEnd { get; private set; }

        public bool HasPartner()
        {
            return Partner != null;
        }

        public FamilyMember SetPartner(FamilyMember arg)
        {
            if (arg == null)
            {
                Partner.Partner = null;
            }

            Partner = arg;

            if (HasPartner())
            {
                arg.Partner = this;
            }

            return this;
        }

        public FamilyMember RemovePartner ()
        {
            return SetPartner(null);
        }

        public FamilyMember SetStatus(StatusOptions arg)
        {
            if (arg == StatusOptions.Married && !HasPartner())
            {
                throw new ArgumentException("The partner is not defined with status married.", nameof(arg));
            }
            else if (HasPartner())
            {
                Partner.Status = arg;
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

        /// <summary>
        /// Used by history.
        /// </summary>
        /// <returns></returns>
        public FamilyMember Clone ()
        {
            return new FamilyMember(FullName, BirthDate)
            {
                Id = Id,
                Partner = Partner,
                Children = Children,
                Status = Status
            };
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
    }
}
