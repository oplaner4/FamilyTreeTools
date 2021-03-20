using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Node
    {
        public Node(Guid key, string value)
        {
            Children = new Dictionary<Guid, Node>();
            ChildrenReference = new List<Guid>();
            Key = key;
            Value = value;
        }

        [JsonProperty]
        public string Value { get; private set; }

        [JsonProperty]
        public Guid Key { get; private set; }

        [JsonProperty]
        public Dictionary<Guid, Node> Children { get; private set; }

        [JsonProperty]
        public List<Guid> ChildrenReference { get; private set; }

        [JsonProperty]
        public Node Partner { get; set; }

        [JsonProperty]
        public Guid? PartnerReference { get; set; }

        public Node AddChild(Node arg)
        {
            Children.Add(arg.Key, arg);
            return this;
        }
    }
}
