using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Family
    {
        /// <summary>
        /// This constructor is used only during deserialization.
        /// </summary>
        [JsonConstructor]
        public Family()
        { }

        public Family(string name, Dictionary<Guid, Member> members = null)
        {
            Members = members ?? new Dictionary<Guid, Member>();
            Name = name;
        }

        private string _Name { get; set; }

        public string Name {
            get {
                return _Name;
            }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Trying to set null name.");
                }

                _Name = value;
            }
        }

        private Dictionary<Guid, Member> _Members { get; set; }

        [JsonProperty]
        public Dictionary<Guid, Member> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value ?? throw new NullReferenceException("Trying to set null members.");
            }
        }

        public Family AddMember(Member arg)
        {
            if (arg == null)
            {
                throw new NullReferenceException("Trying to add a null member.");
            }

            Members.Add(arg.Id, arg);
            return this;
        }

        public Family RemoveMember(Member arg)
        {
            if (!CanBeRemoved(arg))
            {
                throw new HistoryViolationException("Member has children or partner at some time.");
            }

            if (arg.Refs.Parent != null)
            {
                arg.Refs.Parent.Refs.RemoveChild(arg);
            }

            Members.Remove(arg.Id);
            return this;
        }

        public bool CanBeRemoved(Member arg)
        {
            return !arg.Refs.Children.Any() && !arg.HadAnyPartner();
        }

        /// <summary>
        /// This method is used only after serialization.
        /// </summary>
        public Family Repair()
        {
            foreach (Member member in Members.Values)
            {
                member.Repair(id => Members[id]);
            }

            return this;
        }

        public IEnumerable<Member> GetRootAncestors(SearchSettings settings)
        {
            IEnumerable<Member> result = Members.Values.Where(
                m => m.Refs.IsRootAncestor(settings)
            );

            return result;
        }

        public IEnumerable<Member> GetEnumerableMembers()
        {
            return Members.Values.OrderByDescending(m => m.BirthDate)
                .ThenBy(m => m.FullName);
        }
    }
}
