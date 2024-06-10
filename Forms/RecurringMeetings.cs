using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokningsProgram.Forms
{
    public partial class RecurringMeetings : Form
    {
        private MeetingManager _mm;
        private SSKmanager _sm;
        private Meeting _newMeeting;

        public MeetingManager MeetingManager
        {
            get { return _mm; }
            set { _mm = value; }
        }

        public RecurringMeetings(SSKmanager sm, MeetingManager mm)
        {
            InitializeComponent();
            _sm = sm;
            _mm = mm;
            initializeGUI();
        }
        private void initializeGUI()
        {
            lbMeetings.DisplayMember = "NameOfMeeting";
            UpdateMeetings();
            UpdateGUI();
            lbAvailableSSK.DataSource = _sm.ListOfSSK;
            _newMeeting = new Meeting();
            dtpTimeOfMeeting.CustomFormat = "HH:mm";
            dtpTimeOfMeeting.ShowUpDown = true;

            DateTime date = DateTime.Today;
            dtpTimeOfMeeting.Value = new DateTime(date.Year, date.Month, date.Day, 10, 0, 0);
        }
        private void UpdateGUI()
        {
            if (lbMeetings.SelectedIndex != -1 )
            {
                lbSelectedSSK.Items.Clear();
                Meeting selectedMeeting = (Meeting)lbMeetings.SelectedItem;
                foreach (var ssk in selectedMeeting.NamesOfSSK)
                {
                    lbSelectedSSK.Items.Add(ssk);
                }
            }
        }
        private void UpdateMeetings()
        {
            lbMeetings.Items.Clear();
            foreach (var meeting in _mm.ListOfMeetings)
            {
                lbMeetings.Items.Add(meeting);
            }
        }
        private void btnAddMeeting_Click(object sender, EventArgs e)
        {
            bool ok = CreateMeeting();
            if (ok)
            {
                _mm.AddMeeting(_newMeeting);
                _newMeeting = new Meeting();
            }
            UpdateMeetings();
        }

        private void btnAddSelectedSSK_Click(object sender, EventArgs e)
        {
            if (lbMeetings.SelectedIndex != -1)
            {
                Meeting selectedMeeting = (Meeting)lbMeetings.SelectedItem;
                if (lbAvailableSSK.SelectedIndex != -1)
                {
                    SSK availableSSK = (SSK)lbAvailableSSK.SelectedItem;
                    if (lbSelectedSSK.Items.Contains(availableSSK.Name))
                        MessageBox.Show("Sköterskan finns redan, välj någon annan");
                    else
                        selectedMeeting.NamesOfSSK.Add(availableSSK.Name);
                }
                else
                    MessageBox.Show("Ingen tillgänglig sköterska vald");
            }
            else
                MessageBox.Show("Inget möte valt");
            UpdateGUI();
        }

        private void btnRemoveSelectedSSK_Click(object sender, EventArgs e)
        {
            if (lbMeetings.SelectedIndex != -1)
            {
                Meeting selectedMeeting = (Meeting)lbMeetings.SelectedItem;
                if (lbSelectedSSK.SelectedIndex != -1)
                {
                    string selectedSSK = (string)lbSelectedSSK.SelectedItem;
                    selectedMeeting.NamesOfSSK.Remove(selectedSSK);
                    var ssk = _sm.GetSSKfromName(selectedSSK);
                    ssk.RemoveMeetingBooking(selectedMeeting.NameOfMeeting);
                }
                else
                    MessageBox.Show("Ingen anmäld sköterska vald");
            }
            else
                MessageBox.Show("Inget möte valt");
            UpdateGUI();
        }

        private void lbAvailableSSK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Meeting tempMeeting = new Meeting(lbMeetings.SelectedItem as Meeting);
            txtNameOfMeeting.Text = tempMeeting.NameOfMeeting;
            txtWeeklyInterval.Text = tempMeeting.Intervall.ToString();
            dtpTimeOfMeeting.Value = tempMeeting.Time;

            UpdateWeekDays(tempMeeting.DayOfWeek);

            UpdateGUI();
        }
        private void UpdateWeekDays(List<DayOfWeek> days)
        {
            foreach (Control control in gbReccurence.Controls)
            {
                // Check if the control is a CheckBox
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
            foreach (DayOfWeek day in days)
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                        cbMonday.Checked = true;
                        break;
                    case DayOfWeek.Tuesday:
                        cbTuesday.Checked = true;
                        break;
                    case DayOfWeek.Wednesday:
                        cbWednesday.Checked = true;
                        break;
                    case DayOfWeek.Thursday:
                        cbThursday.Checked = true;
                        break;
                    case DayOfWeek.Friday:
                        cbFriday.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void GetWeekDay(CheckBox checkBox)
        {
            DayOfWeek dayOfWeek;
            if (checkBox.Text.Equals("Måndag"))
            {
                dayOfWeek = DayOfWeek.Monday;
                _newMeeting.DayOfWeek.Add(dayOfWeek);
            }
            else if (checkBox.Text.Equals("Tisdag"))
            {
                dayOfWeek = DayOfWeek.Monday;
                _newMeeting.DayOfWeek.Add(dayOfWeek);
            }
            else if (checkBox.Text.Equals("Onsdag"))
            {
                dayOfWeek = DayOfWeek.Monday;
                _newMeeting.DayOfWeek.Add(dayOfWeek);
            }
            else if (checkBox.Text.Equals("Torsdag"))
            {
                dayOfWeek = DayOfWeek.Monday;
                _newMeeting.DayOfWeek.Add(dayOfWeek);
            }
            else if (checkBox.Text.Equals("Fredag"))
            {
                dayOfWeek = DayOfWeek.Monday;
                _newMeeting.DayOfWeek.Add(dayOfWeek);
            }
        }
        private bool CreateMeeting()
        {
            _newMeeting = new Meeting();
            bool ok = false;
            bool intervalOK = CheckInput(txtWeeklyInterval.Text, out int interval);
            bool weekDayOK = CheckWeekDayChecked();
            if (intervalOK && weekDayOK)
            {
                _newMeeting.Intervall = interval;
                _newMeeting.Time = dtpTimeOfMeeting.Value;
                _newMeeting.NameOfMeeting = txtNameOfMeeting.Text;
                ok = true;
            }
            else
                MessageBox.Show("Fyll i alla fält", "Kunde inte lägga till möte");
            return ok;
        }
        private bool CheckInput(string input, out int interval)
        {
            bool ok = int.TryParse(input, out interval);

            return ok;
        }
        private bool CheckWeekDayChecked()
        {
            bool ok = false;
            foreach (Control control in gbReccurence.Controls)
            {
                // Check if the control is a CheckBox
                if (control is CheckBox checkBox)
                {
                    // Set the Checked property to true
                    if (checkBox.Checked)
                    {
                        ok = true;
                        GetWeekDay(checkBox);
                    }
                }
            }
            return ok;
        }

        private void btnEditMeeting_Click(object sender, EventArgs e)
        {
            Meeting oldMeeting = lbMeetings.SelectedItem as Meeting;
            if (oldMeeting is Meeting)
            {
                CreateMeeting();
                _mm.RemoveSSKfromMeeting(oldMeeting, _sm);
                _mm.EditMeeting(_newMeeting, oldMeeting);
            }
            UpdateMeetings();
        }

        private void btnRemoveMeeting_Click(object sender, EventArgs e)
        {
            _newMeeting = lbMeetings.SelectedItem as Meeting;
            if (_newMeeting is Meeting)
            {
                _mm.RemoveSSKfromMeeting(_newMeeting, _sm);
            }
            UpdateMeetings();
        }

        private DateTime RoundToNearest30Minutes(DateTime dateTime)
        {
            int minutes = dateTime.Minute;
            int roundedMinutes = ((minutes + 15) / 30) * 30 % 60; // Adjusted rounding to handle cases where the rounded minutes exceed 59
            int hoursToAdd = ((minutes + 15) / 30) == 2 ? 1 : 0; // Adjusted hours to add based on rounded minutes
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour + hoursToAdd, roundedMinutes, 0);
        }

        private void dtpTimeOfMeeting_ValueChanged(object sender, EventArgs e)
        {
            RoundToNearest30Minutes(dtpTimeOfMeeting.Value);
        }
    }
}
