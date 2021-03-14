using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Helpers.Serialize
{
    public class FamilySerializeHelper
    {
        public FamilySerializeHelper(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }


        public FamilySerializeHelper Save(Family family)
        {
            File.WriteAllText(FileName,
                JsonConvert.SerializeObject(family)
            );

            return this;
        }

        public Family Load ()
        {
            return JsonConvert.DeserializeObject<Family>(File.ReadAllText(FileName));
        }
    }
}
