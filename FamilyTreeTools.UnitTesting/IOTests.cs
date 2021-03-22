using FamilyTreeTools.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTreeTools.Utilities.Generators;
using FamilyTreeTools.Utilities.Serialize;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void FamilySerializeDeserialize()
        {
            Family fieldFamily = FamilyGenerator.GetData();
            Family deserializedFamily = new FamilySerializeHelper(
                string.Format(".\\serialized\\{0}", fieldFamily.Name)
            ).Save(fieldFamily).Load();

            foreach (Member member in fieldFamily.Members.Values)
            {
                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].BirthDate,
                    fieldFamily.Members[member.Id].BirthDate
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].DeathDate,
                    fieldFamily.Members[member.Id].DeathDate
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].Refs.ParentId,
                    fieldFamily.Members[member.Id].Refs.ParentId
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].Refs.ChildrenIds.Count(),
                    fieldFamily.Members[member.Id].Refs.ChildrenIds.Count()
                );

                foreach (DateTime at in new List<DateTime>() {
                    DateTime.Now,
                    FamilyGenerator.KalebWeddingDate,
                    FamilyGenerator.KoreyWeddingDate,
                    FamilyGenerator.RumaysaWeddingDate,
                    FamilyGenerator.HenriettaWeddingDate,
                    FamilyGenerator.SebastianWithKarishmaDate
                }.Where(d => d >= member.BirthDate))
                {
                    Assert.AreEqual(
                        deserializedFamily.Members[member.Id].FullName.Value(at),
                        fieldFamily.Members[member.Id].FullName.Value(at)
                    );

                    Assert.AreEqual(
                        deserializedFamily.Members[member.Id].Status.Value(at),
                        fieldFamily.Members[member.Id].Status.Value(at)
                    );
                }
            }

            FamilyTests.CheckFieldFamilyReferences(deserializedFamily);
        }

        [TestMethod]
        public void TreeSerialize()
        {
            Family fieldFamily = FamilyGenerator.GetData();

            int i = 0;
            foreach (SearchSettings settings in new List<SearchSettings>()
            {
                new SearchSettings()
                {
                    At = FamilyGenerator.Kaleb.BirthDate.AddYears(-10),
                    CanBeDead = true,
                    CanBePartnerOtherTime = false
                },
                new SearchSettings()
                {
                    At = FamilyGenerator.KalebWeddingDate,
                    CanBeDead = true,
                    CanBePartnerOtherTime = true
                },
                new SearchSettings()
                {
                    At = FamilyGenerator.KalebWeddingDate,
                    CanBeDead = false,
                    CanBePartnerOtherTime = false
                },
                new SearchSettings()
                {
                    At = FamilyGenerator.HenriettaWeddingDate,
                    CanBeDead = false,
                    CanBePartnerOtherTime = true
                },
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = true,
                    CanBePartnerOtherTime = false
                }
            })
            {
                string name = string.Format(
                    ".\\serialized\\{0} {1}",
                    fieldFamily.Name,
                    i++
                );

                new TreeSerializeHelper(name).Save(
                    new Tree(fieldFamily, settings).Build()
                );
            }
        }
    }
}
