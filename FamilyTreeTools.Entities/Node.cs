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
            Children = new List<Node>();
            Key = key;
            Value = value;
        }

        [JsonProperty]
        public string Value { get; private set; }

        [JsonProperty]
        public Guid Key { get; private set; }

        [JsonProperty]
        public List<Node> Children { get; private set; }

        [JsonProperty]
        public Node Partner { get; private set; }

        public Node AddChild(Node arg)
        {
            Children.Add(arg);
            return this;
        }

        public Node AddPartner(Node arg)
        {
            Partner = arg;
            return this;
        }
    }
}
