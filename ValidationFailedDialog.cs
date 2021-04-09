using FamilyTreeTools.Properties;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class ValidationFailedDialog : Form
    {
        public ValidationFailedDialog(string message)
        {
            InitializeComponent();
            Icon = Resources.favicon;
            MessageBox.Text = message;
        }
    }
}
