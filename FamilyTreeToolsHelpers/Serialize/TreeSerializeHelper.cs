using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public class TreeSerializeHelper : SerializeHelper
    {
        public readonly string Extension = "json";

        public TreeSerializeHelper(string fileName) : base(fileName) { }

        public TreeSerializeHelper Save(TreeNode root)
        {
            File.WriteAllText(GetFullFileName(Extension),
                JsonConvert.SerializeObject(root)
            );

            return this;
        }
    }
}
