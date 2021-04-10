using FamilyTreeTools.Entities;
using FamilyTreeTools.Properties;
using System;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class EditSettingsDialog : Form
    {
        public SearchSettings Settings { get; private set; }

        public EditSettingsDialog(SearchSettings settings)
        {
            InitializeComponent();
            Icon = Resources.favicon;
            Settings = settings;
            Initialize();
        }

        private void Initialize()
        {
            AtDatetimePicker.MaxDate = DateTime.Now;
            CanBeDeadValue.Checked = Settings.CanBeDead;
            CanBeFromFartherGenerationValue.Checked = Settings.CanBeFromFartherGeneration;
            CanBeIllegitimateRelativeValue.Checked = Settings.CanBeIllegitimateRelative;
            AtDatetimePicker.Value = Settings.At;
            IncludePartnersOtherTimeValue.Checked = Settings.CanBePartnerOtherTime;
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            Settings.At = AtDatetimePicker.Value;
            Settings.CanBeDead = CanBeDeadValue.Checked;
            Settings.CanBeFromFartherGeneration = CanBeFromFartherGenerationValue.Checked;
            Settings.CanBeIllegitimateRelative = CanBeIllegitimateRelativeValue.Checked;
            Settings.CanBePartnerOtherTime = IncludePartnersOtherTimeValue.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}
