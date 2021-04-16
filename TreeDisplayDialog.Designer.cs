
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
            this.AtLabelValue = new System.Windows.Forms.Label();
            this.AnimationAddDays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AnimationInterval = new System.Windows.Forms.NumericUpDown();
            this.AnimationRunningValue = new System.Windows.Forms.CheckBox();
            this.EventsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAddDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // WithLabelsCheckbox
            // 
            this.WithLabelsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WithLabelsCheckbox.AutoSize = true;
            this.WithLabelsCheckbox.Location = new System.Drawing.Point(768, 11);
            this.WithLabelsCheckbox.Name = "WithLabelsCheckbox";
            this.WithLabelsCheckbox.Size = new System.Drawing.Size(78, 17);
            this.WithLabelsCheckbox.TabIndex = 6;
            this.WithLabelsCheckbox.Text = "With labels";
            this.WithLabelsCheckbox.UseVisualStyleBackColor = true;
            this.WithLabelsCheckbox.CheckedChanged += new System.EventHandler(this.WithLabelsCheckboxOnChange);
            // 
            // AtLabelValue
            // 
            this.AtLabelValue.AutoSize = true;
            this.AtLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtLabelValue.Location = new System.Drawing.Point(12, 7);
            this.AtLabelValue.Name = "AtLabelValue";
            this.AtLabelValue.Size = new System.Drawing.Size(99, 20);
            this.AtLabelValue.TabIndex = 7;
            this.AtLabelValue.Text = "00.00.0000";
            // 
            // AnimationAddDays
            // 
            this.AnimationAddDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationAddDays.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AnimationAddDays.Location = new System.Drawing.Point(596, 8);
            this.AnimationAddDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.AnimationAddDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AnimationAddDays.Name = "AnimationAddDays";
            this.AnimationAddDays.Size = new System.Drawing.Size(44, 20);
            this.AnimationAddDays.TabIndex = 8;
            this.AnimationAddDays.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Animation add days:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Animation interval (seconds):";
            // 
            // AnimationInterval
            // 
            this.AnimationInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationInterval.Location = new System.Drawing.Point(444, 8);
            this.AnimationInterval.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.AnimationInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AnimationInterval.Name = "AnimationInterval";
            this.AnimationInterval.Size = new System.Drawing.Size(42, 20);
            this.AnimationInterval.TabIndex = 10;
            this.AnimationInterval.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.AnimationInterval.ValueChanged += new System.EventHandler(this.AnimationIntervalOnChange);
            // 
            // AnimationRunningValue
            // 
            this.AnimationRunningValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationRunningValue.AutoSize = true;
            this.AnimationRunningValue.Location = new System.Drawing.Point(649, 10);
            this.AnimationRunningValue.Name = "AnimationRunningValue";
            this.AnimationRunningValue.Size = new System.Drawing.Size(110, 17);
            this.AnimationRunningValue.TabIndex = 13;
            this.AnimationRunningValue.Text = "Animation running";
            this.AnimationRunningValue.UseVisualStyleBackColor = true;
            this.AnimationRunningValue.CheckedChanged += new System.EventHandler(this.AnimationRunningValueOnChange);
            // 
            // EventsListBox
            // 
            this.EventsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventsListBox.FormattingEnabled = true;
            this.EventsListBox.ItemHeight = 16;
            this.EventsListBox.Items.AddRange(new object[] {
            "Changes at runtime"});
            this.EventsListBox.Location = new System.Drawing.Point(0, 734);
            this.EventsListBox.Name = "EventsListBox";
            this.EventsListBox.ScrollAlwaysVisible = true;
            this.EventsListBox.Size = new System.Drawing.Size(868, 68);
            this.EventsListBox.TabIndex = 14;
            // 
            // TreeDisplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 804);
            this.Controls.Add(this.EventsListBox);
            this.Controls.Add(this.AnimationRunningValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AnimationInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnimationAddDays);
            this.Controls.Add(this.AtLabelValue);
            this.Controls.Add(this.WithLabelsCheckbox);
            this.Name = "TreeDisplayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Family tree tools - display tree";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TreeDisplayDialogOnClose);
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAddDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox WithLabelsCheckbox;
        private System.Windows.Forms.Label AtLabelValue;
        private System.Windows.Forms.NumericUpDown AnimationAddDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown AnimationInterval;
        private System.Windows.Forms.CheckBox AnimationRunningValue;
        private System.Windows.Forms.ListBox EventsListBox;
    }
}