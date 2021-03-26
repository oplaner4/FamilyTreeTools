
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MembersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MembersMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MembersMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familyTree = new System.Windows.Forms.TreeView();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveAsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.MembersMenuItem,
            this.TreeMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Menu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItemOpen,
            this.FileMenuItemSave,
            this.FileMenuItemSaveAs});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // FileMenuItemOpen
            // 
            this.FileMenuItemOpen.Name = "FileMenuItemOpen";
            this.FileMenuItemOpen.Size = new System.Drawing.Size(138, 22);
            this.FileMenuItemOpen.Text = "Open";
            this.FileMenuItemOpen.Click += new System.EventHandler(this.FileMenuItemOpenOnClick);
            // 
            // FileMenuItemSave
            // 
            this.FileMenuItemSave.Enabled = false;
            this.FileMenuItemSave.Name = "FileMenuItemSave";
            this.FileMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileMenuItemSave.Size = new System.Drawing.Size(138, 22);
            this.FileMenuItemSave.Text = "Save";
            this.FileMenuItemSave.Click += new System.EventHandler(this.FileMenuItemSaveOnClick);
            // 
            // FileMenuItemSaveAs
            // 
            this.FileMenuItemSaveAs.Enabled = false;
            this.FileMenuItemSaveAs.Name = "FileMenuItemSaveAs";
            this.FileMenuItemSaveAs.Size = new System.Drawing.Size(138, 22);
            this.FileMenuItemSaveAs.Text = "Save as";
            this.FileMenuItemSaveAs.Click += new System.EventHandler(this.FileMenuItemSaveAsOnClick);
            // 
            // MembersMenuItem
            // 
            this.MembersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MembersMenuItemAdd,
            this.MembersMenuItemEdit});
            this.MembersMenuItem.Name = "MembersMenuItem";
            this.MembersMenuItem.Size = new System.Drawing.Size(69, 20);
            this.MembersMenuItem.Text = "Members";
            // 
            // MembersMenuItemAdd
            // 
            this.MembersMenuItemAdd.Name = "MembersMenuItemAdd";
            this.MembersMenuItemAdd.Size = new System.Drawing.Size(180, 22);
            this.MembersMenuItemAdd.Text = "Add";
            this.MembersMenuItemAdd.Click += new System.EventHandler(this.MembersMenuItemAddOnClick);
            // 
            // MembersMenuItemEdit
            // 
            this.MembersMenuItemEdit.Enabled = false;
            this.MembersMenuItemEdit.Name = "MembersMenuItemEdit";
            this.MembersMenuItemEdit.Size = new System.Drawing.Size(180, 22);
            this.MembersMenuItemEdit.Text = "Edit";
            // 
            // TreeMenuItem
            // 
            this.TreeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenuItemSettings,
            this.TreeMenuItemExport,
            this.animationToolStripMenuItem});
            this.TreeMenuItem.Name = "TreeMenuItem";
            this.TreeMenuItem.Size = new System.Drawing.Size(40, 20);
            this.TreeMenuItem.Text = "Tree";
            // 
            // TreeMenuItemSettings
            // 
            this.TreeMenuItemSettings.Name = "TreeMenuItemSettings";
            this.TreeMenuItemSettings.Size = new System.Drawing.Size(130, 22);
            this.TreeMenuItemSettings.Text = "Settings";
            // 
            // TreeMenuItemExport
            // 
            this.TreeMenuItemExport.Enabled = false;
            this.TreeMenuItemExport.Name = "TreeMenuItemExport";
            this.TreeMenuItemExport.Size = new System.Drawing.Size(130, 22);
            this.TreeMenuItemExport.Text = "Export";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.Enabled = false;
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.animationToolStripMenuItem.Text = "Animation";
            // 
            // familyTree
            // 
            this.familyTree.Location = new System.Drawing.Point(12, 41);
            this.familyTree.Name = "familyTree";
            this.familyTree.Size = new System.Drawing.Size(275, 321);
            this.familyTree.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.familyTree);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainWindow";
            this.Text = "Family tree tools";
            this.Load += new System.EventHandler(this.MainWindowOnLoad);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.TreeView familyTree;
        private System.Windows.Forms.ToolStripMenuItem MembersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MembersMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem MembersMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem TreeMenuItemExport;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveAsFileDialog;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
    }
}

