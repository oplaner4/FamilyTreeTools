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
        protected void Initialize(Member source)
        {
            Partner = new PropHistory<Member>();
            Children = new Dictionary<Guid, Member>();
            Source = source ?? throw new NullReferenceException("Trying to set null source.");
        }

        public References(Member source)
        {
            Initialize(source);
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
                    if (TryGetPartner(out Member value, since))
                    {
                        value.Refs.UpdatePartner(arg, since, false);
                    }
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

        public References ClearPartnersHistory()
        {
            IEnumerable<DateTime> records = Partner.Changes.Keys.Where(
                ch => ch != Source.BirthDate
            ).ToArray();

            foreach (DateTime since in records)
            {
                if (Partner.Changes[since] != null)
                {
                    Partner.Changes[since].Refs.Partner.Changes.Remove(since);
                    Partner.Changes[since].Refs.PartnerId.Changes.Remove(since);
                    Partner.Changes[since].Status.Changes.Remove(since);
                }

                Source.Status.Changes.Remove(since);
                Partner.Changes.Remove(since);
                PartnerId.Changes.Remove(since);
            }

            IEnumerable<DateTime> statusRecords = Source.Status.Changes.Keys.Where(
                ch => ch != Source.BirthDate
            ).ToArray();

            foreach (DateTime since in statusRecords)
            {
                Source.Status.Changes.Remove(since);
            }

            return this;
        }

        public Member Parent { get; private set; }

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
        internal References Repair(Member source, Func<Guid, Member> mapper)
        {
            Initialize(source);
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

        private HashSet<Member> GetDescendants(SearchSettings settings, bool noncycle)
        {
            HashSet<Member> result = new HashSet<Member>();

            if (noncycle && (
                    settings.CanBeIllegitimateRelative ||
                    Source.WasMarried(settings.At)
                ) && TryGetPartner(
                    out Member value, settings.At, settings.CanBeDead
                )
            )
            {
                result.UnionWith(value.Refs.GetDescendants(settings, false));
            }

            foreach (Member child in Children.Values)
            {
                if (child.IsBorn(settings.At, settings.CanBeDead))
                {
                    result.Add(child);

                    if (settings.CanBeFromFartherGeneration)
                    {
                        result.UnionWith(child.Refs.GetDescendants(settings, true));
                    }
                }
            }

            return result;
        }

        public HashSet<Member> GetDescendants(SearchSettings settings)
        {
            return GetDescendants(settings, true);
        }

        public bool IsRootAncestor(SearchSettings settings)
        {
            SearchSettings useSettings = new SearchSettings()
            {
                At = settings.At,
                CanBeDead = settings.CanBeDead,
                CanBePartnerOtherTime = settings.CanBePartnerOtherTime,
                CanBeIllegitimateRelative = false,
                CanBeFromFartherGeneration = false
            };

            if (!Source.IsBorn(useSettings.At, useSettings.CanBeDead) ||
                GetAncestors(useSettings).Any()
            )
            {
                return false;
            }

            if (TryGetPartner(out Member value, useSettings.At, useSettings.CanBeDead))
            {
                return !value.Refs.GetAncestors(useSettings).Any();
            }

            return useSettings.CanBePartnerOtherTime || !Source.HadAnyPartner();
        }

        public bool TryGetPartner(out Member value, DateTime at, bool canBeDead = false)
        {
            value = Partner.Value(at);
            return value != null && value.IsBorn(at, canBeDead);
        }

        private HashSet<Member> GetAncestors(SearchSettings settings, bool noncycle)
        {
            HashSet<Member> result = new HashSet<Member>();

            if (Parent != null && Parent.IsBorn(settings.At, settings.CanBeDead))
            {
                result.Add(Parent);

                if (settings.CanBeFromFartherGeneration)
                {
                    result.UnionWith(Parent.Refs.GetAncestors(settings, true));
                }

                if (noncycle && (
                        settings.CanBeIllegitimateRelative ||
                        Parent.WasMarried(Source.BirthDate)
                    ) && Parent.Refs.TryGetPartner(
                        out Member value, Source.BirthDate, settings.CanBeDead
                    )
                )
                {
                    result.Add(value);

                    if (settings.CanBeFromFartherGeneration)
                    {
                        result.UnionWith(value.Refs.GetAncestors(settings, false));
                    }
                }
            }

            return result;
        }

        public HashSet<Member> GetAncestors(SearchSettings settings)
        {
            return GetAncestors(settings, true);
        }

        public HashSet<Member> GetSiblings(SearchSettings settings)
        {
            HashSet<Member> result = new HashSet<Member>();

            if (Parent != null)
            {
                bool canBeFromFartherGeneration = settings.CanBeFromFartherGeneration;
                settings.CanBeFromFartherGeneration = false;

                result.UnionWith(Parent.Refs.GetDescendants(settings));

                settings.CanBeFromFartherGeneration = canBeFromFartherGeneration;
            }

            result.Remove(Source);
            return result;
        }
    }
}
