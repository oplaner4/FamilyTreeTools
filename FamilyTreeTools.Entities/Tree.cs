using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Tree
    {
        public Tree(Family family, DateTime dateAt)
        {
            DateAt = dateAt;
            Family = family;

            Root = new Node(Guid.Empty, Family.Name);
        }

        private void AddChildrenWithPartner(Node node, IEnumerable<Member> children)
        {
            Member partner = null;
            Node partnerNode = null;
            bool married = false;

            if (Family.Members.ContainsKey(node.Key))
            {
                partner = Family.Members[node.Key].PartnerReference.ValueAt(DateAt);
                if (partner != null)
                {
                    partnerNode = new Node(
                        partner.Id,
                        partner.FullName.ValueAt(DateAt)
                    );

                    married = partner.WasMarried(DateAt);
                }
            }

            foreach (Member child in children)
            {
                Node childNode = new Node(child.Id, child.FullName.ValueAt(DateAt));
                node.AddChild(childNode);

                if (married)
                {
                    partnerNode.AddChild(childNode);
                }
            }

            if (partner != null && !AddedPartners.Contains(partner.Id))
            {
                AddedPartners.Add(partner.Id);
                node.AddPartner(partnerNode);
            }
        }

        public Tree Build()
        {
            AddedPartners = new HashSet<Guid>();

            AddChildrenWithPartner(
                Root,
                Family.GetOldestAncestors(DateAt, CanBeDead)
            );

            BuildRecurrent(Root);
            return this;
        }

        private void BuildRecurrent(Node actual)
        {
            foreach (Node child in actual.Children)
            {
                AddChildrenWithPartner(
                    child,
                    Family.Members[child.Key].ChildrenReference.Where(
                        ch => ch.IsBorn(DateAt, CanBeDead)
                    )
                );

                BuildRecurrent(child);
            }
        }

        [JsonProperty]
        public bool CanBeDead { get; set; }

        [JsonProperty]
        public DateTime DateAt { get; private set; }

        [JsonProperty]
        public Node Root { get; private set; }

        private Family Family { get; set; }

        private HashSet<Guid> AddedPartners { get; set; }
    }
}
