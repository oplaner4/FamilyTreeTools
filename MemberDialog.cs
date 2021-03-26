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
using FamilyTreeTools.Properties;

namespace FamilyTreeTools
{
    public partial class MemberDialog : Form
    {
        public Member SourceMember { get; set; }

        public MemberDialog(Member sourceMember = null)
        {
            InitializeComponent();
            SourceMember = sourceMember;
            Icon = Resources.favicon;

            if (sourceMember == null)
            {
                Text = "Family tree tools - new member";
            }
            else
            {
                Text = "Family tree tools - edit member";
            }
        }


    }
}
