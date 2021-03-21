using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class References
    {
        protected void Initialize()
        {
            Partner = new PropHistory<Member>();
            Children = new List<Member>();
        }

        public References(Member source)
        {
            Initialize();

            Source = source ?? throw new NullReferenceException("Trying to set null source.");
            ChildrenIds = new List<Guid>();
            PartnerId = new PropHistory<Guid?>().AddChange(null, Source.BirthDate);
            Partner.AddChange(null, Source.BirthDate);
        }

        /// <summary>
        /// This constructor is used only during deserialization.
        /// </summary>
        [JsonConstructor]
        public References()
        { }

        public Member Source { get; private set; }

        private List<Guid> _ChildrenIds { get; set; }

        [JsonProperty]
        public List<Guid> ChildrenIds
        {
            get
            {
                return _ChildrenIds;
            }
            set
            {
                _ChildrenIds = value ?? throw new NullReferenceException("Trying to set null children ids.");
            }
        }

        [JsonProperty]
        public Guid? ParentId { get; set; }

        private PropHistory<Guid?> _PartnerId { get; set; }

        [JsonProperty]
        public PropHistory<Guid?> PartnerId
        {
            get
            {
                return _PartnerId;
            }
            set
            {
                _PartnerId = value ?? throw new NullReferenceException("Trying to set null partner id.");
            }
        }

        public PropHistory<Member> Partner { get; private set; }

        private References UpdatePartner(Member arg, DateTime since, bool noncycle)
        {
            if (noncycle)
            {
                Partner.Value(since)?.References.UpdatePartner(arg, since, false);
            }

            Partner.AddChange(arg, since);
            PartnerId.AddChange(arg?.Id, since);
            return this;
        }

        internal References UpdatePartner(Member arg, DateTime since)
        {
            return UpdatePartner(arg, since, true);
        }

        internal References AddChild (Member arg)
        {
            Children.Add(arg);
            ChildrenIds.Add(arg.Id);
            arg.References.ParentId = Source.Id;
            arg.References.Parent = Source;
            return this;
        }

        internal References RemoveChild(Member arg)
        {
            Children.Remove(arg);
            ChildrenIds.Remove(arg.Id);
            arg.References.ParentId = null;
            arg.References.Parent = null;
            return this;
        }

        public Member Parent { get; set; }

        public List<Member> Children { get; private set; }

        private void RepairPartner(Func<Guid, Member> mapper)
        {
            foreach (DateTime since in PartnerId.Changes.Keys)
            {
                Guid? partnerId = PartnerId.Changes[since];
                if (PartnerId.Changes[since].HasValue)
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
        internal References Repair(Func<Guid, Member> mapper)
        {
            Initialize();

            if (Partner.Changes.Count() > 0 ||
                Parent != null ||
                Children.Count() > 0)
            {
                throw new InvalidOperationException("This method can be used only after the serialization.");
            }

            RepairPartner(mapper);

            if (ParentId.HasValue)
            {
                Parent = mapper(ParentId.Value);
            }

            foreach (Guid childId in ChildrenIds)
            {
                Children.Add(mapper(childId));
            }

            return this;
        }

        public IEnumerable<Member> GetChildrenWithSpouse(SearchSettings settings)
        {
            List<Member> result = new List<Member>();

            if (Source.WasMarried(settings.At))
            {
                foreach (Member child in Partner.Value(settings.At).References.Children)
                {
                    result.Add(child);
                }
            }

            result.AddRange(Children);
            return result.Where(ch => ch.IsBorn(settings.At, settings.CanBeDead));
        }

        public bool IsRootAncestor(SearchSettings settings)
        {
            if (!Source.IsBorn(settings.At, settings.CanBeDead) || GetAncestors(settings).Any())
            {
                return false;
            }

            Member partner = Partner.Value(settings.At);
            if (partner == null)
            {
                return settings.CanBePartnerOtherTime || !Source.HadAnyPartner();
            }

            return !partner.References.GetAncestors(settings).Any();
        }

        public List<Member> GetAncestors(SearchSettings settings)
        {
            List<Member> result = new List<Member>();

            if (Parent != null && (settings.CanBeDead || !Parent.IsDead(settings.At)))
            {
                result.Add(Parent);

                if (settings.GoDeep)
                {
                    result.AddRange(Parent.References.GetAncestors(settings));

                    Member partner = Parent.References.Partner.Value(Source.BirthDate);
                    if (partner != null && (settings.CanBeDead || !partner.IsDead(settings.At)))
                    {
                        result.AddRange(partner.References.GetAncestors(settings));
                    }
                }
            }

            return result;
        }
    }
}
