using FamilyTreeTools.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class HumanTests
    {
        public readonly string PrishaKendall = "Prisha Kendall";
        public readonly DateTime PrishaKendallBirthDate = new DateTime(1940, 4, 5);
        public readonly DateTime PrishaKendallDiedDate = new DateTime(2020, 7, 11);

        [TestMethod]
        public void Queries()
        {
            Human Prisha = new Human(PrishaKendall, PrishaKendallBirthDate)
                .Died(PrishaKendallDiedDate);

            Assert.IsTrue(Prisha.IsBorn(DateTime.Now, true));
            Assert.IsFalse(Prisha.IsBorn(DateTime.Now));
            Assert.IsFalse(Prisha.IsBorn(DateTime.Now, false));
            Assert.IsFalse(Prisha.IsBorn(PrishaKendallBirthDate.AddDays(-4)));
            Assert.IsTrue(Prisha.IsDead(DateTime.Now));
            Assert.IsFalse(Prisha.IsDead(PrishaKendallBirthDate.AddYears(8)));
            Assert.IsFalse(Prisha.IsDead(PrishaKendallBirthDate.AddYears(-8)));
            Assert.IsTrue(Prisha.BeforeBirthday(PrishaKendallBirthDate.AddYears(10).AddDays(-1)));
            Assert.IsTrue(Prisha.BeforeBirthday(PrishaKendallBirthDate.AddYears(11).AddMonths(-2).AddDays(6)));
            Assert.IsFalse(Prisha.BeforeBirthday(PrishaKendallBirthDate.AddYears(12).AddMonths(3).AddDays(-1)));
            Assert.AreEqual(30, Prisha.GetAge(PrishaKendallBirthDate.AddYears(30).AddMonths(1).AddDays(4)));
            Assert.AreEqual(41, Prisha.GetAge(PrishaKendallBirthDate.AddMonths(2).AddYears(41)));
            Assert.AreEqual(24, Prisha.GetAge(PrishaKendallBirthDate.AddYears(25).AddMonths(-1).AddDays(10)));
        }
    }
}
