using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class TreeSerializeHelper : SerializeHelper
    {
        public static readonly string StandardExtension = "json";

        public TreeSerializeHelper(string fileName) : base(fileName) { }

        public TreeSerializeHelper Save(Tree tree)
        {
            using (StreamWriter file = File.CreateText(FullFileName))
            {
                new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = "MM/dd/yyyy H:mm:ss",
                    Formatting = Formatting.Indented
                }.Serialize(file, tree);
            }

            return this;
        }
    }
}
