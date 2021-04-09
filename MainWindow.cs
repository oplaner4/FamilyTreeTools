using FamilyTreeTools.Properties;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using FamilyTreeTools.Utilities.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTreeTools.Utilities.Generators;
using System.IO;

namespace FamilyTreeTools
{
    public partial class MainWindow : Form
    {
        public Family SourceFamily { get; set; }

        public SearchSettings UseSettings { get; set; }

        public string FileFullName { get; set; }

        public bool UnsavedChanges { get; set; }

        public IEnumerable<Member> EnumerableMembers { get; set; }

        public MainWindow()
        {
            Icon = Resources.favicon;
            InitializeComponent();
            OpenFileDialog.Filter = string.Format(
                "*.{0}|*.{0}|All files (*.*)|*.*",
                FamilySerializeHelper.StandardExtension
            );
            SaveAsFileDialog.Filter = OpenFileDialog.Filter;

            ExportTreeDialog.Filter = string.Format(
                "*.{0}|*.{0}|All files (*.*)|*.*",
                TreeSerializeHelper.StandardExtension
            );

            // SourceFamily = new Family("family");
            SourceFamily = FamilyGenerator.GetData();
            UseSettings = new SearchSettings();
            UpdateUI();
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
            UpdateUIMembersListBox();

            if (SourceFamily != null)
            {
                FileMenuItemSaveAs.Enabled = true;
                FileMenuItemSave.Enabled = true;

                DateAtValue.Text = UseSettings.At.ToString("dd/MM/yyyy");
            }
        }

        private void UpdateUIMembersListBox()
        {
            EnumerableMembers = SourceFamily.GetEnumerableMembers();

            MembersListBox.Items.Clear();

            if (EnumerableMembers.Any())
            {
                foreach (Member member in EnumerableMembers)
                {
                    MembersListBox.Items.Add(member);
                }
            }
            else
            {
                MembersListBox.Items.Add("No available members.");
            }

            EditSelectedBtn.Enabled = false;
            RemoveSelectedBtn.Enabled = false;
        }

        private void FileMenuItemOpenOnClick(object sender, EventArgs e)
        {
            if (HandleUnsavedChanges() && OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileFullName = OpenFileDialog.FileName;

                Family loadedFamily = new FamilySerializeHelper(FileFullName).Load();

                if (loadedFamily == null)
                {
                    new ValidationFailedDialog("Unable to load family. The file might be damaged.").ShowDialog();
                }
                else
                {
                    SourceFamily = loadedFamily;
                    UpdateUI();
                    UnsavedChanges = false;
                }
            }
        }

        private void FileMenuItemSaveOnClick(object sender, EventArgs e)
        {
            if (FileFullName == null)
            {
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
                SourceFamily.Name = Path.GetFileNameWithoutExtension(SaveAsFileDialog.FileName);
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
                SourceFamily.AddMember(dialog.OutMember);
                UnsavedChanges = true;
                UpdateUI();
            };
        }

        private bool HandleUnsavedChanges()
        {
            return !UnsavedChanges || new UnsavedConfirmDialog().ShowDialog() == DialogResult.OK;
        }

        private void MainWindowOnClose(object sender, FormClosingEventArgs e)
        {
            if (!HandleUnsavedChanges())
            {
                e.Cancel = true;
            }
        }

        private void MembersListBoxOnSelected(object sender, EventArgs e)
        {
            UsingSelectedMember(m =>
            {
                Member selectedMember = EnumerableMembers.ElementAt(MembersListBox.SelectedIndex);
                if (m.IsBorn(UseSettings.At, UseSettings.CanBeDead))
                {
                    BornValue.Text = "Yes";
                    DescendantsCountValue.Enabled = true;
                    AncestorsCountValue.Enabled = true;
                    ChildrenCountValue.Enabled = true;

                    DescendantsCountValue.Text = m.Refs.GetDescendants(UseSettings).Count().ToString();
                    AncestorsCountValue.Text = m.Refs.GetAncestors(UseSettings).Count().ToString();
                    ChildrenCountValue.Text = m.Refs.Children.Count().ToString();
                }
                else
                {
                    BornValue.Text = "No";
                    DescendantsCountValue.Enabled = false;
                    AncestorsCountValue.Enabled = false;
                    ChildrenCountValue.Enabled = false;

                    DescendantsCountValue.Text = "-";
                    AncestorsCountValue.Text = "-";
                    ChildrenCountValue.Text = "-";
                }

                RemoveSelectedBtn.Enabled = SourceFamily.CanBeRemoved(selectedMember);
                EditSelectedBtn.Enabled = true;
            });
        }

        private void SettingsMenuItemEditOnClick(object sender, EventArgs e)
        {
            EditSettingsDialog settingsDialog = new EditSettingsDialog(UseSettings);
            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                UseSettings = settingsDialog.Settings;
                UpdateUI();
            };
        }

        private void EditMember()
        {
            UsingSelectedMember(m =>
            {
                MemberEditDialog editDialog = new MemberEditDialog(
                    SourceFamily, m
                );

                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    UnsavedChanges = true;
                    RemoveSelectedBtn.Enabled = SourceFamily.CanBeRemoved(m);
                }
            });
        }

        private void MembersListBoxOnDoubleClick(object sender, EventArgs e)
        {
            EditMember();
        }

        private void EditSelectedBtnOnClick(object sender, EventArgs e)
        {
            EditMember();
        }

        private void RemoveSelectedBtnOnClick(object sender, EventArgs e)
        {
            RemoveSelectedMember();
        }

        private void RemoveSelectedMember()
        {
            UsingSelectedMember(m =>
            {
                if (new DestructiveConfirmDialog().ShowDialog() == DialogResult.OK)
                {
                    SourceFamily.RemoveMember(m);
                    UnsavedChanges = true;
                    UpdateUI();
                }
            });
        }

        private void UsingSelectedMember(Action<Member> action)
        {
            if (MembersListBox.SelectedIndex > -1 && EnumerableMembers.Any())
            {
                action(EnumerableMembers.ElementAt(MembersListBox.SelectedIndex));
            }
        }

        private void MembersListBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedMember();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EditMember();
            }
        }

        private void TreeMenuItemExportOnClick(object sender, EventArgs e)
        {
            if (ExportTreeDialog.ShowDialog() == DialogResult.OK)
            {
                new TreeSerializeHelper(ExportTreeDialog.FileName).Save(
                    new Tree(SourceFamily, UseSettings).Build()
                );
            };
        }

        private void FileMenuItemNewOnClick(object sender, EventArgs e)
        {
            if (SaveAsFileDialog.ShowDialog() == DialogResult.OK)
            {
                SourceFamily = new Family("family");
                new FamilySerializeHelper(SaveAsFileDialog.FileName).Save(SourceFamily);
                FileFullName = SaveAsFileDialog.FileName;
                UnsavedChanges = false;
                UpdateUI();
            };
        }

        private void TreeMenuItemDisplayOnClick(object sender, EventArgs e)
        {
            TreeDisplayDialog dialog = new TreeDisplayDialog(
                new Tree(SourceFamily, UseSettings).Build()
            );

            if (dialog.ShowDialog() == DialogResult.OK) {

            };
        }
    }
}
