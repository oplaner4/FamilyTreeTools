using System;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using FamilyTreeTools.Properties;

namespace FamilyTreeTools
{
    public partial class MemberAddDialog : Form
    {
        public Family SourceFamily { get; set; }

        public Member OutMember { get; private set; }

        public MemberAddDialog(Family sourceFamily)
        {
            InitializeComponent();
            SourceFamily = sourceFamily;
            Icon = Resources.favicon;
            DeathDate.MaxDate = DateTime.Now;
            BirthDate.MaxDate = DateTime.Now;
        }

        private void MemberSaveOnClick(object sender, EventArgs e)
        {
            if (!ValidateInputs()) {
                return;
            };

            OutMember = new Member(BirthFullName.Text, BirthDate.Value);
            if (DeathDate.Checked)
            {
                OutMember.Died(DeathDate.Value);
            }

            DialogResult = DialogResult.OK;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(BirthFullName.Text))
            {
                BirthFullName.Focus();
                return false;
            }

            if (DeathDate.Checked && BirthDate.Value >= DeathDate.Value)
            {
                DeathDate.Focus();
                return false;
            }

            return true;
        }
    }
}
