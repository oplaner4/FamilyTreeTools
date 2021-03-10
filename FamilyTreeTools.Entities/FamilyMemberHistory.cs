using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    public class FamilyMemberHistory
    {
        public FamilyMemberHistory(
            FamilyMember member
        )
        {
            MemberId = member.Id;
            Data = new List<FamilyMember>
            {
                member
            };
        }

        public Guid MemberId { get; private set; }

        private List<FamilyMember> Data { get; set; }

        public delegate void FamilyMemberUpdater(FamilyMember member);

        public FamilyMemberHistory AddChange(FamilyMemberUpdater updater, DateTime validStart, DateTime? validEnd = null)
        {
            FamilyMember last = Data.Last();

            if (last.IsDead())
            {
                throw new Exception("Cannot update data of the dead family member.");
            }

            last.SetValidEnd(
                validStart.AddMilliseconds(-1)
            );

            FamilyMember result = last.Clone();

            updater(
                result.SetValidStart(validStart).SetValidEnd(validEnd)
            );

            Data.Add(result);
            return this;
        }

        public object GetMemberPropertyAt (string prop, DateTime d)
        {
            List<object> candidates = new List<object>();

            foreach (FamilyMember member in Data)
            {
                if (member.IsValidAt(d))
                {
                    candidates.Add(
                        member.GetType().GetProperty(prop).GetValue(member, null)
                    );
                }
            }

            return candidates.FirstOrDefault();
        }

    }
}
