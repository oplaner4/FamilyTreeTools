using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTreeTools.Helpers.Generators;
using System;
using FamilyTreeTools.Entities;
using System.Collections.Generic;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class FamilyMemberTest
    {
        [TestMethod]
        public void Defining()
        {
            Assert.IsTrue(DataGenerator.KalebHistory.GetMemberPropertyAt("Partner", DateTime.Now) == null);






            //foreach (FamilyMemberHistory history in data.Values) {
            //    List<FamilyMember> KalebChildren = (List<FamilyMember>)history.GetMemberPropertyAt("Children", new DateTime(2005, 4, 3));
            //}


        }
    }
}
