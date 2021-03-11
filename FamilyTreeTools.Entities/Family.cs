using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.Entities
{
    public class Family
    {
        [JsonConstructor]
        public Family (Dictionary<Guid, History> membersData = null)
        {
            MembersData = membersData ?? new Dictionary<Guid, History>();
        }

        private Dictionary<Guid, History> _MembersData { get; set; }

        [JsonProperty]
        public Dictionary<Guid, History> MembersData {
            get
            {
                return _MembersData;
            }
            set
            {
                _MembersData = value ?? throw new Exception("Trying to set null members.");
            }
        }

        public Family AddMember(FamilyMember member)
        {
            MembersData.Add(member.Id, new History(member));
            return this;
        }

        public Family RemoveMember(FamilyMember member)
        {
            MembersData.Remove(member.Id);
            return this;
        }

        public Family ChangeMemberHistory(History history)
        {
            MembersData[history.MemberId] = history;
            return this;
        }
    }
}
