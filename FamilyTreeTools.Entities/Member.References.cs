using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    public partial class Member : Human
    {
        private List<Guid> _ChildrenReference { get; set; }

        [JsonProperty]
        public List<Guid> ChildrenReference
        {
            get
            {
                return _ChildrenReference;
            }
            set
            {
                _ChildrenReference = value ?? throw new Exception("Trying to set null children reference.");
            }
        }

        [JsonProperty]
        public Guid? ParentReference { get; set; }

        private PropHistory<Guid?> _PartnerReference { get; set; }

        [JsonProperty]
        public PropHistory<Guid?> PartnerReference
        {
            get
            {
                return _PartnerReference;
            }
            set
            {
                _PartnerReference = value ?? throw new Exception("Trying to set null partner reference.");
            }
        }

        public PropHistory<Member> Partner { get; private set; }

        public Member Parent { get; private set; }

        public List<Member> Children { get; private set; }

        private void RepairPartnerReference(Func<Guid, Member> mapper)
        {
            foreach (DateTime since in PartnerReference.Changes.Keys)
            {
                Guid? partnerId = PartnerReference.Changes[since];
                if (PartnerReference.Changes[since].HasValue)
                {
                    Partner.AddChange(mapper(partnerId.Value), since);
                }
                else
                {
                    Partner.AddChange(null, since);
                }
            }
        }

        /// <summary>
        /// This method is used only after serialization.
        /// </summary>
        internal Member RepairReferences(Func<Guid, Member> mapper)
        {
            RepairInitialization();

            if (Partner.Changes.Count() > 0 ||
                Parent != null ||
                Children.Count() > 0)
            {
                throw new Exception("This method can be used only after the serialization.");
            }

            RepairPartnerReference(mapper);

            if (ParentReference.HasValue)
            {
                Parent = mapper(ParentReference.Value);
            }

            foreach (Guid childId in ChildrenReference)
            {
                Children.Add(mapper(childId));
            }

            return this;
        }

        public IEnumerable<Member> GetChildrenWithSpouse(SearchSettings settings)
        {
            List<Member> result = Children;

            if (WasMarried(settings.At))
            {
                foreach (Member child in Partner.Value(settings.At).Children)
                {
                    result.Add(child);
                }
            }

            return result.Where(ch => ch.IsBorn(settings.At, settings.CanBeDead));
        }

        public bool IsRootAncestor(SearchSettings settings)
        {
            if (!IsBorn(settings.At, settings.CanBeDead) || GetAncestors(settings).Any())
            {
                return false;
            }

            Member partner = Partner.Value(settings.At);
            if (partner == null)
            {
                return settings.CanBePartnerOtherTime || !HadAnyPartner();
            }

            return !partner.GetAncestors(settings).Any();
        }

        public List<Member> GetAncestors(SearchSettings settings)
        {
            List<Member> result = new List<Member>();

            if (Parent != null && (settings.CanBeDead || !Parent.IsDead(settings.At)))
            {
                result.Add(Parent);

                if (settings.GoDeep)
                {
                    result.AddRange(Parent.GetAncestors(settings));

                    Member partner = Parent.Partner.Value(BirthDate);
                    if (partner != null && (settings.CanBeDead || !partner.IsDead(settings.At)))
                    {
                        result.AddRange(partner.GetAncestors(settings));
                    }
                }
            }

            return result;
        }
    }
}
