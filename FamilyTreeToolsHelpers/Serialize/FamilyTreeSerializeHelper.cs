using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class FamilyTreeSerializeHelper : SerializeHelper
    {
        public readonly string Extension = "json";

        public FamilyTreeSerializeHelper(string fileName) : base(fileName) { }

        public FamilyTreeSerializeHelper Save(Tree tree)
        {
            File.WriteAllText(GetFullFileName(Extension),
                JsonConvert.SerializeObject(tree)
            );

            return this;
        }
    }
}
