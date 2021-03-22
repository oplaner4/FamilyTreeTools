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
    public class TreeTests
    {
        [TestMethod]
        public void CorrectBuild()
        {
            Family fieldFamily = FamilyGenerator.GetData();

            Tree atHenriettaWeddingDate = new Tree(fieldFamily, new SearchSettings()
            {
                At = FamilyGenerator.HenriettaWeddingDate,
                CanBePartnerOtherTime = true
            }).Build();

            Node HenriettaNode = atHenriettaWeddingDate.Root.Children[FamilyGenerator.Kaleb.Id]
                .Children[FamilyGenerator.Korey.Id]
                .Children[FamilyGenerator.Henrietta.Id];

            Assert.AreEqual(FamilyGenerator.Ahsan.Id, HenriettaNode.Partner.Key);
            Assert.AreEqual(FamilyGenerator.Henrietta.Id, HenriettaNode.Partner.PartnerReference);


            /*  FamilyGenerator.Karishma,
              FamilyGenerator.Kaleb,
              FamilyGenerator.Sebastian,
              FamilyGenerator.Hailie,
              FamilyGenerator.Ashley,
              FamilyGenerator.Fleur,
              FamilyGenerator.John*/



        }
    }
}
