using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    public class TreeNode
    {
        public TreeNode(Guid key, string value)
        {
            Children = new List<TreeNode>();
            Key = key;
            Value = value;
        }

        [JsonProperty]
        public string Value { get; private set; }

        public Guid Key { get; private set; }


        public List<TreeNode> Children { get; private set; }
    }
}
