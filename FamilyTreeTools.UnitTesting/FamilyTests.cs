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
            foreach (KeyValuePair<SearchSettings, HashSet<Member>> expected in new Dictionary<SearchSettings, HashSet<Member>>() {
                { /* 1 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate.AddYears(-10),
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {}
                },
                { /* 2 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate,
                        CanBePartnerOtherTime = false
                    },
                    new HashSet<Member>() {}
                },
                { /* 3 */
                    new SearchSettings() {
                        At = FamilyGenerator.Kaleb.BirthDate,
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {
                        FamilyGenerator.Kaleb
                    }
                },
                { /* 4 */
                    new SearchSettings() {
                        At = FamilyGenerator.Karishma.BirthDate,
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma
                    }
                },
                { /* 5 */
                    new SearchSettings() {
                        At = FamilyGenerator.KalebWeddingDate,
                        CanBePartnerOtherTime = false
                    },
                    new HashSet<Member>() {
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Karishma
                    }
                },
                { /* 6 */
                    new SearchSettings() {
                        At = FamilyGenerator.KalebWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
                        FamilyGenerator.Sebastian,
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb,
                        FamilyGenerator.Hailie,
                        FamilyGenerator.Ahsan
                    }
                },
                { /* 8 */
                    new SearchSettings() {
                        At = FamilyGenerator.SebastianWithKarishmaDate,
                        CanBePartnerOtherTime = false
                    },
                    new HashSet<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Sebastian
                    }
                },
                { /* 9 */
                    new SearchSettings() {
                        At = FamilyGenerator.RumaysaWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
                        FamilyGenerator.Karishma,
                        FamilyGenerator.Kaleb
                    }
                },
                { /* 11 */
                    new SearchSettings() {
                        At = FamilyGenerator.HenriettaWeddingDate,
                        CanBePartnerOtherTime = true
                    },
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                    new HashSet<Member>() {
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
                f.Members[FamilyGenerator.Kaleb.Id].Refs.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Karishma.Id].Refs.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Sebastian.Id].Refs.Partner.Value(FamilyGenerator.SebastianWithKarishmaDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Karishma.Id].Refs.Partner.Value(FamilyGenerator.SebastianWithKarishmaDate).Id,
                FamilyGenerator.Sebastian.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Rumaysa.Id].Refs.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Korey.Id].Refs.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Rumaysa.Id].Refs.Parent.Id,
                FamilyGenerator.Kaleb.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Klara.Id].Refs.Parent
                    .Refs.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Korey.Id].Refs.Parent
                    .Refs.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Kian.Id].Refs.Parent
                    .Refs.Parent.Refs.Partner.Value(FamilyGenerator.RumaysaWeddingDate).Id,
                FamilyGenerator.Fleur.Id
            );

            Assert.IsTrue(
                f.Members[FamilyGenerator.Fleur.Id].Refs.Children.ContainsKey(FamilyGenerator.Raja.Id)
            );

            Assert.IsTrue(
                f.Members[FamilyGenerator.Korey.Id].Refs.Children[FamilyGenerator.Sonya.Id]
                    .Refs.Children.ContainsKey(FamilyGenerator.Marwah.Id)
            );

            Assert.AreEqual(
                f.Members[FamilyGenerator.Moesha.Id]
                    .Refs.Children[FamilyGenerator.Kian.Id]
                    .Refs.Parent
                    .Refs.Partner.Value(FamilyGenerator.Kian.BirthDate)
                    .Refs.Partner.Value(FamilyGenerator.Kian.BirthDate)
                    .Refs.Parent
                    .Refs.Parent
                    .Refs.Partner.Value(FamilyGenerator.KalebWeddingDate).Id,
                FamilyGenerator.Karishma.Id
            );
        }

        [TestMethod]
        public void References()
        {
            Family fieldFamily = FamilyGenerator.GetData();

            FamilyGenerator.Rumaysa.Refs.RemoveChild(FamilyGenerator.Moesha);
            Assert.AreEqual(1, FamilyGenerator.Rumaysa.Refs.Children.Count());
            FamilyGenerator.Rumaysa.HadChild(FamilyGenerator.Moesha);
            Assert.AreEqual(2, FamilyGenerator.Rumaysa.Refs.Children.Count());

            CheckFieldFamilyReferences(fieldFamily);
        }

    }
}