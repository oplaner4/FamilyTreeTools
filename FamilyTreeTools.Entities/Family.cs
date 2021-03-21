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

        /// <summary>
        /// This method is used only after serialization.
        /// </summary>
        public Family RepairReferences()
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
                m => m.References.IsRootAncestor(settings)
            );

            return result;
        }
    }
}
