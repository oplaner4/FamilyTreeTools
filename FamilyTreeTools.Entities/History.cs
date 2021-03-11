using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyTreeTools.Entities
{
    public class History
    {
        [JsonConstructor]
        public History()
        { }

        public History(
            FamilyMember member
        )
        {
            MemberId = member.Id;
            Changes = new List<FamilyMember>
            {
                member
            };
        }

        [JsonProperty]
        public Guid MemberId { get; set; }

        [JsonProperty]
        public List<FamilyMember> Changes { get; set; }

        public delegate void FamilyMemberUpdater(FamilyMember member);

        public History AddChange(FamilyMemberUpdater updater, DateTime validStart, DateTime? validEnd = null)
        {
            FamilyMember newest = Changes.Last();

            if (newest.AfterDeath(validStart))
            {
                throw new ArgumentException("Unable to change history after death.", nameof(validStart));
            }

            FamilyMember result = newest.Clone();

            updater(
                result.SetValidStart(validStart).SetValidEnd(validEnd)
            );

            Changes.Add(result);
            return this;
        }

        public object GetMemberPropertyAt(string prop, DateTime d)
        {
            foreach (FamilyMember member in Changes.OrderBy(m => m.ValidStart))
            {
                if (member.IsValidAt(d))
                {
                    return member.GetType().GetProperty(prop).GetValue(member, null);
                }
            }

            throw new Exception("No valid value of the property found.");
        }

    }
}
