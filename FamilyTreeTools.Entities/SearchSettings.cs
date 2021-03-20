using System;

namespace FamilyTreeTools.Entities
{
    public class SearchSettings
    {
        public SearchSettings ()
        {
            CanBeDead = true;
            CanBePartnerOtherTime = false;
            GoDeep = false;
            At = DateTime.Now;
        }

        public bool CanBeDead { get; set; }

        public bool CanBePartnerOtherTime { get; set; }

        public DateTime At { get; set; }

        public bool GoDeep { get; set; }
    }
}
