using FamilyTreeTools.Entities;
using FamilyTreeTools.Entities.Exceptions;
using FamilyTreeTools.Utilities.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class MemberTests
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
        public readonly DateTime JazmynWhiteBirthDate = new DateTime(1983, 8, 22);

        [TestMethod]
        public void InvalidChanges()
        {
            int i = 1;
            foreach (Action familyMemberF in new List<Action>() {
                () => new Member(JohnSmith, DateTime.Now.AddDays(3)), /* 1 */

                () => new Member(JohnSmith, JohnSmithBirthDate) /* 2 */
                    .Died(JohnSmithBirthDate.AddDays(-4)),

                () => new Member(JohnSmith, JohnSmithBirthDate) /* 3 */
                    .Died(DateTime.Now.AddHours(18)),

                () => new Member(JohnSmith, JohnSmithBirthDate).WithPartner( /* 4 */
                        new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate),
                        DateTime.Now.AddYears(20)
                    ),

                () => new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate) /* 5 */
                    .GotUnmarried(HuzaifaMscgrathBirthDate.AddYears(28)),

                () => new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate).HadChild( /* 6 */
                        new Member(JohnSmith, JohnSmithBirthDate)
                    ),

                () => new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate) /* 7 */
                    .WithPartner(
                        new Member(JohnSmith, JohnSmithBirthDate.AddYears(24)), HuzaifaMscgrathBirthDate.AddYears(20)
                    ),

                () => new Member(JohnSmith, JohnSmithBirthDate) /* 8 */
                    .WithoutPartner(DateTime.Now),

                () => new Member(JohnSmith, JohnSmithBirthDate).GotMarried( /* 9 */
                        HuzaifaMscgrathBirthDate.AddDays(-20),
                        new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new Member(JohnSmith, JohnSmithBirthDate).GotMarried( /* 10 */
                        HuzaifaMscgrathBirthDate.AddDays(-20),
                        new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new Member(JohnSmith, JohnSmithBirthDate) /* 11 */
                    .WithPartner(
                        new Member(ShylaBoyce, ShylaBoyceBirthDate),
                        JohnSmithBirthDate.AddYears(19)
                    )
                    .GotMarried(
                        JohnSmithBirthDate.AddYears(20),
                        new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate)
                    ),

                () => new Member(JohnSmith, JohnSmithBirthDate)
                        .ChangedFullName("", DateTime.Now), /* 12 */

                () => new Member(ShylaBoyce, ShylaBoyceBirthDate) /* 13 */
                        .GotMarried(DateTime.Now),

                () => new Member(JohnSmith, JohnSmithBirthDate) /* 14 */
                        .WithPartner(
                            new Member(ShylaBoyce, ShylaBoyceBirthDate),
                            JohnSmithBirthDate.AddYears(19)
                        )
                        .WithPartner(
                            new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate),
                            JohnSmithBirthDate.AddYears(19)
                        ),

                () => new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate) /* 15 */
                        .WithPartner(
                            new Member(JohnSmith, JohnSmithBirthDate)
                                .WithPartner(
                                    new Member(ShylaBoyce, ShylaBoyceBirthDate),
                                    JohnSmithBirthDate.AddYears(25)
                                ),
                            JohnSmithBirthDate.AddYears(26)
                        ),

                () => { /* 16 */
                    Member Jazmyn = new Member(JazmynWhite, JazmynWhiteBirthDate);
                    new Member(ShylaBoyce, ShylaBoyceBirthDate).HadChild(Jazmyn);
                    new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate).HadChild(Jazmyn);
                },

                () => { /* 17 */
                    Member Jazmyn = new Member(JazmynWhite, JazmynWhiteBirthDate);
                    Jazmyn.HadChild(Jazmyn);
                },

                () => { /* 18 */
                    Member Jazmyn = new Member(JazmynWhite, JazmynWhiteBirthDate);
                    Jazmyn.WithPartner(Jazmyn, DateTime.Now);
                },

                () => { /* 19 */
                    Member Huzaifa = new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate);
                    new Member(JazmynWhite, JazmynWhiteBirthDate)
                    .GotMarried(DateTime.Now.AddYears(-5), Huzaifa)
                    .GotMarried(DateTime.Now, Huzaifa);
                },

                () => { /* 20 */
                    Member Huzaifa = new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate);
                    Member Shyla = new Member(ShylaBoyce, ShylaBoyceBirthDate);
                    new Member(JazmynWhite, JazmynWhiteBirthDate)
                    .GotMarried(DateTime.Now.AddYears(-6), Huzaifa)
                    .GotMarried(DateTime.Now, Shyla);
                },

                () => { /* 21 */
                    Member Huzaifa = new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate);
                    new Member(JohnSmith, JohnSmithBirthDate)
                    .WithPartner(Huzaifa, DateTime.Now.AddYears(-7))
                    .HadChild(Huzaifa);
                }
            })
            {
                Assert.ThrowsException<HistoryViolationException>(
                    () => familyMemberF(),
                    string.Format("Case {0} was not an invalid change.", i++)
                );
            }
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

            Member Huzaifa = new Member(HuzaifaMscgrath, HuzaifaMscgrathBirthDate);
            Member Shyla = new Member(ShylaBoyce, ShylaBoyceBirthDate);
            Member Laila = new Member(LailaNorman, LailaNormanBirthDate);

            Assert.IsFalse(Laila.WasEverMarried());
            Assert.IsFalse(Laila.HadAnyPartner());

            Member John = new Member(JohnSmith, JohnSmithBirthDate)
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

        public void CheckAncestorsMarwah()
        {
            HashSet<Member> ancestors = FamilyGenerator.Marwah.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Marwah.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(3, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Sonya));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Heena));


            ancestors = FamilyGenerator.Marwah.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Marwah.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(4, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Sonya));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Heena));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Kaleb));


            ancestors = FamilyGenerator.Marwah.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Marwah.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = false,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(1, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Sonya));
        }

        public void CheckAncestorsKian()
        {
            HashSet<Member> ancestors = FamilyGenerator.Kian.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Kian.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(5, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Moesha));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.John));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Rumaysa));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Kaleb));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));


            ancestors = FamilyGenerator.Kian.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Kian.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(3, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Moesha));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Rumaysa));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));


            ancestors = FamilyGenerator.Kian.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Kian.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = false,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Moesha));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.John));
        }

        public void CheckAncestorsRaja()
        {

            HashSet<Member> ancestors = FamilyGenerator.Raja.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(1, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));


            ancestors = FamilyGenerator.Raja.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Hailie));
        }

        public void CheckAncestorsAhsan()
        {
            HashSet<Member> ancestors = FamilyGenerator.Ahsan.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Ahsan.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(0, ancestors.Count);
        }

        public void CheckAncestorsHenrietta()
        {
            HashSet<Member> ancestors = FamilyGenerator.Henrietta.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Henrietta.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(3, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Heena));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Kaleb));


            ancestors = FamilyGenerator.Henrietta.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(2, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Heena));


            ancestors = FamilyGenerator.Henrietta.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = false,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Heena));
        }

        public void CheckAncestorsIsmaeel()
        {
            HashSet<Member> ancestors = FamilyGenerator.Ismaeel.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Ismaeel.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Hailie));


            ancestors = FamilyGenerator.Ismaeel.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Ismaeel.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(1, ancestors.Count);
            Assert.IsTrue(ancestors.Contains(FamilyGenerator.Fleur));
        }

        [TestMethod]
        public void Ancestors()
        {
            CheckAncestorsMarwah();
            CheckAncestorsKian();
            CheckAncestorsRaja();
            CheckAncestorsAhsan();
            CheckAncestorsHenrietta();
            CheckAncestorsIsmaeel();

            HashSet<Member> ancestors = FamilyGenerator.Karishma.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Karishma.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(0, ancestors.Count);

            ancestors = FamilyGenerator.Kaleb.Refs.GetAncestors(
                new SearchSettings()
                {
                    At = FamilyGenerator.Kaleb.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(0, ancestors.Count);
        }

        [TestMethod]
        public void Descendants()
        {
            HashSet<Member> descendants = FamilyGenerator.Karishma.Refs.GetDescendants(
                new SearchSettings()
                {
                    At = FamilyGenerator.Klara.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(3, descendants.Count);
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Rumaysa));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Klara));


            descendants = FamilyGenerator.Kaleb.Refs.GetDescendants(
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(10, descendants.Count);
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Sonya));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Henrietta));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Rumaysa));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Marian));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Moesha));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Klara));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Jun));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Kian));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Marwah));


            descendants = FamilyGenerator.Hailie.Refs.GetDescendants(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = false
                }
            );

            Assert.AreEqual(0, descendants.Count);


            descendants = FamilyGenerator.Hailie.Refs.GetDescendants(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.BirthDate,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, descendants.Count);
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Raja));
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Ismaeel));


            descendants = FamilyGenerator.Hailie.Refs.GetDescendants(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.DeathDate.Value,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(1, descendants.Count);
            Assert.IsTrue(descendants.Contains(FamilyGenerator.Ismaeel));
        }

        [TestMethod]
        public void Siblings()
        {
            HashSet<Member> siblings = FamilyGenerator.Korey.Refs.GetSiblings(
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, siblings.Count);
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Rumaysa));
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Klara));


            siblings = FamilyGenerator.Rumaysa.Refs.GetSiblings(
                new SearchSettings()
                {
                    At = DateTime.Now,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(2, siblings.Count);
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Korey));
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Klara));


            siblings = FamilyGenerator.Ismaeel.Refs.GetSiblings(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.BirthDate,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(1, siblings.Count);
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Raja));


            siblings = FamilyGenerator.Ismaeel.Refs.GetSiblings(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.DeathDate.Value,
                    CanBeDead = false,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(0, siblings.Count);


            siblings = FamilyGenerator.Ismaeel.Refs.GetSiblings(
                new SearchSettings()
                {
                    At = FamilyGenerator.Raja.DeathDate.Value,
                    CanBeDead = true,
                    CanBeFromFartherGeneration = true,
                    CanBeIllegitimateRelative = true
                }
            );

            Assert.AreEqual(1, siblings.Count);
            Assert.IsTrue(siblings.Contains(FamilyGenerator.Raja));
        }
    }
}
