using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class FamilySerializeHelper : SerializeHelper
    {
        public static readonly string StandardExtension = "ftt";

        public FamilySerializeHelper(string fileName) : base(fileName) { }

        public FamilySerializeHelper Save(Family family)
        {
            using (StreamWriter file = File.CreateText(FullFileName))
            {
                new JsonSerializer().Serialize(file, family);
            }
            return this;
        }

        public Family Load()
        {
            return JsonConvert.DeserializeObject<Family>(
                File.ReadAllText(FullFileName)
            ).Repair();
        }
    }
}
