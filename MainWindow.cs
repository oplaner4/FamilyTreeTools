using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using FamilyTreeTools.Utilities.Generators;
using System;

namespace FamilyTreeTools
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            Icon = Resources.favicon;
            InitializeComponent();
        }

        private void MainWindowOnLoad(object sender, EventArgs e)
        {
            Family fieldFamily = FamilyGenerator.GetData();

            Tree fieldFamilyTree = new Tree(fieldFamily, new SearchSettings());

            familyTree.BeginUpdate();
            familyTree.Nodes.Add("Parent");
            familyTree.Nodes[0].Nodes.Add("Child 1");
            familyTree.Nodes[0].Nodes.Add("Child 2");
            familyTree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            familyTree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            familyTree.EndUpdate();



        }
    }
}
