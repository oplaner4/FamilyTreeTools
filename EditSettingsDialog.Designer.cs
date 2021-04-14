
namespace FamilyTreeTools
{
    partial class EditSettingsDialog
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CanBeDeadValue = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CanBeFromFartherGenerationValue = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CanBeIllegitimateRelativeValue = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IncludePartnersOtherTimeValue = new System.Windows.Forms.CheckBox();
            this.AtDatetimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DateIncreaseBtn = new System.Windows.Forms.Button();
            this.DateDecreaseBtn = new System.Windows.Forms.Button();
            this.DateChange = new System.Windows.Forms.NumericUpDown();
            this.DateUnitComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DateChange)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(496, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CanBeDeadValue
            // 
            this.CanBeDeadValue.AutoSize = true;
            this.CanBeDeadValue.Location = new System.Drawing.Point(260, 104);
            this.CanBeDeadValue.Name = "CanBeDeadValue";
            this.CanBeDeadValue.Size = new System.Drawing.Size(15, 14);
            this.CanBeDeadValue.TabIndex = 5;
            this.CanBeDeadValue.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Can be dead";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Can be from farther generation";
            // 
            // CanBeFromFartherGenerationValue
            // 
            this.CanBeFromFartherGenerationValue.AutoSize = true;
            this.CanBeFromFartherGenerationValue.Location = new System.Drawing.Point(260, 136);
            this.CanBeFromFartherGenerationValue.Name = "CanBeFromFartherGenerationValue";
            this.CanBeFromFartherGenerationValue.Size = new System.Drawing.Size(15, 14);
            this.CanBeFromFartherGenerationValue.TabIndex = 7;
            this.CanBeFromFartherGenerationValue.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Can be an illegitimate relative";
            // 
            // CanBeIllegitimateRelativeValue
            // 
            this.CanBeIllegitimateRelativeValue.AutoSize = true;
            this.CanBeIllegitimateRelativeValue.Location = new System.Drawing.Point(260, 169);
            this.CanBeIllegitimateRelativeValue.Name = "CanBeIllegitimateRelativeValue";
            this.CanBeIllegitimateRelativeValue.Size = new System.Drawing.Size(15, 14);
            this.CanBeIllegitimateRelativeValue.TabIndex = 9;
            this.CanBeIllegitimateRelativeValue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date at";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Can be partner at another time";
            // 
            // IncludePartnersOtherTimeValue
            // 
            this.IncludePartnersOtherTimeValue.AutoSize = true;
            this.IncludePartnersOtherTimeValue.Location = new System.Drawing.Point(260, 202);
            this.IncludePartnersOtherTimeValue.Name = "IncludePartnersOtherTimeValue";
            this.IncludePartnersOtherTimeValue.Size = new System.Drawing.Size(15, 14);
            this.IncludePartnersOtherTimeValue.TabIndex = 13;
            this.IncludePartnersOtherTimeValue.UseVisualStyleBackColor = true;
            // 
            // AtDatetimePicker
            // 
            this.AtDatetimePicker.Location = new System.Drawing.Point(260, 34);
            this.AtDatetimePicker.Name = "AtDatetimePicker";
            this.AtDatetimePicker.Size = new System.Drawing.Size(158, 20);
            this.AtDatetimePicker.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "(look also for dead members)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "(go deep: children of children, parents of parents)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "(look also for relatives of unmarried partner)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "(look for relatives using this date)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "(without any ancestor)";
            // 
            // DateIncreaseBtn
            // 
            this.DateIncreaseBtn.Location = new System.Drawing.Point(551, 53);
            this.DateIncreaseBtn.Name = "DateIncreaseBtn";
            this.DateIncreaseBtn.Size = new System.Drawing.Size(20, 20);
            this.DateIncreaseBtn.TabIndex = 21;
            this.DateIncreaseBtn.Text = "+";
            this.DateIncreaseBtn.UseVisualStyleBackColor = true;
            this.DateIncreaseBtn.Click += new System.EventHandler(this.DateIncreaseBtnOnClick);
            // 
            // DateDecreaseBtn
            // 
            this.DateDecreaseBtn.Location = new System.Drawing.Point(551, 33);
            this.DateDecreaseBtn.Name = "DateDecreaseBtn";
            this.DateDecreaseBtn.Size = new System.Drawing.Size(20, 20);
            this.DateDecreaseBtn.TabIndex = 22;
            this.DateDecreaseBtn.Text = "-";
            this.DateDecreaseBtn.UseVisualStyleBackColor = true;
            this.DateDecreaseBtn.Click += new System.EventHandler(this.DateDecreaseBtnOnClick);
            // 
            // DateChange
            // 
            this.DateChange.Location = new System.Drawing.Point(450, 34);
            this.DateChange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DateChange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DateChange.Name = "DateChange";
            this.DateChange.Size = new System.Drawing.Size(39, 20);
            this.DateChange.TabIndex = 23;
            this.DateChange.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // DateUnitComboBox
            // 
            this.DateUnitComboBox.FormattingEnabled = true;
            this.DateUnitComboBox.Items.AddRange(new object[] {
            "Year",
            "Month",
            "Day"});
            this.DateUnitComboBox.Location = new System.Drawing.Point(491, 33);
            this.DateUnitComboBox.Name = "DateUnitComboBox";
            this.DateUnitComboBox.Size = new System.Drawing.Size(54, 21);
            this.DateUnitComboBox.TabIndex = 24;
            // 
            // EditSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 289);
            this.Controls.Add(this.DateUnitComboBox);
            this.Controls.Add(this.DateChange);
            this.Controls.Add(this.DateDecreaseBtn);
            this.Controls.Add(this.DateIncreaseBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AtDatetimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IncludePartnersOtherTimeValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CanBeIllegitimateRelativeValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CanBeFromFartherGenerationValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CanBeDeadValue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Family tree tools - edit settings";
            ((System.ComponentModel.ISupportInitialize)(this.DateChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CanBeDeadValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CanBeFromFartherGenerationValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CanBeIllegitimateRelativeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox IncludePartnersOtherTimeValue;
        private System.Windows.Forms.DateTimePicker AtDatetimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button DateIncreaseBtn;
        private System.Windows.Forms.Button DateDecreaseBtn;
        private System.Windows.Forms.NumericUpDown DateChange;
        private System.Windows.Forms.ComboBox DateUnitComboBox;
    }
}