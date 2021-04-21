using FamilyTreeTools.Entities.Exceptions;
using Newtonsoft.Json;
using System;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SearchSettings
    {
        public SearchSettings()
        {
            CanBeDead = true;
            CanBePartnerOtherTime = false;
            CanBeFromFartherGeneration = true;
            CanBeIllegitimateRelative = false;
            At = DateTime.Now;
        }

        /// <summary>
        /// Look also for dead members.
        /// </summary>
        [JsonProperty]
        public bool CanBeDead { get; set; }

        /// <summary>
        /// Look also for members who are partners
        /// at another time and do not have any
        /// ancestor that time.
        /// </summary>
        [JsonProperty]
        public bool CanBePartnerOtherTime { get; set; }

        /// <summary>
        /// Date which is used to look for relatives.
        /// </summary>
        private DateTime _At { get; set; }

        [JsonProperty]
        public DateTime At
        {
            get
            {
                return _At;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new HistoryViolationException("Trying to search in the future.");
                }

                _At = value;
            }
        }

        /// <summary>
        /// Look also for members who are
        /// from a farther generation.
        /// </summary>
        public bool CanBeFromFartherGeneration { get; set; }

        /// <summary>
        /// Look also for members who
        /// are not legitimate relatives
        /// (from unmarried partner).
        /// </summary>
        public bool CanBeIllegitimateRelative { get; set; }
    }
}
