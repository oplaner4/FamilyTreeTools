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

        /// <summary>
        /// Look for dead members.
        /// </summary>
        [JsonProperty]
        public bool CanBeDead { get; set; }

        /// <summary>
        /// Determines if members who are partners
        /// at another time, and are not connected with
        /// other relatives, should be included
        /// </summary>
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

        /// <summary>
        /// Look for members who are
        /// from a farther generation
        /// or just from the nearest.
        /// </summary>
        public bool GoDeep { get; set; }
    }
}
