using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using FamilyTreeTools.Utilities.Serialize;
using System;

namespace FamilyTreeTools
{
    public partial class MainWindow : Form
    {
        public Family SourceFamily { get; set; }

        public string FileFullName { get; set; }

        public bool UnsavedChanges { get; set; }

        public MainWindow()
        {
            Icon = Resources.favicon;
            InitializeComponent();
            OpenFileDialog.Filter = string.Format(
                "*.{0}|*.{0}|All files (*.*)|*.*",
                FamilySerializeHelper.StandardExtension
            );
            SaveAsFileDialog.Filter = OpenFileDialog.Filter;
            SourceFamily = new Family("family");
        }

        private void MainWindowOnLoad(object sender, EventArgs e)
        {
            /*Family fieldFamily = FamilyGenerator.GetData();
            Tree fieldFamilyTree = new Tree(fieldFamily);

            familyTree.BeginUpdate();
            familyTree.Nodes.Add("Parent");
            familyTree.Nodes[0].Nodes.Add("Child 1");
            familyTree.Nodes[0].Nodes.Add("Child 2");
            familyTree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            familyTree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            familyTree.EndUpdate();*/
        }

        private void UpdateUI()
        {
            if (SourceFamily != null)
            {
                FileMenuItemSaveAs.Enabled = true;
                FileMenuItemSave.Enabled = true;

                if (SourceFamily.Members.Count > 0)
                {
                    MembersMenuItemEdit.Enabled = true;
                }
                else
                {
                    MembersMenuItemEdit.Enabled = false;
                }

                TotalMembersValue.Text = SourceFamily.Members.Count.ToString();
            }
        }

        private void FileMenuItemOpenOnClick(object sender, EventArgs e)
        {
            if (HandleUnsavedChanges())
            {
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileFullName = OpenFileDialog.FileName;
                    SourceFamily = new FamilySerializeHelper(FileFullName).Load();
                    UpdateUI();
                    UnsavedChanges = false;
                };
            }


        }

        private void FileMenuItemSaveOnClick(object sender, EventArgs e)
        {
            if (FileFullName == null)
            {
                FileFullName = OpenFileDialog.FileName;
                SaveFileShowDialog();
            }
            else
            {
                new FamilySerializeHelper(FileFullName).Save(SourceFamily);
                UnsavedChanges = false;
            }
        }

        private void FileMenuItemSaveAsOnClick(object sender, EventArgs e)
        {
            SaveFileShowDialog();
        }

        private void SaveFileShowDialog()
        {
            if (SaveAsFileDialog.ShowDialog() == DialogResult.OK)
            {
                new FamilySerializeHelper(SaveAsFileDialog.FileName).Save(SourceFamily);
                UnsavedChanges = false;
                UpdateUI();
            };
        }

        private void MembersMenuItemAddOnClick(object sender, EventArgs e)
        {
            MemberAddDialog dialog = new MemberAddDialog(SourceFamily);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceFamily.AddMember(dialog.SourceMember);
                UnsavedChanges = true;
                UpdateUI();
            };
        }

        private void FileMenuItemExitOnClick(object sender, EventArgs e)
        {
            SaveExit();
        }

        private bool HandleUnsavedChanges()
        {
            return !UnsavedChanges || new UnsavedConfirmDialog().ShowDialog() == DialogResult.OK;
        }

        private void SaveExit()
        {
            if (HandleUnsavedChanges())
            {
                Application.Exit();
            }
        }

        private void MainWindowOnClose(object sender, FormClosingEventArgs e)
        {
            SaveExit();
        }
    }
}
