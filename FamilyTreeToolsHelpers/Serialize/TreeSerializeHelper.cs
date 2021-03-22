using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class TreeSerializeHelper : SerializeHelper
    {
        public TreeSerializeHelper(string fileName) : base(fileName, "json") { }

        public TreeSerializeHelper Save(Tree tree)
        {
            File.WriteAllText(FullFileName,
                JsonConvert.SerializeObject(tree, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = "MM/dd/yyyy H:mm:ss",
                })
            );

            return this;
        }
    }
}
