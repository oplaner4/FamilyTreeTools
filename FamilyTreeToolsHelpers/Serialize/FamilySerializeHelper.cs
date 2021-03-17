using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class FamilySerializeHelper : SerializeHelper
    {
        public readonly string Extension = "json";

        public FamilySerializeHelper(string fileName) : base(fileName) { }

        public FamilySerializeHelper Save(Family family)
        {
            File.WriteAllText(GetFullFileName(Extension),
                JsonConvert.SerializeObject(family)
            );

            return this;
        }

        public Family Load()
        {
            return JsonConvert.DeserializeObject<Family>(
                File.ReadAllText(GetFullFileName(Extension))
            ).RepairReferences();
        }
    }
}
