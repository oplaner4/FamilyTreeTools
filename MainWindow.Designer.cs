
namespace FamilyTreeTools
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MembersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MembersMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItemAnimate = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveAsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMembersValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateAtValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BornValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ChildrenCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AncestorsCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DescendantsCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.ToolbarSettingsEdit = new System.Windows.Forms.ToolStripButton();
            this.ToolbarSaveFile = new System.Windows.Forms.ToolStripButton();
            this.ToolBarAddMember = new System.Windows.Forms.ToolStripButton();
            this.ToolBarDisplayTree = new System.Windows.Forms.ToolStripButton();
            this.MembersListBox = new System.Windows.Forms.ListBox();
            this.EditSelectedBtn = new System.Windows.Forms.Button();
            this.RemoveSelectedBtn = new System.Windows.Forms.Button();
            this.FamilyNameLabel = new System.Windows.Forms.Label();
            this.ExportTreeDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SiblingsCountValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.MainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.MembersMenuItem,
            this.SettingsMenuItem,
            this.TreeMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(809, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Menu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItemNew,
            this.FileMenuItemOpen,
            this.FileMenuItemSave,
            this.FileMenuItemSaveAs});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // FileMenuItemNew
            // 
            this.FileMenuItemNew.Name = "FileMenuItemNew";
            this.FileMenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileMenuItemNew.Size = new System.Drawing.Size(146, 22);
            this.FileMenuItemNew.Text = "New";
            this.FileMenuItemNew.Click += new System.EventHandler(this.FileMenuItemNewOnClick);
            // 
            // FileMenuItemOpen
            // 
            this.FileMenuItemOpen.Name = "FileMenuItemOpen";
            this.FileMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileMenuItemOpen.Size = new System.Drawing.Size(146, 22);
            this.FileMenuItemOpen.Text = "Open";
            this.FileMenuItemOpen.Click += new System.EventHandler(this.FileMenuItemOpenOnClick);
            // 
            // FileMenuItemSave
            // 
            this.FileMenuItemSave.Enabled = false;
            this.FileMenuItemSave.Name = "FileMenuItemSave";
            this.FileMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileMenuItemSave.Size = new System.Drawing.Size(146, 22);
            this.FileMenuItemSave.Text = "Save";
            this.FileMenuItemSave.Click += new System.EventHandler(this.FileMenuItemSaveOnClick);
            // 
            // FileMenuItemSaveAs
            // 
            this.FileMenuItemSaveAs.Enabled = false;
            this.FileMenuItemSaveAs.Name = "FileMenuItemSaveAs";
            this.FileMenuItemSaveAs.Size = new System.Drawing.Size(146, 22);
            this.FileMenuItemSaveAs.Text = "Save as";
            this.FileMenuItemSaveAs.Click += new System.EventHandler(this.FileMenuItemSaveAsOnClick);
            // 
            // MembersMenuItem
            // 
            this.MembersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MembersMenuItemAdd});
            this.MembersMenuItem.Name = "MembersMenuItem";
            this.MembersMenuItem.Size = new System.Drawing.Size(69, 20);
            this.MembersMenuItem.Text = "Members";
            // 
            // MembersMenuItemAdd
            // 
            this.MembersMenuItemAdd.Name = "MembersMenuItemAdd";
            this.MembersMenuItemAdd.Size = new System.Drawing.Size(96, 22);
            this.MembersMenuItemAdd.Text = "Add";
            this.MembersMenuItemAdd.Click += new System.EventHandler(this.MembersMenuItemAddOnClick);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItemEdit});
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // SettingsMenuItemEdit
            // 
            this.SettingsMenuItemEdit.Name = "SettingsMenuItemEdit";
            this.SettingsMenuItemEdit.Size = new System.Drawing.Size(94, 22);
            this.SettingsMenuItemEdit.Text = "Edit";
            this.SettingsMenuItemEdit.Click += new System.EventHandler(this.SettingsMenuItemEditOnClick);
            // 
            // TreeMenuItem
            // 
            this.TreeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenuItemExport,
            this.TreeMenuItemAnimate,
            this.displayToolStripMenuItem});
            this.TreeMenuItem.Name = "TreeMenuItem";
            this.TreeMenuItem.Size = new System.Drawing.Size(40, 20);
            this.TreeMenuItem.Text = "Tree";
            // 
            // TreeMenuItemExport
            // 
            this.TreeMenuItemExport.Name = "TreeMenuItemExport";
            this.TreeMenuItemExport.Size = new System.Drawing.Size(119, 22);
            this.TreeMenuItemExport.Text = "Export";
            this.TreeMenuItemExport.Click += new System.EventHandler(this.TreeMenuItemExportOnClick);
            // 
            // TreeMenuItemAnimate
            // 
            this.TreeMenuItemAnimate.Name = "TreeMenuItemAnimate";
            this.TreeMenuItemAnimate.Size = new System.Drawing.Size(119, 22);
            this.TreeMenuItemAnimate.Text = "Animate";
            this.TreeMenuItemAnimate.Click += new System.EventHandler(this.TreeMenuItemAnimateOnClick);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.TreeMenuItemDisplayOnClick);
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TotalMembersValue,
            this.toolStripStatusLabel7,
            this.DateAtValue,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4,
            this.BornValue,
            this.toolStripStatusLabel2,
            this.ChildrenCountValue,
            this.toolStripStatusLabel6,
            this.AncestorsCountValue,
            this.toolStripStatusLabel8,
            this.DescendantsCountValue,
            this.toolStripStatusLabel3,
            this.SiblingsCountValue});
            this.MainStatus.Location = new System.Drawing.Point(0, 455);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(809, 24);
            this.MainStatus.TabIndex = 3;
            this.MainStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 19);
            this.toolStripStatusLabel1.Text = "Total:";
            // 
            // TotalMembersValue
            // 
            this.TotalMembersValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TotalMembersValue.Name = "TotalMembersValue";
            this.TotalMembersValue.Size = new System.Drawing.Size(14, 19);
            this.TotalMembersValue.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(73, 19);
            this.toolStripStatusLabel7.Text = "    Date at:";
            // 
            // DateAtValue
            // 
            this.DateAtValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DateAtValue.Name = "DateAtValue";
            this.DateAtValue.Size = new System.Drawing.Size(69, 19);
            this.DateAtValue.Text = "00.00.0000";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(82, 19);
            this.toolStripStatusLabel5.Text = "     Selected:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 19);
            this.toolStripStatusLabel4.Text = "Born:";
            // 
            // BornValue
            // 
            this.BornValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BornValue.Name = "BornValue";
            this.BornValue.Size = new System.Drawing.Size(12, 19);
            this.BornValue.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 19);
            this.toolStripStatusLabel2.Text = "Children:";
            // 
            // ChildrenCountValue
            // 
            this.ChildrenCountValue.Enabled = false;
            this.ChildrenCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ChildrenCountValue.Name = "ChildrenCountValue";
            this.ChildrenCountValue.Size = new System.Drawing.Size(12, 19);
            this.ChildrenCountValue.Text = "-";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabel6.Text = "Ancestors:";
            // 
            // AncestorsCountValue
            // 
            this.AncestorsCountValue.Enabled = false;
            this.AncestorsCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AncestorsCountValue.Name = "AncestorsCountValue";
            this.AncestorsCountValue.Size = new System.Drawing.Size(12, 19);
            this.AncestorsCountValue.Text = "-";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(77, 19);
            this.toolStripStatusLabel8.Text = "Descendants:";
            // 
            // DescendantsCountValue
            // 
            this.DescendantsCountValue.Enabled = false;
            this.DescendantsCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DescendantsCountValue.Name = "DescendantsCountValue";
            this.DescendantsCountValue.Size = new System.Drawing.Size(12, 19);
            this.DescendantsCountValue.Text = "-";
            // 
            // MainToolbar
            // 
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolbarSettingsEdit,
            this.ToolbarSaveFile,
            this.ToolBarAddMember,
            this.ToolBarDisplayTree});
            this.MainToolbar.Location = new System.Drawing.Point(0, 24);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(809, 25);
            this.MainToolbar.TabIndex = 4;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // ToolbarSettingsEdit
            // 
            this.ToolbarSettingsEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarSettingsEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarSettingsEdit.Image")));
            this.ToolbarSettingsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarSettingsEdit.Name = "ToolbarSettingsEdit";
            this.ToolbarSettingsEdit.Size = new System.Drawing.Size(23, 22);
            this.ToolbarSettingsEdit.Text = "toolStripButton1";
            this.ToolbarSettingsEdit.ToolTipText = "Edit settings";
            this.ToolbarSettingsEdit.Click += new System.EventHandler(this.SettingsMenuItemEditOnClick);
            // 
            // ToolbarSaveFile
            // 
            this.ToolbarSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolbarSaveFile.Image")));
            this.ToolbarSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarSaveFile.Name = "ToolbarSaveFile";
            this.ToolbarSaveFile.Size = new System.Drawing.Size(23, 22);
            this.ToolbarSaveFile.Text = "toolStripButton1";
            this.ToolbarSaveFile.ToolTipText = "Save file";
            this.ToolbarSaveFile.Click += new System.EventHandler(this.FileMenuItemSaveOnClick);
            // 
            // ToolBarAddMember
            // 
            this.ToolBarAddMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolBarAddMember.Image = ((System.Drawing.Image)(resources.GetObject("ToolBarAddMember.Image")));
            this.ToolBarAddMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBarAddMember.Name = "ToolBarAddMember";
            this.ToolBarAddMember.Size = new System.Drawing.Size(23, 22);
            this.ToolBarAddMember.Text = "toolStripButton1";
            this.ToolBarAddMember.ToolTipText = "Add member";
            this.ToolBarAddMember.Click += new System.EventHandler(this.MembersMenuItemAddOnClick);
            // 
            // ToolBarDisplayTree
            // 
            this.ToolBarDisplayTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolBarDisplayTree.Image = ((System.Drawing.Image)(resources.GetObject("ToolBarDisplayTree.Image")));
            this.ToolBarDisplayTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolBarDisplayTree.Name = "ToolBarDisplayTree";
            this.ToolBarDisplayTree.Size = new System.Drawing.Size(23, 22);
            this.ToolBarDisplayTree.Text = "Display tree";
            this.ToolBarDisplayTree.Click += new System.EventHandler(this.TreeMenuItemDisplayOnClick);
            // 
            // MembersListBox
            // 
            this.MembersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MembersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersListBox.FormattingEnabled = true;
            this.MembersListBox.ItemHeight = 16;
            this.MembersListBox.Items.AddRange(new object[] {
            "abc"});
            this.MembersListBox.Location = new System.Drawing.Point(12, 84);
            this.MembersListBox.Name = "MembersListBox";
            this.MembersListBox.ScrollAlwaysVisible = true;
            this.MembersListBox.Size = new System.Drawing.Size(785, 324);
            this.MembersListBox.TabIndex = 5;
            this.MembersListBox.SelectedIndexChanged += new System.EventHandler(this.MembersListBoxOnSelected);
            this.MembersListBox.DoubleClick += new System.EventHandler(this.MembersListBoxOnDoubleClick);
            this.MembersListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MembersListBoxOnKeyDown);
            // 
            // EditSelectedBtn
            // 
            this.EditSelectedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditSelectedBtn.Location = new System.Drawing.Point(638, 414);
            this.EditSelectedBtn.Name = "EditSelectedBtn";
            this.EditSelectedBtn.Size = new System.Drawing.Size(159, 23);
            this.EditSelectedBtn.TabIndex = 6;
            this.EditSelectedBtn.Text = "Edit selected (or double click)";
            this.EditSelectedBtn.UseVisualStyleBackColor = true;
            this.EditSelectedBtn.Click += new System.EventHandler(this.EditSelectedBtnOnClick);
            // 
            // RemoveSelectedBtn
            // 
            this.RemoveSelectedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveSelectedBtn.Location = new System.Drawing.Point(473, 414);
            this.RemoveSelectedBtn.Name = "RemoveSelectedBtn";
            this.RemoveSelectedBtn.Size = new System.Drawing.Size(159, 23);
            this.RemoveSelectedBtn.TabIndex = 7;
            this.RemoveSelectedBtn.Text = "Remove selected (or Del)";
            this.RemoveSelectedBtn.UseVisualStyleBackColor = true;
            this.RemoveSelectedBtn.Click += new System.EventHandler(this.RemoveSelectedBtnOnClick);
            // 
            // FamilyNameLabel
            // 
            this.FamilyNameLabel.AutoSize = true;
            this.FamilyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FamilyNameLabel.Location = new System.Drawing.Point(9, 63);
            this.FamilyNameLabel.Name = "FamilyNameLabel";
            this.FamilyNameLabel.Size = new System.Drawing.Size(136, 18);
            this.FamilyNameLabel.TabIndex = 8;
            this.FamilyNameLabel.Text = "Changes at runtime";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 19);
            this.toolStripStatusLabel3.Text = "Siblings:";
            // 
            // SiblingsCountValue
            // 
            this.SiblingsCountValue.Enabled = false;
            this.SiblingsCountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SiblingsCountValue.Name = "SiblingsCountValue";
            this.SiblingsCountValue.Size = new System.Drawing.Size(12, 19);
            this.SiblingsCountValue.Text = "-";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 479);
            this.Controls.Add(this.FamilyNameLabel);
            this.Controls.Add(this.RemoveSelectedBtn);
            this.Controls.Add(this.EditSelectedBtn);
            this.Controls.Add(this.MembersListBox);
            this.Controls.Add(this.MainToolbar);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Family tree tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowOnClose);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MembersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MembersMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItemExport;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveAsFileDialog;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItemAnimate;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStrip MainToolbar;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ChildrenCountValue;
        private System.Windows.Forms.ListBox MembersListBox;
        private System.Windows.Forms.ToolStripStatusLabel TotalMembersValue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel AncestorsCountValue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel DescendantsCountValue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItemEdit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel BornValue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel DateAtValue;
        private System.Windows.Forms.Button EditSelectedBtn;
        private System.Windows.Forms.Button RemoveSelectedBtn;
        private System.Windows.Forms.Label FamilyNameLabel;
        private System.Windows.Forms.ToolStripButton ToolbarSettingsEdit;
        private System.Windows.Forms.ToolStripButton ToolbarSaveFile;
        private System.Windows.Forms.ToolStripButton ToolBarAddMember;
        private System.Windows.Forms.SaveFileDialog ExportTreeDialog;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemNew;
        private System.Windows.Forms.ToolStripButton ToolBarDisplayTree;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel SiblingsCountValue;
    }
}

