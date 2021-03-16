using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeTools.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Family
    {
        [JsonConstructor]
        public Family()
        { }

        public Family(string name, Dictionary<Guid, FamilyMember> members = null)
        {
            Members = members ?? new Dictionary<Guid, FamilyMember>();
            Name = name;
        }

        private string _Name { get; set; }

        public string Name {
            get {
                return _Name;
            }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Trying to set no name of the family.");
                }

                _Name = value;
            }
        }

        private Dictionary<Guid, FamilyMember> _Members { get; set; }

        [JsonProperty]
        public Dictionary<Guid, FamilyMember> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value ?? throw new Exception("Trying to set null members.");
            }
        }

        public Family AddMember(FamilyMember arg)
        {
            if (arg == null)
            {
                throw new Exception("Trying to add a null member.");
            }

            Members.Add(arg.Id, arg);
            return this;
        }

        public List<FamilyMember> GetBornChildrenOf(Guid member, DateTime at)
        {
            List<FamilyMember> result = new List<FamilyMember>();

            foreach (Guid id in Members[member].Children)
            {
                FamilyMember child = Members[id];
                if (child.IsBorn(at))
                {
                    result.Add(child);
                }
            }

            return result;
        }

        public List<FamilyMember> GetOldestAncestors(DateTime at)
        {
            return Members.Values.Where(m => !m.Parent.HasValue && m.IsBorn(at)).ToList();
        }

        public Family RepairAfterSerialization()
        {
            foreach (FamilyMember member in Members.Values)
            {
                member.RepairAfterSerialization(id => Members[id]);
            }

            return this;
        }


        private void SetTreeNodeChildren(TreeNode node, List<FamilyMember> children, DateTime at)
        {
            foreach (FamilyMember ancestor in children)
            {
                node.Children.Add(
                    new TreeNode(
                        ancestor.Id, ancestor.FullName.ValueAt(at)
                    )
                );
            }
        }

        private void BuidTreeRecurrent(DateTime at, TreeNode actual)
        {
            foreach (TreeNode child in actual.Children)
            {
                SetTreeNodeChildren(child, GetBornChildrenOf(child.Key, at), at);

                foreach (FamilyMember member in Members[child.Key].ChildrenReference.Where(ch => ch.IsBorn(at)))
                {
                    child.Children.Add(
                        new TreeNode(
                            member.Id, member.FullName.ValueAt(at)
                        )
                    );
                }
                BuidTreeRecurrent(at, child);
            }
        }

        public TreeNode BuidTree(DateTime at)
        {
            TreeNode root = new TreeNode(Guid.Empty, Name);

            foreach (FamilyMember ancestor in GetOldestAncestors(at))
            {
                root.Children.Add(
                    new TreeNode(
                        ancestor.Id, ancestor.FullName.ValueAt(at)
                    )
                );
            }

            BuidTreeRecurrent(at, root);
            return root;
        }
    }
}
