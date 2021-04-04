using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilyTreeTools.Entities;
using FamilyTreeTools.Entities.Exceptions;
using FamilyTreeTools.Properties;

namespace FamilyTreeTools
{
    public partial class MemberAddDialog : Form
    {
        public Family SourceFamily { get; set; }

        public Member SourceMember { get; set; }
        private IEnumerable<Member> EnumerableMembers { get; set; }

        public MemberAddDialog(Family sourceFamily)
        {
            InitializeComponent();
            SourceFamily = sourceFamily;
            Icon = Resources.favicon;
            Text = "Family tree tools - add member";
            UpdateChooseChildren(false);
            EnumerableMembers = SourceFamily.Members.Values;
        }


        private void UpdateChooseChildren (bool selectAll)
        {
            ChooseChildren.Items.Clear();

            foreach (Member child in SourceFamily.Members.Values)
            {
                ChooseChildren.Items.Add(child, selectAll);
            }
        }

        private void KnownDeathDateOnChange(object sender, EventArgs e)
        {
            DeathDate.Enabled = KnownDeathDate.Checked;
        }

        private void MemberSaveOnClick(object sender, EventArgs e)
        {
            try
            {
                SourceMember = new Member(BirthFullName.Text, BirthDate.Value);
                if (KnownDeathDate.Checked)
                {
                    SourceMember.Died(DeathDate.Value);
                }

                foreach (int i in ChooseChildren.SelectedIndices)
                {
                    SourceMember.HadChild(EnumerableMembers.ElementAt(i));
                }


                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (new ValidationFailedDialog(ex.Message).ShowDialog() == DialogResult.OK)
                {
                    UpdateChooseChildren(false);
                    return;
                }
            }
        }

        private void ChooseChildrenAllOnChange(object sender, EventArgs e)
        {
            UpdateChooseChildren(ChooseChildrenAll.Checked);
        }
    }
}
