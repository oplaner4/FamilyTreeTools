﻿using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Linq;
using DrawingNode = Microsoft.Msagl.Drawing.Node;
using Microsoft.Msagl.Core.Geometry.Curves;

namespace FamilyTreeTools
{
    public partial class TreeDisplayDialog : Form
    {
        public static readonly int ControlPanelHeight = 35;

        public DateTime AnimationStartDateTime { get; private set; }

        public DateTime AnimationEndDateTime { get; private set; }

        private Timer GraphUpdateTimer { get; set; }

        public TreeDisplayDialog(Family sourceFamily, SearchSettings sourceSettings, bool animation = false)
        {
            InitializeComponent();
            Icon = Resources.favicon;

            SourceFamily = sourceFamily;
            SourceSettings = sourceSettings;

            Initialize();

            if (animation)
            {
                SourceSettings = new SearchSettings()
                {
                    CanBeDead = sourceSettings.CanBeDead,
                    CanBeFromFartherGeneration = sourceSettings.CanBeFromFartherGeneration,
                    CanBeIllegitimateRelative = sourceSettings.CanBeIllegitimateRelative,
                    CanBePartnerOtherTime = sourceSettings.CanBePartnerOtherTime,
                    At = sourceSettings.At,
                };

                GraphUpdateTimer = new Timer();
                GraphUpdateTimer.Tick += new EventHandler(OnGraphUpdateIntervalElapsed);
                GraphUpdateTimer.Interval = (int)AnimationInterval.Value * 1000;

                AnimationStartDateTime = sourceSettings.At;
                AnimationEndDateTime = DateTime.Now;

                AnimationRunningValue.Checked = true;
            }
        }

        private void OnGraphUpdateIntervalElapsed(object sender, EventArgs e)
        {
            DateTime newAt = SourceSettings.At.Add(new TimeSpan((int)AnimationAddDays.Value, 0, 0, 0));

            if (newAt > AnimationEndDateTime)
            {
                SourceSettings.At = AnimationStartDateTime;
                AnimationRunningValue.Checked = false;
            }
            else
            {
                SourceSettings.At = newAt;
            }

            UpdateUI();
            UpdateGraph();
            UpdateEventsListBox();
        }

        private void InitializeGraph()
        {
            SourceTree = new Tree(SourceFamily, SourceSettings).Build();

            TreeGraph = new Graph("tree chart")
            {
                Directed = true,
                
            };

            DrawingNode root = TreeGraph.AddNode(SourceTree.Root.Key.ToString());
            TreeGraph.Attr.LayerDirection = LayerDirection.TB;

            InitializeData(SourceTree.Root);

            root.Attr.FillColor = Color.SaddleBrown;
            root.Attr.Shape = Shape.Box;
            root.Attr.LabelMargin = 10;
        }

        private void UpdateEventsListBox()
        {
            EventsListBox.Items.Clear();

            foreach (Member m in SourceFamily.Members.Values)
            {
                if (m.BirthDate.Date == SourceSettings.At.Date)
                {
                    EventsListBox.Items.Add(string.Format("{0} was born.", m));
                }
                else if (m.Status.Changes.ContainsKey(SourceSettings.At.Date))
                {
                    if (m.Refs.TryGetPartner(
                        out Member value, SourceSettings.At, SourceSettings.CanBeDead)
                    )
                    {
                        EventsListBox.Items.Add(string.Format("{0} got married with {1}.", m, value));
                    }
                    else
                    {
                        EventsListBox.Items.Add(string.Format("{0} got unmarried.", m));
                    }

                }

                if (m.DeathDate.HasValue && m.DeathDate.Value.Date == SourceSettings.At.Date)
                {
                    EventsListBox.Items.Add(string.Format("{0} died.", m));
                }
            }

            if (EventsListBox.Items.Count == 0)
            {
                EventsListBox.Items.Add("No events happened that day.");
            }
        }

        private void UpdateUI()
        {
            AtLabelValue.Text = SourceSettings.At.ToString("dd/MM/yyyy");
        }

        private void Initialize()
        {
            InitializeGraph();

            TreeViewer = new GViewer()
            {
                Dock = DockStyle.Fill,
                Graph = TreeGraph,
                CurrentLayoutMethod = LayoutMethod.UseSettingsOfTheGraph,
                Padding = new Padding(0, ControlPanelHeight, 0, EventsListBox.Height),
            };

            Controls.Add(TreeViewer);

            UpdateUI();
            UpdateEventsListBox();
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
        public Family SourceFamily { get; private set; }
        public SearchSettings SourceSettings { get; private set; }

        public void InitializeNode(Entities.Node node)
        {
            DrawingNode createdNode = TreeGraph.FindNode(node.Key.ToString());
            createdNode.LabelText = node.Value;
            createdNode.Label.FontColor = Color.White;
            createdNode.Attr.Padding = 18;
            
            if (node.Key == SourceTree.Root.Key)
            {
                return;
            }

            if (SourceFamily.Members[node.Key].IsDead(SourceSettings.At))
            {
                createdNode.Attr.FillColor = Color.DarkGreen;
            }
            else if (node.PartnerReference != null
                && node.Children.Count() == 0 && node.CommonChildren == null
            )
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
            InitializeDataCommonChildren(node);
            InitializeNode(node);
        }

        private void InitializeDataCommonChildren(Entities.Node node)
        {
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

        private void InitializeDataChildConstraints(Edge nodeEdge, Edge prevNodeEdge = null)
        {
            TreeGraph.LayerConstraints.AddUpDownConstraint(
                nodeEdge.SourceNode, nodeEdge.TargetNode
            );

            if (prevNodeEdge != null)
            {
                if (prevNodeEdge.TargetNode.UserData == null)
                {
                    TreeGraph.LayerConstraints.AddSameLayerNeighbors(
                        nodeEdge.TargetNode, prevNodeEdge.TargetNode
                    );
                }
                else
                {
                    TreeGraph.LayerConstraints.AddSameLayerNeighbors(
                        nodeEdge.TargetNode, (DrawingNode)prevNodeEdge.TargetNode.UserData
                    );
                }


            }
        }

        private void InitializeDataChildren(Entities.Node node)
        {
            Edge prevEdge = null;

            foreach (Entities.Node childNode in node.Children.Values)
            {
                Edge edge = CreateEdge(
                    node.Key, childNode.Key,
                    node.Key == SourceTree.Root.Key ? string.Empty : "child"
                );
                edge.Attr.Color = Color.SaddleBrown;
                edge.Label.FontColor = Color.SaddleBrown;
                edge.Attr.ArrowheadAtTarget = node.Key == SourceTree.Root.Key ? ArrowStyle.None : ArrowStyle.Generalization;

                InitializeData(childNode);
                InitializeDataChildConstraints(edge, prevEdge);
                prevEdge = edge;
            }
        }

        private void InitializeDataPartners(Entities.Node node)
        {
            if (node.Partner == null && node.PartnerReference == null)
            {
                return;
            }

            Edge e = CreateEdge(
                node.Key,
                node.Partner == null ? node.PartnerReference.Value : node.Partner.Key,
                "partner"
            );

            e.Attr.Color = Color.DarkGreen;
            e.Label.FontColor = e.Attr.Color;

            if (e.TargetNode.UserData == null)
            {
                TreeGraph.LayerConstraints.AddSameLayerNeighbors(
                    e.SourceNode, e.TargetNode
                );

                e.SourceNode.UserData = e.TargetNode;
            }

            if (node.Partner != null)
            {
                InitializeData(node.Partner);
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

        private void TreeDisplayDialogOnClose(object sender, FormClosedEventArgs e)
        {
            if (AnimationRunningValue.Checked)
            {
                GraphUpdateTimer.Dispose();
            }
        }

        private void AnimationIntervalOnChange(object sender, EventArgs e)
        {
            GraphUpdateTimer.Interval = (int)AnimationInterval.Value * 1000;
        }

        private void AnimationRunningValueOnChange(object sender, EventArgs e)
        {
            if (AnimationRunningValue.Checked)
            {
                GraphUpdateTimer.Start();
            }
            else
            {
                GraphUpdateTimer.Stop();
            }
        }
    }
}
