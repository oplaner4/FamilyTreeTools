using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTreeTools.Helpers.Generators;
using FamilyTreeTools.Helpers.Serialize;
using System;
using System.Collections.Generic;
using FamilyTreeTools.Entities;
using System.Linq;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void FamilySerialize()
        {
            string file = "generatedFamily.ftt";

            Family generatedFamily = FamilyGenerator.GetData();
            Family deserializedFamily = new FamilySerializeHelper(file)
                .Save(generatedFamily).Load();

            foreach (FamilyMember member in new List<FamilyMember>() {
                FamilyGenerator.Kaleb,
                FamilyGenerator.Karishma
            }) {
                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].Children.Count(),
                    generatedFamily.Members[member.Id].Children.Count()
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].BirthDate,
                    generatedFamily.Members[member.Id].BirthDate
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].DeathDate,
                    generatedFamily.Members[member.Id].DeathDate
                );

                foreach (DateTime at in new List<DateTime>() {
                    DateTime.Now,
                    FamilyGenerator.KalebWeddingDate,
                    FamilyGenerator.KoreyWeddingDate,
                    FamilyGenerator.RumaysaWeddingDate,
                    FamilyGenerator.HenriettaWeddingDate
                })
                {
                    Assert.AreEqual(
                        deserializedFamily.Members[member.Id].FullName.ValueAt(at),
                        generatedFamily.Members[member.Id].FullName.ValueAt(at)
                    );

                    Assert.AreEqual(
                        deserializedFamily.Members[member.Id].HadPartner(at),
                        generatedFamily.Members[member.Id].HadPartner(at)
                    );
                }
            }
        }
    }
}
