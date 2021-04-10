
namespace FamilyTreeTools
{
    partial class TreeDisplayDialog
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
            this.WithLabelsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // WithLabelsCheckbox
            // 
            this.WithLabelsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WithLabelsCheckbox.AutoSize = true;
            this.WithLabelsCheckbox.Checked = true;
            this.WithLabelsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WithLabelsCheckbox.Location = new System.Drawing.Point(890, 37);
            this.WithLabelsCheckbox.Name = "WithLabelsCheckbox";
            this.WithLabelsCheckbox.Size = new System.Drawing.Size(78, 17);
            this.WithLabelsCheckbox.TabIndex = 6;
            this.WithLabelsCheckbox.Text = "With labels";
            this.WithLabelsCheckbox.UseVisualStyleBackColor = true;
            this.WithLabelsCheckbox.CheckedChanged += new System.EventHandler(this.WithLabelsCheckboxOnChange);
            // 
            // TreeDisplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 951);
            this.Controls.Add(this.WithLabelsCheckbox);
            this.Name = "TreeDisplayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Family tree tools - display tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox WithLabelsCheckbox;
    }
}