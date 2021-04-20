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
            bool canBeFromFartherGeneration = Settings.CanBeFromFartherGeneration;
            Settings.CanBeFromFartherGeneration = false;

            IEnumerable<Member> result = node.Key == Root.Key ?
                Family.GetRootAncestors(Settings)
                :
                Family.Members[node.Key].Refs.GetDescendants(Settings);

            Settings.CanBeFromFartherGeneration = canBeFromFartherGeneration;

            return result;
        }

        private Tree BuildPartner(Node node, bool fartherChild)
        {
            if (Family.Members[node.Key].Refs.TryGetPartner(
                out Member partner, Settings.At, Settings.CanBeDead
            )) {
                if (fartherChild && Seen.Add(partner.Id))
                {
                    node.Partner = new Node(
                        partner.Id,
                        partner.FullName.Value(Settings.At)
                    )
                    {
                        PartnerReference = node.Key
                    };

                    BuildRecurrent(node.Partner);
                }
                else
                {
                    node.PartnerReference = partner.Id;
                }
            }

            return this;
        }

        public Tree Build()
        {
            Seen = new HashSet<Guid>();
            Root = new Node(Guid.Empty, Family.Name);
            BuildRecurrent(Root);
            return this;
        }

        private Tree BuildRecurrent(Node actual)
        {
            foreach (Member child in UseChildren(actual))
            {
                if (Seen.Add(child.Id))
                {
                    Node childNode = new Node(
                        child.Id, child.FullName.Value(Settings.At)
                    );
                    actual.AddChild(childNode);

                    if (Settings.CanBeFromFartherGeneration)
                    {
                        BuildRecurrent(childNode).BuildPartner(
                            childNode, actual.Key != Root.Key
                        );
                    }
                }
                else
                {
                    actual.AddChildReference(child.Id);
                }
            }

            return this;
        }

        [JsonProperty]
        public SearchSettings Settings { get; private set; }

        [JsonProperty]
        public Node Root { get; private set; }

        private Family Family { get; set; }

        private HashSet<Guid> Seen { get; set; }
    }
}
