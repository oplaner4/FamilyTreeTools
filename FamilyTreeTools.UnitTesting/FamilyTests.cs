using FamilyTreeTools.Entities;
using FamilyTreeTools.Utilities.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using System.Collections.Generic;
using FamilyTreeTools.Entities.Exceptions;

namespace FamilyTreeTools.UnitTesting
{
    [TestClass]
    public class FamilyTests
    {
        [TestMethod]
        public void RootAncestors()
        {
            Family fieldFamily = FamilyGenerator.GetData();


            Assert.ThrowsException<HistoryViolationException>(
                () => new SearchSettings() { At = DateTime.Now.AddDays(7) },
                "Future date should have thrown an exception."
            );

            int i = 1;
            foreach (KeyValuePair<SearchSettings, List<Member>> expected in new Dictionary<SearchSettings, List<Member>>() {
                { /* 1 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate.AddYears(-10),
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {}
                },
                { /* 2 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate,
                        CanBePartnerOtherTime = false
                    },
                    new List<Member>() {}
                },
                { /* 3 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Kaleb
                    }
                },
                { /* 4 */
                    new SearchSettings() {
                        At = FamilyGenerator.Karishma.BirthDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma
                    }
                },
                { /* 5 */
                    new SearchSettings() {
                        At = FamilyGenerator.KalebWeddingDate,
                        CanBePartnerOtherTime = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma
                    }
                },
                { /* 6 */
                    new SearchSettings() {
                        At = FamilyGenerator.KalebWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Fleur,
                        FamilyGenerator.Heena,
                        FamilyGenerator.Sebastian
                    }
                },
                { /* 7 */
                    new SearchSettings() {
                        At = FamilyGenerator.SebastianWithKarishmaDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Hailie
                    }
                },
                { /* 8 */
                    new SearchSettings() {
                        At = FamilyGenerator.SebastianWithKarishmaDate,
                        CanBePartnerOtherTime = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Sebastian
                    }
                },
                { /* 9 */
                    new SearchSettings() {
                        At = FamilyGenerator.RumaysaWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Hailie
                    }
                },
                { /* 10 */
                    new SearchSettings() {
                        At = FamilyGenerator.RumaysaWeddingDate,
                        CanBePartnerOtherTime = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb
                    }
                },
                { /* 11 */
                    new SearchSettings() {
                        At = FamilyGenerator.HenriettaWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Ashley,
                        FamilyGenerator.Fleur,
                        FamilyGenerator.John
                    }
                },
                { /* 12 */
                    new SearchSettings() {
                        At = FamilyGenerator.HenriettaWeddingDate,
                        CanBePartnerOtherTime = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Fleur,
                    }
                },
                { /* 13 */
                    new SearchSettings() {
                        At = FamilyGenerator.HenriettaWeddingDate,
                        CanBePartnerOtherTime = false,
                        CanBeDead = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Korey,
                        FamilyGenerator.Heena,
                        FamilyGenerator.Klara,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Fleur
                    }
                },
                { /* 14 */
                    new SearchSettings() {
                        At = FamilyGenerator.HenriettaWeddingDate,
                        CanBePartnerOtherTime = true,
                        CanBeDead = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Korey,
                        FamilyGenerator.Heena,
                        FamilyGenerator.Klara,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Fleur,
                        FamilyGenerator.Rumaysa,
                        FamilyGenerator.John,
                        FamilyGenerator.Ashley
                    }
                },
                { /* 15 */
                    new SearchSettings() {
                        CanBePartnerOtherTime = false,
                        CanBeDead = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Fleur,
                        FamilyGenerator.Hailie
                    }
                },
                { /* 16 */
                    new SearchSettings() {
                        CanBePartnerOtherTime = false,
                        CanBeDead = false
                    },
                    new List<Member>() {
                        FamilyGenerator.Korey,
                        FamilyGenerator.Heena,
                        FamilyGenerator.Klara,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Fleur
                    }
                },
                { /* 17 */
                    new SearchSettings() {
                        CanBePartnerOtherTime = true,
                        CanBeDead = true
                    },
                    new List<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Fleur
                    }
                }
            })
            {
                IEnumerable<Member> actualAncestors = fieldFamily.GetRootAncestors(expected.Key);

                Assert.AreEqual(
                    expected.Value.Count(),
                    actualAncestors.Count(),
                    string.Format("Different number of ancestors in case {0}.", i)
                );

                foreach (Member ancestor in expected.Value)
                {
                    Assert.IsTrue(
                        actualAncestors.Any(m => m.Id == ancestor.Id),
                        string.Format(
                            "Missing ancestor '{0}' in case {1}.",
                            ancestor.FullName.Value(expected.Key.At),
                            i
                        )
                    );
                }

                i++;
            }


        }

        public static void CheckFieldFamilyReferences (Family f)
        {
            Assert.AreEqual(
                f.Members[FamilyGenerator.Kaleb.Id].References.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Karishma.Id].References.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Sebastian.Id].References.Partner.Value(FamilyGenerator.SebastianWithKarishmaDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Karishma.Id].References.Partner.Value(FamilyGenerator.SebastianWithKarishmaDate).Id,
                FamilyGenerator.Sebastian.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Rumaysa.Id].References.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Korey.Id].References.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Rumaysa.Id].References.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Klara.Id].References.Parent
                    .References.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Korey.Id].References.Parent
                    .References.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Kian.Id].References.Parent
                    .References.Parent.References.Partner.Value(FamilyGenerator.RumaysaWeddingDate).Id,
                FamilyGenerator.Fleur.Id
            );

            Assert.IsTrue(
                f.Members[FamilyGenerator.Fleur.Id].References.Children.Any(ch => ch.Id == FamilyGenerator.Raja.Id)
            );

            Assert.IsTrue(
                f.Members[FamilyGenerator.Korey.Id].References.Children
                    .Where(ch => ch.Id == FamilyGenerator.Sonya.Id).FirstOrDefault()
                    .References.Children.Any(ch => ch.Id == FamilyGenerator.Marwah.Id)
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Moesha.Id]
                    .References.Children.Where(ch => ch.Id == FamilyGenerator.Kian.Id).FirstOrDefault()
                    .References.Parent
                    .References.Partner.Value(FamilyGenerator.Kian.BirthDate)
                    .References.Partner.Value(FamilyGenerator.Kian.BirthDate)
                    .References.Parent
                    .References.Parent
                    .References.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );
        }

        [TestMethod]
        public void References()
        {
            Family family = FamilyGenerator.GetData();
            CheckFieldFamilyReferences(family);
        }

    }
}