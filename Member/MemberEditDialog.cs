using FamilyTreeTools.Entities;
using FamilyTreeTools.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class MemberEditDialog : Form
    {
        public Member SourceMember { get; private set; }

        public Family SourceFamily { get; private set; }

        private IEnumerable<Member> EnumerablePartners { get; set; }
        private IEnumerable<KeyValuePair<DateTime, Human.StatusOptions>> EnumerableStatusesHistory { get; set; }
        private IEnumerable<KeyValuePair<DateTime, Member>> EnumerablePartnersHistory { get; set; }
        private IEnumerable<KeyValuePair<DateTime, string>> EnumerableFullNamesHistory { get; set; }

        public DateTime SinceDateTime { get; set; }

        public IEnumerable<Member> EnumerableOwnChildren { get; private set; }
        public IEnumerable<Member> EnumerableChildren { get; private set; }

        public MemberEditDialog(Family sourceFamily, Member sourceMember)
        {
            SourceMember = sourceMember;
            SourceFamily = sourceFamily;
            InitializeComponent();
            Icon = Resources.favicon;
            Initialize();
        }

        private void Initialize()
        {
            SinceDateTime = DateTime.Now;
            SinceDateTimePicker.MinDate = SourceMember.BirthDate;
            SinceDateTimePicker.MaxDate = SinceDateTime;
            MemberTitle.Text = SourceMember.ToString();

            UpdatePartnersComboBox();
            UpdatePartnersListBox();
            UpdateStatusesListBox();
            UpdateFullNamesListBox();
            UpdateChooseChildren();
            UpdateButtons();
        }

        private void UpdateChooseChildren(bool? selectAll = null)
        {
            ChooseChildren.Items.Clear();

            EnumerableOwnChildren = SourceFamily.GetEnumerableMembers().Where(m => m.Refs.ParentId == SourceMember.Id);
            EnumerableChildren = SourceFamily.GetEnumerableMembers().Where(
                m => m.Id != SourceMember.Id
                    && m.BirthDate >= SourceMember.BirthDate
                    && m.Refs.Parent == null
                    && !SourceMember.Refs.Partner.Changes.Values.Any(p => p != null && p.Id == m.Id)
            );

            if (EnumerableChildren.Any() || EnumerableOwnChildren.Any())
            {
                foreach (Member child in EnumerableOwnChildren)
                {
                    ChooseChildren.Items.Add(child, selectAll ?? true);
                }

                foreach (Member child in EnumerableChildren)
                {
                    ChooseChildren.Items.Add(child, selectAll ?? false);
                }
            }
            else
            {
                ChooseChildren.Items.Add("No available members. Add children of this member at first.", CheckState.Indeterminate);
            }
        }

        private void UpdatePartnersComboBox()
        {
            EnumerablePartners = SourceFamily.GetEnumerableMembers().Where(
                m => m.Id != SourceMember.Id
                && m.BirthDate <= SinceDateTime
                && (m.DeathDate == null || SinceDateTime <= m.DeathDate)
                && !m.Refs.PartnerId.Value(SinceDateTime).HasValue
            ).OrderBy(m => m.BirthDate - SourceMember.BirthDate);

            PartnersComboBox.Items.Clear();

            if (SourceMember.HadPartner(SinceDateTime))
            {
                PartnersComboBox.Items.Add("The partner that time");
            }
            else
            {
                PartnersComboBox.Items.Add("No partner selected");
            }

            PartnersComboBox.SelectedIndex = 0;

            foreach (Member member in EnumerablePartners)
            {
                PartnersComboBox.Items.Add(member);
            }
        }

        private void UpdatePartnersListBox()
        {
            EnumerablePartnersHistory = SourceMember.Refs.Partner.Changes.OrderBy(ch => ch.Key);
            PartnerListBox.Items.Clear();

            foreach (KeyValuePair<DateTime, Member> change in EnumerablePartnersHistory)
            {
                PartnerListBox.Items.Add(
                    string.Format(
                        "since {0}: {1}",
                        change.Key.ToString("dd/MM/yyyy"),
                        change.Value == null ? "without" : change.Value.ToString()
                    )
                );
            }
        }

        private void UpdateStatusesListBox()
        {
            EnumerableStatusesHistory = SourceMember.Status.Changes.OrderBy(ch => ch.Key);
            StatusListBox.Items.Clear();

            foreach (KeyValuePair<DateTime, Human.StatusOptions> change in EnumerableStatusesHistory)
            {
                StatusListBox.Items.Add(
                    string.Format(
                        "since {0}: {1}",
                        change.Key.ToString("dd/MM/yyyy"),
                        change.Value.ToString()
                    )
                );
            }
        }

        private void UpdateFullNamesListBox()
        {
            EnumerableFullNamesHistory = SourceMember.FullName.Changes.OrderBy(ch => ch.Key);
            FullNamesListBox.Items.Clear();

            foreach (KeyValuePair<DateTime, string> change in EnumerableFullNamesHistory)
            {
                FullNamesListBox.Items.Add(
                    string.Format(
                        "since {0}: {1}",
                        change.Key.ToString("dd/MM/yyyy"),
                        change.Value
                    )
                );
            }
        }

        private void UpdateButtons()
        {
            WithoutPartnerBtn.Enabled = SourceMember.HadPartner(SinceDateTime);
            GotUnmarriedBtn.Enabled = SourceMember.WasMarried(SinceDateTime);
            GotMarriedBtn.Enabled = !GotUnmarriedBtn.Enabled && (
                EnumerablePartners.Any() || SourceMember.HadPartner(SinceDateTime)
            );
            WithPartnerBtn.Enabled = !WithoutPartnerBtn.Enabled && EnumerablePartners.Any();
            ClearPartnersHistoryBtn.Enabled = EnumerablePartnersHistory.Count() > 1;
            RemoveSelectedFullNameBtn.Enabled = FullNamesListBox.SelectedIndex > 0;
        }

        private void WithPartnerBtnOnClick(object sender, EventArgs e)
        {
            if (PartnersComboBox.SelectedIndex < 1)
            {
                PartnersComboBox.Focus();
                return;
            }

            try
            {
                SourceMember.WithPartner(
                    EnumerablePartners.ElementAt(PartnersComboBox.SelectedIndex - 1),
                    SinceDateTimePicker.Value
                );
                UpdatePartnersListBox();
                UpdatePartnersComboBox();
                UpdateButtons();
                SinceDateTimePicker.Focus();
            }
            catch (Exception ex)
            {
                if (new ValidationFailedDialog(ex.Message).ShowDialog() == DialogResult.OK)
                {
                    PartnersComboBox.Focus();
                }
            }

        }

        private void ChangedFullNameBtnOnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FullNameTxtBox.Text))
            {
                FullNameTxtBox.Focus();
                return;
            }

            SourceMember.ChangedFullName(
                FullNameTxtBox.Text,
                SinceDateTimePicker.Value
            );

            UpdateFullNamesListBox();
            SinceDateTimePicker.Focus();
        }

        private void WithoutPartnerBtnOnClick(object sender, EventArgs e)
        {
            try
            {
                SourceMember.WithoutPartner(SinceDateTimePicker.Value);
                UpdatePartnersListBox();
                UpdateStatusesListBox();
                UpdatePartnersComboBox();
                UpdateButtons();
            }
            catch (Exception ex)
            {
                if (new ValidationFailedDialog(ex.Message).ShowDialog() == DialogResult.OK)
                {
                    SinceDateTimePicker.Focus();
                }
            }
        }

        private void GotMarriedBtnOnClick(object sender, EventArgs e)
        {
            if (PartnersComboBox.SelectedIndex == -1 || (
                PartnersComboBox.SelectedIndex == 0
                    && !SourceMember.HadPartner(SinceDateTime)
            ))
            {
                PartnersComboBox.Focus();
                return;
            }

            try
            {
                SourceMember.GotMarried(
                    SinceDateTimePicker.Value,
                    PartnersComboBox.SelectedIndex > 0 ?
                        EnumerablePartners.ElementAt(PartnersComboBox.SelectedIndex - 1)
                        :
                        null
                );

                UpdatePartnersListBox();
                UpdateStatusesListBox();
                UpdatePartnersComboBox();
                UpdateButtons();
                SinceDateTimePicker.Focus();
            }
            catch (Exception ex)
            {
                if (new ValidationFailedDialog(ex.Message).ShowDialog() == DialogResult.OK)
                {
                    PartnersComboBox.Focus();
                }
            }
        }

        private void RemoveSelectedFullNameBtnOnClick(object sender, EventArgs e)
        {
            SourceMember.FullName.Changes.Remove(
                EnumerableFullNamesHistory.ElementAt(FullNamesListBox.SelectedIndex).Key
            );

            UpdateFullNamesListBox();
        }

        private void SinceDateTimePickerOnChange(object sender, EventArgs e)
        {
            SinceDateTime = SinceDateTimePicker.Value;
            UpdatePartnersComboBox();
            UpdateButtons();
        }

        private void FullNamesListBoxOnSelect(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void ChooseChildrenSaveChangesBtnOnClick(object sender, EventArgs e)
        {
            if (EnumerableChildren.Any() || EnumerableOwnChildren.Any())
            {
                EnumerableOwnChildren = EnumerableOwnChildren.ToArray();

                for (int i = 0; i < EnumerableOwnChildren.Count(); i++)
                {
                    if (!ChooseChildren.CheckedIndices.Contains(i))
                    {
                        SourceMember.Refs.RemoveChild(EnumerableOwnChildren.ElementAt(i));
                    }
                }

                try
                {
                    EnumerableChildren = EnumerableChildren.ToArray();

                    foreach (int i in ChooseChildren.CheckedIndices)
                    {
                        if (i >= EnumerableOwnChildren.Count())
                        {
                            SourceMember.HadChild(EnumerableChildren.ElementAt(
                                i - EnumerableOwnChildren.Count()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (new ValidationFailedDialog(ex.Message).ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }

            UpdateChooseChildren();
            ChooseChildrenSaveChangesBtn.Enabled = false;
        }

        private void ChooseChildrenAllOnChange(object sender, EventArgs e)
        {
            UpdateChooseChildren(ChooseChildrenAll.Checked);
            ChooseChildrenSaveChangesBtn.Enabled = true;
            UpdateButtons();
        }

        private void ChooseChildrenOnSelect(object sender, EventArgs e)
        {
            ChooseChildrenSaveChangesBtn.Enabled = true;
        }

        private void ClearPartnersHistoryBtnOnClick(object sender, EventArgs e)
        {
            if (new DestructiveConfirmDialog().ShowDialog() == DialogResult.OK)
            {
                SourceMember.Refs.ClearPartnersHistory();
                UpdatePartnersListBox();
                UpdateStatusesListBox();
                UpdatePartnersComboBox();
                UpdateButtons();
            }
        }
    }
}
