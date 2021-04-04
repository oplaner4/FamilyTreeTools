
namespace FamilyTreeTools
{
    partial class MemberAddDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BirthFullName = new System.Windows.Forms.TextBox();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.DeathDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ChooseChildren = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.KnownDeathDate = new System.Windows.Forms.CheckBox();
            this.ChooseChildrenAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Birth full name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Birth date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Death date";
            // 
            // BirthFullName
            // 
            this.BirthFullName.Location = new System.Drawing.Point(92, 20);
            this.BirthFullName.Name = "BirthFullName";
            this.BirthFullName.Size = new System.Drawing.Size(260, 20);
            this.BirthFullName.TabIndex = 3;
            // 
            // BirthDate
            // 
            this.BirthDate.Location = new System.Drawing.Point(92, 56);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(176, 20);
            this.BirthDate.TabIndex = 4;
            // 
            // DeathDate
            // 
            this.DeathDate.Enabled = false;
            this.DeathDate.Location = new System.Drawing.Point(173, 188);
            this.DeathDate.Name = "DeathDate";
            this.DeathDate.Size = new System.Drawing.Size(179, 20);
            this.DeathDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Children";
            // 
            // ChooseChildren
            // 
            this.ChooseChildren.FormattingEnabled = true;
            this.ChooseChildren.Items.AddRange(new object[] {
            "generated at runtime"});
            this.ChooseChildren.Location = new System.Drawing.Point(418, 39);
            this.ChooseChildren.Name = "ChooseChildren";
            this.ChooseChildren.Size = new System.Drawing.Size(368, 169);
            this.ChooseChildren.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(630, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.MemberSaveOnClick);
            // 
            // button4
            // 
            this.button4.CausesValidation = false;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(711, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // KnownDeathDate
            // 
            this.KnownDeathDate.AutoSize = true;
            this.KnownDeathDate.Location = new System.Drawing.Point(92, 188);
            this.KnownDeathDate.Name = "KnownDeathDate";
            this.KnownDeathDate.Size = new System.Drawing.Size(58, 17);
            this.KnownDeathDate.TabIndex = 16;
            this.KnownDeathDate.Text = "known";
            this.KnownDeathDate.UseVisualStyleBackColor = true;
            this.KnownDeathDate.CheckedChanged += new System.EventHandler(this.KnownDeathDateOnChange);
            // 
            // ChooseChildrenAll
            // 
            this.ChooseChildrenAll.AutoSize = true;
            this.ChooseChildrenAll.Location = new System.Drawing.Point(674, 19);
            this.ChooseChildrenAll.Name = "ChooseChildrenAll";
            this.ChooseChildrenAll.Size = new System.Drawing.Size(112, 17);
            this.ChooseChildrenAll.TabIndex = 17;
            this.ChooseChildrenAll.Text = "select/unselect all";
            this.ChooseChildrenAll.UseVisualStyleBackColor = true;
            this.ChooseChildrenAll.CheckedChanged += new System.EventHandler(this.ChooseChildrenAllOnChange);
            // 
            // MemberAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 257);
            this.Controls.Add(this.ChooseChildrenAll);
            this.Controls.Add(this.KnownDeathDate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ChooseChildren);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DeathDate);
            this.Controls.Add(this.BirthDate);
            this.Controls.Add(this.BirthFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MemberAddDialog";
            this.Text = "Member - add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BirthFullName;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.DateTimePicker DeathDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox ChooseChildren;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox KnownDeathDate;
        private System.Windows.Forms.CheckBox ChooseChildrenAll;
    }
}