
namespace FamilyTreeTools
{
    partial class MemberEditDialog
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
            this.PartnerListBox = new System.Windows.Forms.ListBox();
            this.StatusListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartnersComboBox = new System.Windows.Forms.ComboBox();
            this.SinceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.GotMarriedBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.WithPartnerBtn = new System.Windows.Forms.Button();
            this.WithoutPartnerBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FullNamesListBox = new System.Windows.Forms.ListBox();
            this.ChangedFullNameBtn = new System.Windows.Forms.Button();
            this.FullNameTxtBox = new System.Windows.Forms.TextBox();
            this.RemoveSelectedFullNameBtn = new System.Windows.Forms.Button();
            this.GotUnmarriedBtn = new System.Windows.Forms.Button();
            this.ChooseChildren = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChooseChildrenSaveChangesBtn = new System.Windows.Forms.Button();
            this.ChooseChildrenAll = new System.Windows.Forms.CheckBox();
            this.ClearPartnersHistoryBtn = new System.Windows.Forms.Button();
            this.MemberTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartnerListBox
            // 
            this.PartnerListBox.FormattingEnabled = true;
            this.PartnerListBox.HorizontalScrollbar = true;
            this.PartnerListBox.Location = new System.Drawing.Point(12, 77);
            this.PartnerListBox.Name = "PartnerListBox";
            this.PartnerListBox.ScrollAlwaysVisible = true;
            this.PartnerListBox.Size = new System.Drawing.Size(368, 95);
            this.PartnerListBox.TabIndex = 0;
            // 
            // StatusListBox
            // 
            this.StatusListBox.FormattingEnabled = true;
            this.StatusListBox.Location = new System.Drawing.Point(386, 77);
            this.StatusListBox.Name = "StatusListBox";
            this.StatusListBox.ScrollAlwaysVisible = true;
            this.StatusListBox.Size = new System.Drawing.Size(173, 95);
            this.StatusListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Partners";
            // 
            // PartnersComboBox
            // 
            this.PartnersComboBox.FormattingEnabled = true;
            this.PartnersComboBox.Location = new System.Drawing.Point(669, 313);
            this.PartnersComboBox.Name = "PartnersComboBox";
            this.PartnersComboBox.Size = new System.Drawing.Size(189, 21);
            this.PartnersComboBox.TabIndex = 4;
            // 
            // SinceDateTimePicker
            // 
            this.SinceDateTimePicker.Location = new System.Drawing.Point(520, 253);
            this.SinceDateTimePicker.Name = "SinceDateTimePicker";
            this.SinceDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.SinceDateTimePicker.TabIndex = 6;
            this.SinceDateTimePicker.ValueChanged += new System.EventHandler(this.SinceDateTimePickerOnChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Since:";
            // 
            // GotMarriedBtn
            // 
            this.GotMarriedBtn.Enabled = false;
            this.GotMarriedBtn.Location = new System.Drawing.Point(520, 329);
            this.GotMarriedBtn.Name = "GotMarriedBtn";
            this.GotMarriedBtn.Size = new System.Drawing.Size(143, 23);
            this.GotMarriedBtn.TabIndex = 11;
            this.GotMarriedBtn.Text = "Got married";
            this.GotMarriedBtn.UseVisualStyleBackColor = true;
            this.GotMarriedBtn.Click += new System.EventHandler(this.GotMarriedBtnOnClick);
            // 
            // button4
            // 
            this.button4.CausesValidation = false;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Location = new System.Drawing.Point(849, 481);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Ok";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // WithPartnerBtn
            // 
            this.WithPartnerBtn.Enabled = false;
            this.WithPartnerBtn.Location = new System.Drawing.Point(520, 300);
            this.WithPartnerBtn.Name = "WithPartnerBtn";
            this.WithPartnerBtn.Size = new System.Drawing.Size(143, 23);
            this.WithPartnerBtn.TabIndex = 19;
            this.WithPartnerBtn.Text = "With partner";
            this.WithPartnerBtn.UseVisualStyleBackColor = true;
            this.WithPartnerBtn.Click += new System.EventHandler(this.WithPartnerBtnOnClick);
            // 
            // WithoutPartnerBtn
            // 
            this.WithoutPartnerBtn.Enabled = false;
            this.WithoutPartnerBtn.Location = new System.Drawing.Point(669, 433);
            this.WithoutPartnerBtn.Name = "WithoutPartnerBtn";
            this.WithoutPartnerBtn.Size = new System.Drawing.Size(143, 23);
            this.WithoutPartnerBtn.TabIndex = 20;
            this.WithoutPartnerBtn.Text = "Without partner";
            this.WithoutPartnerBtn.UseVisualStyleBackColor = true;
            this.WithoutPartnerBtn.Click += new System.EventHandler(this.WithoutPartnerBtnOnClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(616, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Full names";
            // 
            // FullNamesListBox
            // 
            this.FullNamesListBox.FormattingEnabled = true;
            this.FullNamesListBox.Location = new System.Drawing.Point(619, 77);
            this.FullNamesListBox.Name = "FullNamesListBox";
            this.FullNamesListBox.ScrollAlwaysVisible = true;
            this.FullNamesListBox.Size = new System.Drawing.Size(305, 95);
            this.FullNamesListBox.TabIndex = 21;
            this.FullNamesListBox.SelectedIndexChanged += new System.EventHandler(this.FullNamesListBoxOnSelect);
            // 
            // ChangedFullNameBtn
            // 
            this.ChangedFullNameBtn.Location = new System.Drawing.Point(520, 380);
            this.ChangedFullNameBtn.Name = "ChangedFullNameBtn";
            this.ChangedFullNameBtn.Size = new System.Drawing.Size(143, 23);
            this.ChangedFullNameBtn.TabIndex = 23;
            this.ChangedFullNameBtn.Text = "Changed full name";
            this.ChangedFullNameBtn.UseVisualStyleBackColor = true;
            this.ChangedFullNameBtn.Click += new System.EventHandler(this.ChangedFullNameBtnOnClick);
            // 
            // FullNameTxtBox
            // 
            this.FullNameTxtBox.Location = new System.Drawing.Point(669, 380);
            this.FullNameTxtBox.Name = "FullNameTxtBox";
            this.FullNameTxtBox.Size = new System.Drawing.Size(189, 20);
            this.FullNameTxtBox.TabIndex = 24;
            // 
            // RemoveSelectedFullNameBtn
            // 
            this.RemoveSelectedFullNameBtn.Enabled = false;
            this.RemoveSelectedFullNameBtn.Location = new System.Drawing.Point(799, 178);
            this.RemoveSelectedFullNameBtn.Name = "RemoveSelectedFullNameBtn";
            this.RemoveSelectedFullNameBtn.Size = new System.Drawing.Size(125, 23);
            this.RemoveSelectedFullNameBtn.TabIndex = 25;
            this.RemoveSelectedFullNameBtn.Text = "Remove selected";
            this.RemoveSelectedFullNameBtn.UseVisualStyleBackColor = true;
            this.RemoveSelectedFullNameBtn.Click += new System.EventHandler(this.RemoveSelectedFullNameBtnOnClick);
            // 
            // GotUnmarriedBtn
            // 
            this.GotUnmarriedBtn.Enabled = false;
            this.GotUnmarriedBtn.Location = new System.Drawing.Point(520, 433);
            this.GotUnmarriedBtn.Name = "GotUnmarriedBtn";
            this.GotUnmarriedBtn.Size = new System.Drawing.Size(143, 23);
            this.GotUnmarriedBtn.TabIndex = 28;
            this.GotUnmarriedBtn.Text = "Got unmarried";
            this.GotUnmarriedBtn.UseVisualStyleBackColor = true;
            this.GotUnmarriedBtn.Click += new System.EventHandler(this.WithoutPartnerBtnOnClick);
            // 
            // ChooseChildren
            // 
            this.ChooseChildren.FormattingEnabled = true;
            this.ChooseChildren.Items.AddRange(new object[] {
            "generated at runtime"});
            this.ChooseChildren.Location = new System.Drawing.Point(12, 273);
            this.ChooseChildren.Name = "ChooseChildren";
            this.ChooseChildren.Size = new System.Drawing.Size(368, 154);
            this.ChooseChildren.TabIndex = 36;
            this.ChooseChildren.SelectedIndexChanged += new System.EventHandler(this.ChooseChildrenOnSelect);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "Children";
            // 
            // ChooseChildrenSaveChangesBtn
            // 
            this.ChooseChildrenSaveChangesBtn.Enabled = false;
            this.ChooseChildrenSaveChangesBtn.Location = new System.Drawing.Point(273, 433);
            this.ChooseChildrenSaveChangesBtn.Name = "ChooseChildrenSaveChangesBtn";
            this.ChooseChildrenSaveChangesBtn.Size = new System.Drawing.Size(107, 23);
            this.ChooseChildrenSaveChangesBtn.TabIndex = 39;
            this.ChooseChildrenSaveChangesBtn.Text = "Save changes";
            this.ChooseChildrenSaveChangesBtn.UseVisualStyleBackColor = true;
            this.ChooseChildrenSaveChangesBtn.Click += new System.EventHandler(this.ChooseChildrenSaveChangesBtnOnClick);
            // 
            // ChooseChildrenAll
            // 
            this.ChooseChildrenAll.AutoSize = true;
            this.ChooseChildrenAll.Location = new System.Drawing.Point(268, 254);
            this.ChooseChildrenAll.Name = "ChooseChildrenAll";
            this.ChooseChildrenAll.Size = new System.Drawing.Size(112, 17);
            this.ChooseChildrenAll.TabIndex = 40;
            this.ChooseChildrenAll.Text = "select/unselect all";
            this.ChooseChildrenAll.UseVisualStyleBackColor = true;
            this.ChooseChildrenAll.CheckedChanged += new System.EventHandler(this.ChooseChildrenAllOnChange);
            // 
            // ClearPartnersHistoryBtn
            // 
            this.ClearPartnersHistoryBtn.Location = new System.Drawing.Point(292, 178);
            this.ClearPartnersHistoryBtn.Name = "ClearPartnersHistoryBtn";
            this.ClearPartnersHistoryBtn.Size = new System.Drawing.Size(88, 23);
            this.ClearPartnersHistoryBtn.TabIndex = 41;
            this.ClearPartnersHistoryBtn.Text = "Clear history";
            this.ClearPartnersHistoryBtn.UseVisualStyleBackColor = true;
            this.ClearPartnersHistoryBtn.Click += new System.EventHandler(this.ClearPartnersHistoryBtnOnClick);
            // 
            // MemberTitle
            // 
            this.MemberTitle.AutoSize = true;
            this.MemberTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberTitle.Location = new System.Drawing.Point(12, 9);
            this.MemberTitle.Name = "MemberTitle";
            this.MemberTitle.Size = new System.Drawing.Size(166, 20);
            this.MemberTitle.TabIndex = 42;
            this.MemberTitle.Text = "Changes at runtime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Partner change:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Name change:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Status change:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Status change:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 438);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "(Spouse/common children are set implicitely)";
            // 
            // MemberEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 516);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MemberTitle);
            this.Controls.Add(this.ClearPartnersHistoryBtn);
            this.Controls.Add(this.ChooseChildrenAll);
            this.Controls.Add(this.ChooseChildrenSaveChangesBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ChooseChildren);
            this.Controls.Add(this.GotUnmarriedBtn);
            this.Controls.Add(this.RemoveSelectedFullNameBtn);
            this.Controls.Add(this.FullNameTxtBox);
            this.Controls.Add(this.ChangedFullNameBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FullNamesListBox);
            this.Controls.Add(this.WithoutPartnerBtn);
            this.Controls.Add(this.WithPartnerBtn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.GotMarriedBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SinceDateTimePicker);
            this.Controls.Add(this.PartnersComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusListBox);
            this.Controls.Add(this.PartnerListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MemberEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Family tree tools - edit member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PartnerListBox;
        private System.Windows.Forms.ListBox StatusListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PartnersComboBox;
        private System.Windows.Forms.DateTimePicker SinceDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GotMarriedBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button WithPartnerBtn;
        private System.Windows.Forms.Button WithoutPartnerBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox FullNamesListBox;
        private System.Windows.Forms.Button ChangedFullNameBtn;
        private System.Windows.Forms.TextBox FullNameTxtBox;
        private System.Windows.Forms.Button RemoveSelectedFullNameBtn;
        private System.Windows.Forms.Button GotUnmarriedBtn;
        private System.Windows.Forms.CheckedListBox ChooseChildren;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ChooseChildrenSaveChangesBtn;
        private System.Windows.Forms.CheckBox ChooseChildrenAll;
        private System.Windows.Forms.Button ClearPartnersHistoryBtn;
        private System.Windows.Forms.Label MemberTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}