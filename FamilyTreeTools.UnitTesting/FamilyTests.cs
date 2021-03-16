using FamilyTreeTools.Entities;
using FamilyTreeTools.Utilities.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class FamilyTests
    {
        [TestMethod]
        public void Queries()
        {
            Family generatedFamily = FamilyGenerator.GetData();

        }
    }
}