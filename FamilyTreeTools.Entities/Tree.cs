using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Tree
    {
        public Tree(Family family, SearchSettings settings = null)
        {
            Settings = settings ?? new SearchSettings();
            Family = family;
        }

        private IEnumerable<Member> UseChildren(Node node)
        {
            if (node.Key == Root.Key)
            {
                return Family.GetRootAncestors(Settings);
            }

            return Family.Members[node.Key].References.GetChildrenWithSpouse(Settings);
        }

        private Tree UpdatePartner(Node node)
        {
            Member partner = Family.Members[node.Key].References.Partner.Value(Settings.At);

            if (partner != null)
            {
                if (AddedMembers.Contains(partner.Id))
                {
                    node.PartnerReference = partner.Id;
                }
                else {
                    node.Partner = new Node(
                        partner.Id,
                        partner.FullName.Value(Settings.At)
                    );

                    AddedMembers.Add(partner.Id);

                    UpdateChildren(node.Partner).BuildRecurrent(node.Partner);
                }
            }

            return this;
        }

        private Tree UpdateChildren(Node node)
        {
            foreach (Member child in UseChildren(node)) {
                Node childNode = new Node(child.Id, child.FullName.Value(Settings.At));
                node.AddChild(childNode);
            }

            return this;
        }

        public Tree Build()
        {
            AddedMembers = new HashSet<Guid>();
            Root = new Node(Guid.Empty, Family.Name);

            UpdateChildren(Root);
            AddedMembers.Add(Root.Key);
            BuildRecurrent(Root);
            return this;
        }

        private Tree BuildRecurrent(Node actual)
        {
            foreach (Node node in actual.Children.Values)
            {
                if (!AddedMembers.Contains(node.Key))
                {
                    UpdatePartner(node).UpdateChildren(node).BuildRecurrent(node);
                }
            }

            return this;
        }

        [JsonProperty]
        public SearchSettings Settings { get; set; }

        [JsonProperty]
        public Node Root { get; private set; }

        private Family Family { get; set; }

        private HashSet<Guid> AddedMembers { get; set; }
    }
}
