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
            Children = new Dictionary<Guid, Member>();
        }

        public References(Member source)
        {
            Initialize();

            Source = source ?? throw new NullReferenceException("Trying to set null source.");
            ChildrenIds = new HashSet<Guid>();
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

        private HashSet<Guid> _ChildrenIds { get; set; }

        [JsonProperty]
        public HashSet<Guid> ChildrenIds
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
                if (arg == null)
                {
                    Partner.Value(since)?.Refs.UpdatePartner(arg, since, false);
                }
                else
                {
                    arg.Refs.UpdatePartner(Source, since, false);
                }
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
            Children.Add(arg.Id, arg);
            ChildrenIds.Add(arg.Id);
            arg.Refs.ParentId = Source.Id;
            arg.Refs.Parent = Source;
            return this;
        }

        public References RemoveChild(Member arg)
        {
            Children.Remove(arg.Id);
            ChildrenIds.Remove(arg.Id);
            arg.Refs.ParentId = null;
            arg.Refs.Parent = null;
            return this;
        }

        public Member Parent { get; set; }

        public Dictionary<Guid, Member> Children { get; private set; }

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
                Children.Add(childId, mapper(childId));
            }

            return this;
        }

        private IEnumerable<Member> GetChildrenWithSpouse(SearchSettings settings, bool noncycle)
        {
            List<Member> result = new List<Member>();

            if (noncycle && Source.WasMarried(settings.At))
            {
                result.AddRange(
                    Partner.Value(settings.At).Refs.GetChildrenWithSpouse(settings, false)
                );
            }

            foreach (Member child in Children.Values)
            {
                result.Add(child);

                if (settings.GoDeep)
                {
                    result.AddRange(child.Refs.GetChildrenWithSpouse(settings, true));
                }
            }

            return result.Where(ch => ch.IsBorn(settings.At, settings.CanBeDead));
        }

        public IEnumerable<Member> GetChildrenWithSpouse(SearchSettings settings)
        {
            return GetChildrenWithSpouse(settings, true);
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

            return !partner.Refs.GetAncestors(settings).Any();
        }

        public List<Member> GetAncestors(SearchSettings settings)
        {
            List<Member> result = new List<Member>();

            if (Parent != null && (settings.CanBeDead || !Parent.IsDead(settings.At)))
            {
                result.Add(Parent);

                if (settings.GoDeep)
                {
                    result.AddRange(Parent.Refs.GetAncestors(settings));

                    Member partner = Parent.Refs.Partner.Value(Source.BirthDate);
                    if (partner != null && (settings.CanBeDead || !partner.IsDead(settings.At)))
                    {
                        result.AddRange(partner.Refs.GetAncestors(settings));
                    }
                }
            }

            return result;
        }
    }
}
