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
    public class FamilyMemberTests
    {
        public readonly string JohnSmith = "John Smith";
        public readonly DateTime JohnSmithBirthDate = new DateTime(1950, 4, 3);
        public readonly string HuzaifaMscgrath = "Huzaifa Mcgrath";
        public readonly DateTime HuzaifaMscgrathBirthDate = new DateTime(1952, 7, 2);
        public readonly string ShylaBoyce = "Shyla Boyce";
        public readonly DateTime ShylaBoyceBirthDate = new DateTime(1953, 11, 1);
        public readonly string LailaNorman = "Laila Norman";
        public readonly DateTime LailaNormanBirthDate = new DateTime(1992, 1, 30);

        public readonly string JazmynWhite = "Jazmyn White";
        public readonly DateTime JazmynWhiteBirthDate = new DateTime(2014, 8, 22);

        public readonly string PrishaKendall = "Prisha Kendall";
        public readonly DateTime PrishaKendallBirthDate = new DateTime(2016, 4, 4);


        [TestMethod]
        public void InvalidChanges()
        {
            int i = 1;
            foreach (Func<Human> familyMemberF in new List<Func<Human>>() {
                () => new FamilyMember(JohnSmith, DateTime.Now.AddDays(3)), /* 1 */

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate) /* 2 */
                    .Died(JohnSmithBirthDate.AddDays(-4)),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate) /* 3 */
                    .Died(DateTime.Now.AddHours(18)),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate).WithPartner( /* 4 */
                        new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate),
                        DateTime.Now.AddYears(20)
                    ),

                () => new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate) /* 5 */
                    .GotUnmarried(HuzaifaMscgrathBirthDate.AddYears(28)),

                () => new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate).HadChild( /* 6 */
                        new FamilyMember(JohnSmith, JohnSmithBirthDate)
                    ),

                () => new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate) /* 7 */
                    .WithPartner(
                        new FamilyMember(JohnSmith, JohnSmithBirthDate.AddYears(24)), HuzaifaMscgrathBirthDate.AddYears(20)
                    ),

                () =>  new FamilyMember(JohnSmith, JohnSmithBirthDate) /* 8 */
                    .WithoutPartner(DateTime.Now),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate).GotMarried( /* 9 */
                        HuzaifaMscgrathBirthDate.AddDays(-20),
                        new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate).GotMarried( /* 10 */
                        HuzaifaMscgrathBirthDate.AddDays(-20),
                        new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate) /* 11 */
                    .WithPartner(
                        new FamilyMember(ShylaBoyce, ShylaBoyceBirthDate),
                        JohnSmithBirthDate.AddYears(19)
                    )
                    .GotMarried(
                        JohnSmithBirthDate.AddYears(20),
                        new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate)
                        .ChangedFullName("", DateTime.Now), /* 12 */

                () => new FamilyMember(ShylaBoyce, ShylaBoyceBirthDate) /* 13 */
                        .GotMarried(DateTime.Now),

                () => new FamilyMember(JohnSmith, JohnSmithBirthDate) /* 14 */
                        .WithPartner(
                            new FamilyMember(ShylaBoyce, ShylaBoyceBirthDate),
                            JohnSmithBirthDate.AddYears(19)
                        )
                        .WithPartner(
                            new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate),
                            JohnSmithBirthDate.AddYears(19)
                        )

            }) {
                try
                {
                    familyMemberF();
                }
                catch
                {
                    i++;
                    continue;
                }

                throw new Exception(string.Format("{0} Should have thrown an exception", i));
            }
        }

        [TestMethod]
        public void SpecialCases()
        {



        }

        [TestMethod]
        public void PartnersAtTime()
        {
            DateTime timeWithHuzaifa = JohnSmithBirthDate.AddYears(27).AddMonths(4).AddDays(1);
            DateTime timeMarriedWithHuzaifa = JohnSmithBirthDate.AddYears(29).AddMonths(6).AddDays(22);
            DateTime timeFirstUnmarried = JohnSmithBirthDate.AddYears(31).AddMonths(11).AddDays(4);
            DateTime timeWithShyla = JohnSmithBirthDate.AddYears(33).AddMonths(7).AddDays(10);
            DateTime timeWithoutPartner = JohnSmithBirthDate.AddYears(36).AddMonths(1).AddDays(25);
            DateTime timeSecondWithShyla = JohnSmithBirthDate.AddYears(40).AddMonths(2).AddDays(2);
            DateTime timeMarriedWithShyla = JohnSmithBirthDate.AddYears(45).AddMonths(5).AddDays(30);
            DateTime timeSecondUnmarried = JohnSmithBirthDate.AddYears(50).AddMonths(3).AddDays(9);

            FamilyMember Huzaifa = new FamilyMember(HuzaifaMscgrath, HuzaifaMscgrathBirthDate);
            FamilyMember Shyla = new FamilyMember(ShylaBoyce, ShylaBoyceBirthDate);
            FamilyMember Laila = new FamilyMember(LailaNorman, LailaNormanBirthDate);

            Assert.IsFalse(Laila.WasEverMarried());
            Assert.IsFalse(Laila.HadAnyPartner());

            FamilyMember John = new FamilyMember(JohnSmith, JohnSmithBirthDate)
                .WithPartner(Huzaifa, timeWithHuzaifa)
                .GotMarried(timeMarriedWithHuzaifa)
                .GotUnmarried(timeFirstUnmarried)
                .WithPartner(Shyla, timeWithShyla)
                .WithoutPartner(timeWithoutPartner)
                .WithPartner(Shyla, timeSecondWithShyla)
                .GotMarried(timeMarriedWithShyla)
                .GotUnmarried(timeSecondUnmarried);


            void nobodyMarried(DateTime d)
            {
                Assert.IsFalse(John.WasMarried(d));
                Assert.IsFalse(Huzaifa.WasMarried(d));
                Assert.IsFalse(Shyla.WasMarried(d));
            }

            void nobodyPartner(DateTime d)
            {
                Assert.IsFalse(John.HadPartner(d));
                Assert.IsFalse(Huzaifa.HadPartner(d));
                Assert.IsFalse(Shyla.HadPartner(d));
            }


            Assert.IsTrue(John.HadAnyPartner());
            Assert.IsTrue(Shyla.HadAnyPartner());
            Assert.IsTrue(Huzaifa.HadAnyPartner());
            Assert.IsTrue(John.WasEverMarried());
            Assert.IsTrue(Shyla.WasEverMarried());
            Assert.IsTrue(Huzaifa.WasEverMarried());

            nobodyMarried(ShylaBoyceBirthDate);
            nobodyPartner(ShylaBoyceBirthDate);

            Assert.IsTrue(John.HadPartner(timeWithHuzaifa, Huzaifa));
            Assert.IsTrue(Huzaifa.HadPartner(timeWithHuzaifa, John));
            Assert.IsFalse(Shyla.HadPartner(timeWithHuzaifa));
            nobodyMarried(timeWithHuzaifa);

            Assert.IsTrue(John.HadPartner(timeMarriedWithHuzaifa, Huzaifa));
            Assert.IsTrue(Huzaifa.HadPartner(timeMarriedWithHuzaifa, John));
            Assert.IsFalse(Shyla.HadPartner(timeMarriedWithHuzaifa));
            Assert.IsTrue(John.WasMarried(timeMarriedWithHuzaifa));
            Assert.IsTrue(Huzaifa.WasMarried(timeMarriedWithHuzaifa));
            Assert.IsFalse(Shyla.WasMarried(timeMarriedWithHuzaifa));

            nobodyMarried(timeFirstUnmarried);
            nobodyPartner(timeFirstUnmarried);

            Assert.IsTrue(John.HadPartner(timeWithShyla, Shyla));
            Assert.IsTrue(Shyla.HadPartner(timeWithShyla, John));
            Assert.IsFalse(Huzaifa.HadPartner(timeWithShyla));
            nobodyMarried(timeWithShyla);

            nobodyMarried(timeWithoutPartner);
            nobodyPartner(timeWithoutPartner);

            Assert.IsTrue(John.HadPartner(timeSecondWithShyla, Shyla));
            Assert.IsTrue(Shyla.HadPartner(timeSecondWithShyla, John));
            Assert.IsFalse(Huzaifa.HadPartner(timeSecondWithShyla));
            nobodyMarried(timeSecondWithShyla);

            Assert.IsTrue(John.HadPartner(timeMarriedWithShyla, Shyla));
            Assert.IsTrue(Shyla.HadPartner(timeMarriedWithShyla, John));
            Assert.IsFalse(Huzaifa.HadPartner(timeMarriedWithShyla));
            Assert.IsTrue(John.WasMarried(timeMarriedWithShyla));
            Assert.IsTrue(Shyla.WasMarried(timeMarriedWithShyla));
            Assert.IsFalse(Huzaifa.WasMarried(timeMarriedWithShyla));

            nobodyMarried(timeSecondUnmarried);
            nobodyPartner(timeSecondUnmarried);
        }
    }
}
