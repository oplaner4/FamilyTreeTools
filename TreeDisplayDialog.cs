using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Linq;

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
        private void InitializeGraph()
        {
            TreeGraph = new Graph("tree chart")
            {
                Directed = true
            };
            TreeGraph.Attr.AspectRatio = 16 / 10;

            Microsoft.Msagl.Drawing.Node root = TreeGraph.AddNode(SourceTree.Root.Key.ToString());
            InitializeData(SourceTree.Root);
            SetNode(SourceTree.Root);

            root.Attr.FillColor = Color.SaddleBrown;
            root.Attr.Shape = Shape.Box;
            root.Attr.LabelMargin = 10;
        }

        private void Initialize()
        {
            InitializeGraph();

            TreeViewer = new GViewer()
            {
                Dock = DockStyle.Fill,
                Graph = TreeGraph,
                SaveAsMsaglEnabled = false,
                BackwardEnabled = false,
                ForwardEnabled = false,
                CurrentLayoutMethod = LayoutMethod.UseSettingsOfTheGraph
            };

            Controls.Add(TreeViewer);
            Size = TreeViewer.Size;
        }

        private Edge CreateEdge(Guid source, Guid target, string labelText)
        {
            Edge result = TreeGraph.AddEdge(source.ToString(), string.Empty, target.ToString());
            result.LabelText = WithLabelsCheckbox.Checked ? labelText : string.Empty;
            result.Label.FontSize = 8;
            return result;
        }

        public Tree SourceTree { get; private set; }
        private Graph TreeGraph { get; set; }
        private GViewer TreeViewer { get; set; }

        public void SetNode(Entities.Node node)
        {
            Microsoft.Msagl.Drawing.Node createdNode = TreeGraph.FindNode(node.Key.ToString());
            createdNode.LabelText = node.Value;
            createdNode.Label.FontColor = Color.White;

            if (node.PartnerReference != null && node.Children.Count() == 0)
            {
                createdNode.Attr.FillColor = Color.SeaGreen;
            }
            else
            {
                createdNode.Attr.FillColor = Color.ForestGreen;
            }

            createdNode.Attr.Shape = Shape.Ellipse;
        } 

        public void InitializeData(Entities.Node node)
        {
            InitializeDataPartners(node);
            InitializeDataChildren(node);
        }

        private void InitializeDataChildren(Entities.Node node)
        {
            foreach (Entities.Node childNode in node.Children.Values)
            {
                Edge e = CreateEdge(
                    node.Key, childNode.Key,
                    node.Key == SourceTree.Root.Key ? string.Empty : "child"
                );
                e.Attr.Color = Color.SaddleBrown;
                e.Label.FontColor = Color.SaddleBrown;
                e.Attr.ArrowheadAtTarget = node.Key == SourceTree.Root.Key ? ArrowStyle.None : ArrowStyle.Generalization;
                
                InitializeData(childNode);
                SetNode(childNode);
            }

            if (node.CommonChildren != null)
            {
                foreach (Guid commonChildId in node.CommonChildren)
                {
                    Edge e = CreateEdge(
                        node.Key, commonChildId, "child"
                    );
                    e.Attr.Color = Color.SandyBrown;
                    e.Label.FontColor = Color.SandyBrown;
                    e.Attr.ArrowheadAtTarget = ArrowStyle.Generalization;
                }
            }
        }

        private void InitializeDataPartners(Entities.Node node)
        {
            string labelText = "partner";
            Color useColor = Color.DarkGreen;

            if (node.Partner != null)
            {
                Edge e = CreateEdge(node.Key, node.Partner.Key, labelText);
                e.Attr.Color = useColor;
                e.Label.FontColor = e.Attr.Color;

                InitializeData(node.Partner);
                SetNode(node.Partner);
            }

            if (node.PartnerReference != null)
            {
                Edge e = CreateEdge(node.Key, node.PartnerReference.Value, labelText);
                e.Attr.Color = useColor;
                e.Label.FontColor = e.Attr.Color;
            }
        }

        private void UpdateGraph()
        {
            InitializeGraph();
            TreeViewer.Graph = TreeGraph;
        }

        private void WithLabelsCheckboxOnChange(object sender, EventArgs e)
        {
            UpdateGraph();
        }
    }
}
