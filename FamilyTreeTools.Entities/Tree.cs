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

        private Tree UpdatePartner(Node node)
        {
            Member partner = Family.Members[node.Key].Refs.Partner.Value(Settings.At);

            if (partner != null && Seen.Add(partner.Id))
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
                if (Seen.Contains(child.Id))
                {
                    if (Root.Key != actual.Key)
                    {
                        actual.AddCommonChild(child.Id);
                    }
                }
                else
                {
                    Node childNode = new Node(
                        child.Id, child.FullName.Value(Settings.At)
                    );
                    actual.AddChild(childNode);
                    Seen.Add(child.Id);
                    
                    if (Settings.CanBeFromFartherGeneration)
                    {
                        BuildRecurrent(childNode).UpdatePartner(childNode);
                    }
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
