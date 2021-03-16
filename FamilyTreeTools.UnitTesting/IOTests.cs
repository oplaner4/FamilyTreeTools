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
        public void FamilySerialize()
        {
            Family fieldFamily = FamilyGenerator.GetData();
            Family deserializedFamily = new FamilySerializeHelper(fieldFamily.Name)
                .Save(fieldFamily).Load();

            foreach (FamilyMember member in new List<FamilyMember>() {
                FamilyGenerator.Kaleb,
                FamilyGenerator.Karishma
            })
            {
                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].Children.Count(),
                    fieldFamily.Members[member.Id].Children.Count()
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].BirthDate,
                    fieldFamily.Members[member.Id].BirthDate
                );

                Assert.AreEqual(
                    deserializedFamily.Members[member.Id].DeathDate,
                    fieldFamily.Members[member.Id].DeathDate
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
                        fieldFamily.Members[member.Id].FullName.ValueAt(at)
                    );

                    Assert.AreEqual(
                        deserializedFamily.Members[member.Id].HadPartner(at),
                        fieldFamily.Members[member.Id].HadPartner(at)
                    );
                }
            }
        }

        [TestMethod]
        public void FamilyTreeSerialize()
        {
            Family fieldFamily = FamilyGenerator.GetData();
            TreeNode root = fieldFamily.BuidTree(FamilyGenerator.KoreyWeddingDate);

            new TreeSerializeHelper(fieldFamily.Name).Save(root);

        }
    }
}
