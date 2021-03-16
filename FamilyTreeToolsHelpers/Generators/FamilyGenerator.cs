using FamilyTreeTools.Entities;
using System;

namespace FamilyTreeTools.Utilities.Generators
{
    public static class FamilyGenerator
    {
        public static Family GetData()
        {
            return new Family("Field family")
                .AddMember(Kaleb).AddMember(Karishma)
                .AddMember(Sebastian)
                .AddMember(Klara).AddMember(Rumaysa).AddMember(Korey)
                .AddMember(Heena)
                .AddMember(Fleur)
                .AddMember(Hailie)
                .AddMember(Jun)
                .AddMember(Ismaeel).AddMember(Raja)
                .AddMember(Moesha).AddMember(Marian)
                .AddMember(John)
                .AddMember(Henrietta).AddMember(Sonya)
                .AddMember(Kian)
                .AddMember(Ashley)
                .AddMember(Marwah)
                .AddMember(Ahsan);
        }

        public static readonly DateTime RumaysaWeddingDate = new DateTime(1989, 7, 22);

        public static readonly DateTime KoreyWeddingDate = new DateTime(1986, 10, 18);

        public static readonly DateTime KalebWeddingDate = new DateTime(1965, 11, 3);

        public static readonly DateTime HenriettaWeddingDate = new DateTime(2015, 12, 9);

        public static readonly DateTime SebastianWithKarishmaDate = new DateTime(1994, 3, 4);


        // Sonya's children

        public static FamilyMember Marwah = new FamilyMember("Marwah Field", new DateTime(2017, 12, 4));


        // Moesha's children

        public static FamilyMember Kian = new FamilyMember("Kian Garrison", new DateTime(2020, 8, 7));


        // Henrietta's partner

        public static FamilyMember Ahsan = new FamilyMember("Ahsan Carty", new DateTime(2001, 3, 19));


        // Korey's children

        public static FamilyMember Sonya = new FamilyMember("Sonya Field", new DateTime(1990, 9, 8))
            .HadChild(Marwah);

        public static FamilyMember Henrietta = new FamilyMember("Henrietta Field", new DateTime(1992, 6, 10))
            .WithPartner(Ahsan, new DateTime(2013, 1, 7))
            .GotMarried(HenriettaWeddingDate)
            .ChangedFullName("Henrietta Carty", HenriettaWeddingDate);


        // Moesha's partner

        public static FamilyMember John = new FamilyMember("John Carver", new DateTime(2008, 7, 1));

        // Remaysa's children

        public static FamilyMember Marian = new FamilyMember("Marian Garrison", new DateTime(1990, 2, 6));

        public static FamilyMember Moesha = new FamilyMember("Moesha Garrison", new DateTime(1993, 12, 29))
            .WithPartner(John, new DateTime(2019, 11, 1))
            .HadChild(Kian);


        // Ismaeel's partner

        public static FamilyMember Ashley = new FamilyMember("Ashley Hebert", new DateTime(2001, 11, 3));

        // Fleur's children

        public static FamilyMember Ismaeel = new FamilyMember("Ismaeel Garrison", new DateTime(2002, 7, 20))
            .WithPartner(Ashley, new DateTime(2021, 1, 2));

        public static FamilyMember Raja = (FamilyMember)new FamilyMember("Raja Garrison", new DateTime(2003, 9, 8)).Died(new DateTime(2004, 4, 11));


        // Klara's children

        public static FamilyMember Jun = new FamilyMember("Jun Dickens", new DateTime(1990, 10, 26));


        // Fleur's next partner

        public static FamilyMember Hailie = new FamilyMember("Hailie Leach", new DateTime(1972, 4, 13));


        // Korey, Rumaysa partners

        public static FamilyMember Fleur = new FamilyMember("Fleur Garrison", new DateTime(1963, 3, 4))
            .WithPartner(Hailie, new DateTime(2000, 6, 1))
            .HadChild(Ismaeel)
            .HadChild(Raja);

        public static FamilyMember Heena = new FamilyMember("Heena Mohamed", new DateTime(1964, 4, 2))
            .ChangedFullName("Heena Smith", KoreyWeddingDate);


        // Kaleb + Karishma's children

        public static readonly FamilyMember Korey = new FamilyMember("Korey Field", new DateTime(1962, 8, 7))
                .GotMarried(KoreyWeddingDate, Heena)
                .HadChild(Sonya)
                .HadChild(Henrietta);

        public static readonly FamilyMember Rumaysa = new FamilyMember("Rumaysa Field", new DateTime(1964, 3, 14))
            .GotMarried(RumaysaWeddingDate, Fleur)
            .ChangedFullName("Rumaysa Garrison", RumaysaWeddingDate)
            .HadChild(Marian)
            .HadChild(Moesha)
            .GotUnmarried(new DateTime(1999, 4, 7));

        public static readonly FamilyMember Klara = new FamilyMember("Klara Field", new DateTime(1967, 2, 3))
            .HadChild(Jun);


        // Karishma's next partner

        public static FamilyMember Sebastian = (FamilyMember)new FamilyMember("Sebastian Mcdougall", new DateTime(1946, 2, 2)).Died(new DateTime(2020, 4, 3));


        // Oldest ancestors -- Kaleb + Karishma

        public static readonly FamilyMember Karishma = ((FamilyMember)new FamilyMember("Karishma Smith", new DateTime(1940, 1, 1)).Died(new DateTime(2011, 11, 8)))
            .ChangedFullName("Karishma Field", KalebWeddingDate)
            .ChangedFullName("Karishma Smith", new DateTime(1993, 11, 3))
            .WithPartner(Sebastian, SebastianWithKarishmaDate);

        public static readonly FamilyMember Kaleb = ((FamilyMember)new FamilyMember("Kaleb Field", new DateTime(1939, 1, 5)).Died(new DateTime(2010, 12, 19)))
            .GotMarried(KalebWeddingDate, Karishma)
            .HadChild(Korey)
            .HadChild(Rumaysa)
            .HadChild(Klara)
            .GotUnmarried(new DateTime(1993, 11, 30));
    }
}
