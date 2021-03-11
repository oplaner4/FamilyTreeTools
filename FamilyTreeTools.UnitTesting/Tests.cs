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
    public class Tests
    {
        [TestMethod]
        public void Defining()
        {
            //Assert.IsTrue(DataGenerator.KalebHistory.GetMemberPropertyAt("Partner", DateTime.Now) == null);

            //foreach (FamilyMemberHistory history in data.Values) {
            //    List<FamilyMember> KalebChildren = (List<FamilyMember>)history.GetMemberPropertyAt("Children", new DateTime(2005, 4, 3));
            //}


        }

        [TestMethod]
        public void FamilySerialize()
        {
            string file = "generatedFamily.ft";

            Family generatedFamily = FamilyGenerator.GetData();
            Family deserializedFamily = new FamilySerializeHelper(file)
                .Save(generatedFamily).Load();

            foreach (FamilyMember member in new List<FamilyMember>() {
                FamilyGenerator.Kaleb,
                FamilyGenerator.Karishma
            }) {
                foreach (DateTime at in new List<DateTime>() {
                    DateTime.Now,
                    FamilyGenerator.KalebWeddingDate,
                    FamilyGenerator.KoreyWeddingDate,
                    FamilyGenerator.RumaysaWeddingDate
                })
                {
                    List<FamilyMember> generatedChildren = (List<FamilyMember>)generatedFamily.MembersData[member.Id].GetMemberPropertyAt("Children", at);
                    List<FamilyMember> deserializedChildren = (List<FamilyMember>)deserializedFamily.MembersData[member.Id].GetMemberPropertyAt("Children", at);
                    Assert.AreEqual(generatedChildren.Count(), deserializedChildren.Count());

                    foreach (string prop in new List<string>() { "FullName", "BirthDate", "DeathDate", "PartnerId" })
                    {
                        Assert.AreEqual(
                            deserializedFamily.MembersData[member.Id].GetMemberPropertyAt(prop, at),
                            generatedFamily.MembersData[member.Id].GetMemberPropertyAt(prop, at)
                        );
                    }

                }

            }




        }
    }
}
