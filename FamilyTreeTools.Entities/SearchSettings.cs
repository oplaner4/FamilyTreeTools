using System;
using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SearchSettings
    {
        public SearchSettings ()
        {
            CanBeDead = true;
            CanBePartnerOtherTime = false;
            GoDeep = false;
            At = DateTime.Now;
        }

        [JsonProperty]
        public bool CanBeDead { get; set; }

        [JsonProperty]
        public bool CanBePartnerOtherTime { get; set; }

        private DateTime _At { get; set; }

        [JsonProperty]
        public DateTime At {
            get {
                return _At;
            }
            set {
                if (value > DateTime.Now)
                {
                    throw new HistoryViolationException("Cannot search in the future.");
                }

                _At = value;
            }
        }

        public bool GoDeep { get; set; }
    }
}
