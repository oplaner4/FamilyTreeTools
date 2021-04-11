using FamilyTreeTools.Properties;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class UnsavedConfirmDialog : Form
    {
        public UnsavedConfirmDialog()
        {
            InitializeComponent();
            Icon = Resources.favicon;
        }
    }
}
