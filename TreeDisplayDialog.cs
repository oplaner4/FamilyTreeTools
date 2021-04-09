using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;

namespace FamilyTreeTools
{
    public partial class TreeDisplayDialog : Form
    {
        public TreeDisplayDialog(Tree sourceTree)
        {
            InitializeComponent();
            Icon = Resources.favicon;
            SourceTree = sourceTree;

            Initialize();
        }

        private void Initialize()
        {
            TreeGraph = new Graph("graph") {
                Directed = true
            };
            TreeGraph.Attr.AspectRatio = 16 / 9;

            InitializeData(SourceTree.Root, 0);
            TreeViewer = new GViewer()
            {
                Dock = DockStyle.Fill,
                Graph = TreeGraph,
                SaveAsMsaglEnabled = false,
                BackwardEnabled = false,
                ForwardEnabled = false,
                CurrentLayoutMethod = LayoutMethod.UseSettingsOfTheGraph
            };

            SuspendLayout();
            Controls.Add(TreeViewer);
            ResumeLayout();
        }

        public Tree SourceTree { get; private set; }
        private Graph TreeGraph { get; set; }
        private GViewer TreeViewer { get; set; }

        public void InitializeData(Entities.Node node, int level)
        {
            if (node.Partner != null)
            {
                Edge e = TreeGraph.AddEdge(node.Key.ToString(), node.Partner.Key.ToString());
                e.Attr.Color = Color.DarkGreen;
                InitializeData(node.Partner, level);
            }

            if (node.PartnerReference != null)
            {
                Edge e = TreeGraph.AddEdge(node.Key.ToString(), node.PartnerReference.Value.ToString());
                e.Attr.Color = Color.DarkGreen;
            }

            foreach (Entities.Node childNode in node.Children.Values)
            {
                Edge e = TreeGraph.AddEdge(node.Key.ToString(), childNode.Key.ToString());
                e.Attr.Color = Color.SaddleBrown;
                InitializeData(childNode, level + 1);
            }

            if (node.CommonChildren != null)
            {
                foreach (Guid commonChildId in node.CommonChildren)
                {
                    Edge e = TreeGraph.AddEdge(node.Key.ToString(), commonChildId.ToString());
                    e.Attr.Color = Color.SaddleBrown;
                }
            }

            Microsoft.Msagl.Drawing.Node createdNode = TreeGraph.FindNode(node.Key.ToString());
            if (createdNode != null)
            {
                createdNode.LabelText = node.Value;
                createdNode.Attr.FillColor = node.Key == Guid.Empty ? Color.SaddleBrown : Color.SeaGreen;
                createdNode.Attr.Shape = Shape.Ellipse;
                createdNode.Label.FontColor = Color.White;
            }
        }
    }
}
