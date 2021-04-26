using FamilyTreeTools.Entities;
using FamilyTreeTools.Properties;
using FamilyTreeTools.Utilities.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class MainWindow : Form
    {
        public Family SourceFamily { get; set; }

        public SearchSettings UseSettings { get; set; }
        public string FileFullName { get; set; }
        public bool UnsavedChanges { get; set; }
        public IEnumerable<Member> EnumerableMembers { get; set; }
        public MainWindow(string openedFileName = null)
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

            SourceFamily = new Family("Unsaved family");
            UseSettings = new SearchSettings();

            FileFullName = openedFileName;

            if (openedFileName != null)
            {
                LoadFamily();
            }

            UpdateUI();
            UpdateUIMembersListBox();

        }

        private void UpdateUI()
        {
            if (SourceFamily != null)
            {
                FileMenuItemSaveAs.Enabled = true;
                FileMenuItemSave.Enabled = true;

                DateAtValue.Text = UseSettings.At.ToString("dd/MM/yyyy");
            }

            FamilyNameLabel.Text = SourceFamily.Name;
            Text = string.Format("Family tree tools - {0}{1}",
                UnsavedChanges ? "*" : string.Empty,
                SourceFamily.Name
            );
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
            TotalMembersValue.Text = EnumerableMembers.Count().ToString();
        }

        private void LoadFamily()
        {
            Family loadedFamily = new FamilySerializeHelper(FileFullName).Load();

            if (loadedFamily == null)
            {
                new ValidationFailedDialog("Unable to load family. The file might be damaged.").ShowDialog();
            }
            else
            {
                SourceFamily = loadedFamily;
                UnsavedChanges = false;
                UpdateUI();
                UpdateUIMembersListBox();
            }
        }

        private void FileMenuItemOpenOnClick(object sender, EventArgs e)
        {
            if (HandleUnsavedChanges() && OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileFullName = OpenFileDialog.FileName;
                LoadFamily();
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
                UpdateUI();
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
                string sourceFamilyNameBefore = SourceFamily.Name;
                SourceFamily.Name = Path.GetFileNameWithoutExtension(
                    SaveAsFileDialog.FileName
                );
                new FamilySerializeHelper(SaveAsFileDialog.FileName).Save(SourceFamily);
                if (FileFullName == null)
                {
                    SourceFamily.Name = Path.GetFileNameWithoutExtension(
                        SaveAsFileDialog.FileName
                    );
                }
                else
                {
                    SourceFamily.Name = sourceFamilyNameBefore;
                }

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
                UpdateUIMembersListBox();
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
                    SiblingsCountValue.Enabled = true;

                    DescendantsCountValue.Text = m.Refs.GetDescendants(UseSettings).Count().ToString();
                    AncestorsCountValue.Text = m.Refs.GetAncestors(UseSettings).Count().ToString();
                    ChildrenCountValue.Text = m.Refs.Children.Count().ToString();
                    SiblingsCountValue.Text = m.Refs.GetSiblings(UseSettings).Count().ToString();
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
                    SiblingsCountValue.Text = "-";
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

        private void EditSelectedMember()
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
                    UpdateUI();
                }
            });
        }

        private void MembersListBoxOnDoubleClick(object sender, EventArgs e)
        {
            EditSelectedMember();
        }

        private void EditSelectedBtnOnClick(object sender, EventArgs e)
        {
            EditSelectedMember();
        }

        private void RemoveSelectedBtnOnClick(object sender, EventArgs e)
        {
            RemoveSelectedMember();
        }

        private void RemoveSelectedMember()
        {
            UsingSelectedMember(m =>
            {
                if (SourceFamily.CanBeRemoved(m) && new DestructiveConfirmDialog().ShowDialog() == DialogResult.OK)
                {
                    SourceFamily.RemoveMember(m);
                    UnsavedChanges = true;
                    UpdateUI();
                    UpdateUIMembersListBox();
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
                EditSelectedMember();
            }
        }

        private void TreeMenuItemExportOnClick(object sender, EventArgs e)
        {
            if (ExportTreeDialog.ShowDialog() == DialogResult.OK)
            {
                new TreeSerializeHelper(ExportTreeDialog.FileName).Save(
                    new Tree(SourceFamily, UseSettings)
                );
            };
        }

        private void FileMenuItemNewOnClick(object sender, EventArgs e)
        {
            if (HandleUnsavedChanges() && SaveAsFileDialog.ShowDialog() == DialogResult.OK)
            {
                SourceFamily = new Family(
                    Path.GetFileNameWithoutExtension(SaveAsFileDialog.FileName)
                );
                new FamilySerializeHelper(SaveAsFileDialog.FileName).Save(SourceFamily);
                FileFullName = SaveAsFileDialog.FileName;
                UnsavedChanges = false;
                UpdateUI();
                UpdateUIMembersListBox();
            };
        }

        private void TreeMenuItemDisplayOnClick(object sender, EventArgs e)
        {
            TreeDisplayDialog dialog = new TreeDisplayDialog(
                SourceFamily, UseSettings
            );

            if (dialog.ShowDialog() == DialogResult.OK)
            {

            };
        }

        private void TreeMenuItemAnimateOnClick(object sender, EventArgs e)
        {
            TreeDisplayDialog dialog = new TreeDisplayDialog(
                SourceFamily, UseSettings,
                true
            );

            if (dialog.ShowDialog() == DialogResult.OK)
            {

            };
        }

        private void FileExitMenuItemOnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
