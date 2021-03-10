
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.efToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abToolStripMenuItem,
            this.bcToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(88, 48);
            // 
            // abToolStripMenuItem
            // 
            this.abToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cdToolStripMenuItem,
            this.aToolStripMenuItem});
            this.abToolStripMenuItem.Name = "abToolStripMenuItem";
            this.abToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.abToolStripMenuItem.Text = "ab";
            // 
            // cdToolStripMenuItem
            // 
            this.cdToolStripMenuItem.Name = "cdToolStripMenuItem";
            this.cdToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.cdToolStripMenuItem.Text = "cd";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.aToolStripMenuItem.Text = "a";
            // 
            // bcToolStripMenuItem
            // 
            this.bcToolStripMenuItem.Name = "bcToolStripMenuItem";
            this.bcToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.bcToolStripMenuItem.Text = "bc";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abcToolStripMenuItem,
            this.cdToolStripMenuItem1,
            this.efToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abcToolStripMenuItem
            // 
            this.abcToolStripMenuItem.Name = "abcToolStripMenuItem";
            this.abcToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.abcToolStripMenuItem.Text = "abc";
            // 
            // cdToolStripMenuItem1
            // 
            this.cdToolStripMenuItem1.Name = "cdToolStripMenuItem1";
            this.cdToolStripMenuItem1.Size = new System.Drawing.Size(32, 20);
            this.cdToolStripMenuItem1.Text = "cd";
            // 
            // efToolStripMenuItem
            // 
            this.efToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cdToolStripMenuItem2});
            this.efToolStripMenuItem.Name = "efToolStripMenuItem";
            this.efToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.efToolStripMenuItem.Text = "ef";
            // 
            // cdToolStripMenuItem2
            // 
            this.cdToolStripMenuItem2.Checked = true;
            this.cdToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cdToolStripMenuItem2.Name = "cdToolStripMenuItem2";
            this.cdToolStripMenuItem2.Size = new System.Drawing.Size(87, 22);
            this.cdToolStripMenuItem2.Text = "cd";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Family tree tools";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bcToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cdToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem efToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cdToolStripMenuItem2;
    }
}

