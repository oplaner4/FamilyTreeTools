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
        [JsonConstructor]
        public Family(Dictionary<Guid, FamilyMember> members = null)
        {
            Members = members ?? new Dictionary<Guid, FamilyMember>();
        }

        private Dictionary<Guid, FamilyMember> _Members { get; set; }

        [JsonProperty]
        public Dictionary<Guid, FamilyMember> Members {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value ?? throw new Exception("Trying to set null members.");
            }
        }

        public Family AddMember (FamilyMember arg)
        {
            Members.Add(arg.Id, arg);
            return this;
        }

        public Family RemoveMember (FamilyMember arg)
        {
            Members.Remove(arg.Id);
            return this;
        }

        public Guid? GetPartnerIdOf (Guid member, DateTime at)
        {
            Guid? partnerId = Members[member].PartnerId.ValueAt(at);

            if (partnerId.HasValue && Members.ContainsKey(partnerId.Value))
            {
                return partnerId;
            }

            return Members.Values.Where(m => {
                Guid? id = m.PartnerId.ValueAt(at);
                return id.HasValue && id.Value == member;
            }).Select(m => m.Id).FirstOrDefault();
        }

        public List<FamilyMember> ChildOf (Guid member, DateTime at)
        {
            return Members.Values.Where(m => GetBornChildrenOf (m.Id, at).Contains(member)).ToList();
        }

        public List<Guid> GetBornChildrenOf (Guid member, DateTime at)
        {
            return Members[member].Children.Where(ch => Members[ch].BirthDate >= at).ToList();
        }

        public List<FamilyMember> GetOldestAncestors (DateTime at)
        {
            return Members.Values.Where(m => !ChildOf(m.Id, at).Any()).ToList();
        }

        /*
        public List<Guid> GetBornChildrenWithPartnerAt(FamilyMemberData memberData, DateTime d)
        {
            Guid? partnerId = GetPartnerIdAt(memberData, d);
            List<Guid> children = memberData.GetBornChildrenAt(d);

            if (partnerId != null)
            {
                children.AddRange(MembersData[partnerId.Value].GetBornChildrenAt(d));
            }

            return children.ToList();
        }*/
    }
}
