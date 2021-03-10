using System;
using System.Collections.Generic;
using FamilyTreeTools.Entities;

namespace FamilyTreeTools.Helpers.Generators
{
    public static class DataGenerator
    {
        public static Dictionary<Guid, FamilyMemberHistory> GetData()
        {
            return new Dictionary<Guid, FamilyMemberHistory>() {
                {
                    Kaleb.Id,
                    KalebHistory
                },
                {
                    Karishma.Id,
                    KarishmaHistory
                },
                {
                    Sebastian.Id,
                    SebastianHistory
                },
                {
                    Korey.Id,
                    KoreyHistory
                },
                {
                    Heena.Id,
                    HeenaHistory
                },
                {
                    Fleur.Id,
                    FleurHistory
                },
                {
                    Rumaysa.Id,
                    RumaysaHistory
                }
            };
        }

        public static readonly FamilyMember Kaleb = (FamilyMember)new FamilyMember("Kaleb Field", new DateTime(1939, 1, 5)).SetDeathDate(new DateTime(2010, 12, 4));
        public static readonly FamilyMember Karishma = (FamilyMember)new FamilyMember("Karishma Smith", new DateTime(1940, 1, 1)).SetDeathDate(new DateTime(2011, 11, 8));

        public static readonly FamilyMember Rumaysa = new FamilyMember("Rumaysa Field", new DateTime(1964, 3, 4));
        public static readonly FamilyMember Korey = new FamilyMember("Korey Field", new DateTime(1962, 8, 7));
        public static readonly FamilyMember Klara = new FamilyMember("Klara Field", new DateTime(1967, 2, 3));


        public static readonly DateTime KalebWeddingDate = new DateTime(1965, 11, 3);

        public static FamilyMemberHistory KalebHistory = new FamilyMemberHistory(Kaleb)
            .AddChange(m => m
                .GotMarried(Karishma)
                .AddChild(Korey)
                .AddChild(Rumaysa)
                .AddChild(Klara),
                KalebWeddingDate
            )
            .AddChange(m => m.GotUnmarried(), new DateTime(1993, 11, 3));

        public static FamilyMember Sebastian = (FamilyMember)new FamilyMember("Sebastian Mcdougall", new DateTime(1946, 2, 2)).SetDeathDate(new DateTime(2020, 4, 3));
        public static FamilyMemberHistory SebastianHistory = new FamilyMemberHistory(Sebastian);

        public static FamilyMemberHistory KarishmaHistory = new FamilyMemberHistory(Karishma)
            .AddChange(m => m.SetFullName("Karishma Field"), KalebWeddingDate)
            .AddChange(m => m.SetFullName("Karishma Smith"), new DateTime(1993, 11, 3))
            .AddChange(m => m.SetPartner(Sebastian), new DateTime(1994, 3, 4));



        public static FamilyMember Heena = new FamilyMember("Heena Mohamed", new DateTime(1964, 4, 2));

        public static FamilyMember Sonya = new FamilyMember("Sonya Field", new DateTime(1990, 9, 8));
        public static FamilyMember Henrietta = new FamilyMember("Henrietta Field", new DateTime(1992, 6, 10));


        public static readonly DateTime KoreyWeddingDate = new DateTime(1986, 10, 8);

        public static FamilyMemberHistory KoreyHistory = new FamilyMemberHistory(Korey)
            .AddChange(m => m
                .GotMarried(Heena)
                .AddChild(Sonya)
                .AddChild(Henrietta),
                KoreyWeddingDate
            );

        public static FamilyMemberHistory HeenaHistory = new FamilyMemberHistory(Heena)
            .AddChange(m => m.SetFullName("Heena Smith"), KoreyWeddingDate);


        public static readonly DateTime RumaysaWeddingDate = new DateTime(1987, 7, 6);

        public static FamilyMember Fleur = new FamilyMember("Fleur Garrison", new DateTime(1963, 3, 4));

        public static FamilyMember Marian = new FamilyMember("Marian Garrison", new DateTime(1990, 2, 6));
        public static FamilyMember Moesha = new FamilyMember("Moesha Garrison", new DateTime(1993, 12, 6));

        public static FamilyMember Hailie = new FamilyMember("Hailie Leach", new DateTime(1972, 4, 1));
        public static FamilyMember Ismaeel = new FamilyMember("Ismaeel Powell", new DateTime(2004, 7, 3));


        public static FamilyMemberHistory RumaysaHistory = new FamilyMemberHistory(Rumaysa)
            .AddChange(m => m
                .GotMarried(Fleur)
                .AddChild(Marian)
                .AddChild(Moesha)
                .SetFullName("Heena Garrison"),
                RumaysaWeddingDate
            );


        public static FamilyMemberHistory FleurHistory = new FamilyMemberHistory(Fleur)
            .AddChange(m => m
                .GotUnmarried().SetPartner(Hailie).AddChild(Ismaeel),
                new DateTime(2003, 4, 7)
            );



        //public static FamilyMember Avi = new FamilyMember("Avi Hebert",                new DateTime(1946, 11, 3));
        //public static FamilyMember Raja = new FamilyMember("Raja Hahn",                new DateTime(1978, 9,  8));
        //public static FamilyMember Kamran = new FamilyMember("Kamran Smith",             new DateTime(1994, 4,  11));
        //public static FamilyMember Ahsan = new FamilyMember("Ahsan Smith",             new DateTime(2001, 3,  4));
        //public static FamilyMember John = new FamilyMember("John Smith",               new DateTime(2008, 7,  1));
        //public static FamilyMember Marwah = new FamilyMember("Marwah Alcock",          new DateTime(2014, 12, 4));
        //public static FamilyMember Kian = new FamilyMember("Kian Lister",              new DateTime(1993, 8,  7));
        //public static FamilyMember Jun = new FamilyMember("Jun Dickens",               new DateTime(2008, 10, 5));

    }
}
