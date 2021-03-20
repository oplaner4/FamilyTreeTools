using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class FamilySerializeHelper : SerializeHelper
    {
        public FamilySerializeHelper(string fileName) : base(fileName, "ftt") { }

        public FamilySerializeHelper Save(Family family)
        {
            File.WriteAllText(FullFileName,
                JsonConvert.SerializeObject(family)
            );

            return this;
        }

        public Family Load()
        {
            return JsonConvert.DeserializeObject<Family>(
                File.ReadAllText(FullFileName)
            ).RepairReferences();
        }
    }
}
