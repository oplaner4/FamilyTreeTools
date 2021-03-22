﻿using Newtonsoft.Json;
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

        internal References AddChild(Member arg)
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

        private HashSet<Member> GetSpouseChildren(SearchSettings settings, bool noncycle)
        {
            HashSet<Member> result = new HashSet<Member>();

            if (noncycle && TryGetSpouse(
                settings.At, settings.CanBeDead, out Member spouse
            ))
            {
                result.Union(spouse.Refs.GetSpouseChildren(settings, false));
            }

            foreach (Member child in Children.Values)
            {
                if (child.IsBorn(settings.At, settings.CanBeDead))
                {
                    result.Add(child);

                    if (settings.GoDeep)
                    {
                        result.Union(child.Refs.GetSpouseChildren(settings, true));
                    }
                }
            }

            return result;
        }

        public HashSet<Member> GetSpouseChildren(SearchSettings settings)
        {
            return GetSpouseChildren(settings, true);
        }

        public bool IsRootAncestor(SearchSettings settings)
        {
            SearchSettings useSettings = new SearchSettings()
            {
                At = settings.At,
                CanBeDead = settings.CanBeDead,
                CanBePartnerOtherTime = settings.CanBePartnerOtherTime,
                GoDeep = false
            };

            if (!Source.IsBorn(useSettings.At, useSettings.CanBeDead) || GetAncestors(useSettings).Any())
            {
                return false;
            }

            Member partner = Partner.Value(useSettings.At);
            if (partner == null)
            {
                return useSettings.CanBePartnerOtherTime || !Source.HadAnyPartner();
            }

            return !partner.Refs.GetAncestors(useSettings).Any();
        }

        public bool TryGetSpouse(DateTime at, bool canBeDead, out Member spouse)
        {
            spouse = Partner.Value(at);
            return spouse != null &&
                spouse.IsBorn(at, canBeDead) &&
                Source.WasMarried(at);
        }

        public HashSet<Member> GetAncestors(SearchSettings settings)
        {
            HashSet<Member> result = new HashSet<Member>();

            if (Parent != null && Parent.IsBorn(settings.At, settings.CanBeDead))
            {
                result.Add(Parent);

                if (settings.GoDeep)
                {
                    result.Union(Parent.Refs.GetAncestors(settings));

                    if (Parent.Refs.TryGetSpouse(
                        Source.BirthDate, settings.CanBeDead,
                        out Member spouse
                    ))
                    {
                        result.Union(spouse.Refs.GetAncestors(settings));
                    }
                }
            }

            return result;
        }
    }
}
