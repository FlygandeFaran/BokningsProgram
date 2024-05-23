using BokningsProgram.Forms;
using BokningsProgram.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BokningsProgram
{
    public partial class MainForm : Form
    {
        //SSKmanager _sskm;
        ClinicalManager _cm;
        //private List<string> names;
        public MainForm()
        {
            InitializeComponent();
            _cm = new ClinicalManager();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            lblWarning.Text = "";

            dtpBehTid.CustomFormat = "HH:mm";
            dtpBehTid.ShowUpDown = true;
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.ShowUpDown = true;
            DateTime idag = DateTime.Now;
            DateTime dt = new DateTime(idag.Year, idag.Month, idag.Day, 1, 0, 0);
            DateTime behTid = new DateTime(idag.Year, idag.Month, idag.Day, 7, 0, 0);
            dtpBehTid.Value = dt;
            dtpStartTime.Value = behTid;
            lblWeekDay.Text = dtpScheduleDay.Value.DayOfWeek.ToString();
            CreateNewSeries();

            List<string> bookingNames = _cm.BookingDescriptions();
            cbDescription.DataSource = bookingNames;
            //cbDescription.Items.Add("Piccline");

            //cbDescription.Items.Add("Piccline");
            //cbDescription.Items.Add("Telefon");
            //cbDescription.Items.Add("Tablett");
            //cbDescription.Items.Add("Cytostatika");
            //cbDescription.Items.Add("Vanlig");

            InitializeListBoxes();

            //CreateFakeBookings();
            UpdateBookingsSSK();

            //InitializeBookings();
            UpdateChart();
        }
        private void InitializeListBoxes()
        {
            //lbAvailableSSK.DataSource = _cm.SskManager.ListOfSSK;
            //lbAvailableRooms.DataSource = _cm.RoomManager.ListOfRooms;
            //lbAvailableRooms.DisplayMember = "RoomNumber";
            //lbAvailableSSK.SelectedIndex = -1;
            //lbAvailableRooms.SelectedIndex = -1;
        }

        private void UpdateChart()
        {
            var ca = chart1.ChartAreas[0];

            ca.AxisX.Interval = 1;
            DateTime date = dtpScheduleDay.Value;
            DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
            DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
            ca.AxisY.LabelStyle.Format = "HH:mm";
            ca.AxisY.IntervalType = DateTimeIntervalType.Minutes;
            ca.AxisY.Interval = 30;
            ca.AxisY.Maximum = endOfDay.ToOADate();
            ca.AxisY.Minimum = startOfDay.ToOADate();
        }
        private void CreateNewSeries()
        {
            Series serie = new Series
            {
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.RangeBar,
                YValueType = ChartValueType.Auto,
                XValueType = ChartValueType.Auto,
                IsXValueIndexed = false,
                YValuesPerPoint = 2
            };
            chart1.Series.Add(serie);
        }
        private void addTaskSSK(Series s, int who, Booking booking)
        {
            int pt = s.Points.AddXY(who, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _cm.SskManager.ListOfSSK[who].Name;
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
            s.Points[pt].LabelForeColor = booking.TaskTextColor;
        }
        private void addTaskRoom(Series s, int index, Booking booking)
        {
            int pt = s.Points.AddXY(index, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _cm.RoomManager.ListOfRooms[index].RoomNumber.ToString();
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
            s.Points[pt].LabelForeColor = booking.TaskTextColor;

        }
        private void UpdateBookingsSSK()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            UpdateChart();
            for (int i = 0; i < _cm.SskManager.ListOfSSK.Count; i++)
            {
                SSK tempSSK = _cm.SskManager.ListOfSSK[i];
                DailySchedule scheduleOfTheDay = tempSSK.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(dtpScheduleDay.Value.DayOfYear));
                
                AddDailyTasksOfSSKFromListOfBookings(i, scheduleOfTheDay);
            }
        }
        private void UpdateBookingsRoom()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            UpdateChart();
            for (int i = 0; i < _cm.RoomManager.ListOfRooms.Count; i++)
            {
                Room tempRoom = _cm.RoomManager.ListOfRooms[i];
                DailySchedule scheduleOfTheDay = tempRoom.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(dtpScheduleDay.Value.DayOfYear));

                AddDailyTasksOfRoomFromListOfBookings(i, scheduleOfTheDay);
                
            }
        }
        private void AddDailyTasksOfSSKFromListOfBookings(int i, DailySchedule scheduleOfTheDay)
        {
            var serie = chart1.Series[0];
            var serieSecondTrack = chart1.Series[1];
            if (scheduleOfTheDay is DailySchedule)
            {
                btnExecute.Enabled = true;
                btnSickLeave.Enabled = true;
                lblWarning.Text = "";
                if (scheduleOfTheDay.SecondlistOfBookings != null)
                {
                    for (int j = 0; j < scheduleOfTheDay.SecondlistOfBookings.Count; j++)
                    {
                        Booking tempBooking = scheduleOfTheDay.SecondlistOfBookings[j];
                        addTaskSSK(serieSecondTrack, i, tempBooking);
                    }
                }
                for (int j = 0; j < scheduleOfTheDay.FirstlistOfBookings.Count; j++)
                {
                    Booking tempBooking = scheduleOfTheDay.FirstlistOfBookings[j];
                    addTaskSSK(serie, i, tempBooking);
                }
            }
            else
            {
                lblWarning.Text = "Finns inget schema för den här dagen";
                btnExecute.Enabled = false;
                btnSickLeave.Enabled = false;
            }
        }
        private void AddDailyTasksOfRoomFromListOfBookings(int i, DailySchedule scheduleOfTheDay)
        {
            var serie = chart1.Series[0];
            var serieSecondTrack = chart1.Series[1];
            if (scheduleOfTheDay is DailySchedule)
            {
                lblWarning.Text = "";
                if (scheduleOfTheDay.SecondlistOfBookings != null)
                {
                    for (int j = 0; j < scheduleOfTheDay.SecondlistOfBookings.Count; j++)
                    {
                        Booking tempBooking = scheduleOfTheDay.SecondlistOfBookings[j];
                        addTaskRoom(serieSecondTrack, i, tempBooking);
                    }
                }
                for (int j = 0; j < scheduleOfTheDay.FirstlistOfBookings.Count; j++)
                {
                    Booking tempBooking = scheduleOfTheDay.FirstlistOfBookings[j];
                    addTaskRoom(serie, i, tempBooking);
                }
            }
            else
            {
                lblWarning.Text = "Finns inget schema för den här dagen";
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            RoomCategory roomRequired = GetRequiredRoom();
            if (cbFlerdagsbeh.Checked)
            {
                bool ok = CheckWeeklyInput();
                if (ok)
                {
                    List<Booking> multipleNewBookings = MultipleNewBookings(roomRequired);
                    _cm.SuggestMultipleBookings(multipleNewBookings);
                }
                else
                {
                    MessageBox.Show("Fel format på veckovis intervall");
                }
            }
            else
            {
                GetBookingTime(out DateTime start, out DateTime end, dtpScheduleDay.Value);
                Booking newBooking = new Booking(start, end, cbDescription.Text, roomRequired, cbEntireDayBooking.Checked);
                _cm.SuggestBooking(newBooking, lbAvailableSSK.SelectedItem as SSK, true);
            }
            UpdateChartDependingOnTab();
            //MessageBox.Show($"Bokning har skapats för rum  med SSK ");
        }
        private List<Booking> MultipleNewBookings(RoomCategory roomRequired)
        {
            List<Booking> newBookings = new List<Booking>();
            List<DateTime> days = GenerateDaysForMultipleBookings();
            foreach (DateTime date in days)
            {
                GetBookingTime(out DateTime start, out DateTime end, date);
                newBookings.Add(new Booking(start, end, cbDescription.Text, roomRequired, cbEntireDayBooking.Checked));
            }
            return newBookings;

            //var days = (dtpEndDate.Value.DayOfYear - dtpStartDate.Value.DayOfYear) + 1;
            //DateTime date = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            //for (int i = 0; i < days; i++)
            //{
            //    GetBookingTime(out DateTime start, out DateTime end, date);
            //    date = date.AddDays(1);
            //    newBookings.Add(new Booking(start, end, cbDescription.Text, roomRequired, cbEntireDayBooking.Checked));
            //}
        }
        private List<DateTime> GenerateDaysForMultipleBookings()
        {
            List<DateTime> dateTimes = new List<DateTime>();

            double days = (dtpEndDate.Value.DayOfYear - dtpStartDate.Value.DayOfYear) + 1;
            int interval = int.Parse(txtWeeklyInterval.Text);
            double treatmentDays = Math.Floor(days / (interval * 7));
            DateTime date = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, 0);
            for ( int i = 0; treatmentDays >= i; i++)
            {
                date = date.AddDays(i * interval * 7);
                dateTimes.Add(date);
            }
            return dateTimes;
        }
        private bool CheckWeeklyInput()
        {
            bool ok = int.TryParse(txtWeeklyInterval.Text, out int result);
            if (ok && result > 0)
                return true;
            else
                return false;
        }
        private void UpdateChartDependingOnTab()
        {
            if (rbChartSSK.Checked)
                UpdateBookingsSSK();
            else
                UpdateBookingsRoom();
        }

        private void GetBookingTime(out DateTime start, out DateTime end, DateTime date)
        {
            //int starttime = 7;
            int startHour = dtpStartTime.Value.Hour;
            int startMinute = dtpStartTime.Value.Minute;
            int durationHour = DateTime.Parse(dtpBehTid.Text).Hour;
            int durationMinute = DateTime.Parse(dtpBehTid.Text).Minute;
            if (cbEntireDayBooking.Checked)
            {
                start = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                end = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
            }
            else
            {
                start = new DateTime(date.Year, date.Month, date.Day, startHour, startMinute, 0);
                end = new DateTime(date.Year, date.Month, date.Day, startHour + durationHour, startMinute + durationMinute, 0);
                //start = new DateTime(date.Year, date.Month, date.Day, startHour, startMinute, 0);
                //end = new DateTime(date.Year, date.Month, date.Day, startHour + durationHour, startMinute + durationMinute, 0);
            }
        }

        private RoomCategory GetRequiredRoom()
        {
            RoomCategory roomRequired;

            if (cbNystart.Checked)
                roomRequired = RoomCategory.Enkel;
            else if (cbDescription.Text.Equals("Piccline"))
                roomRequired = RoomCategory.PicclineIn;
            else
                roomRequired = RoomCategory.Dubbel;
            return roomRequired;
        }

        private void cbFlerdagsbeh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlerdagsbeh.Checked)
            {
                txtWeeklyInterval.Enabled = true;
                lblEndDate.Enabled = true;
                lblStartDate.Enabled = true;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
            else if (!cbFlerdagsbeh.Checked)
            {
                txtWeeklyInterval.Enabled = false;
                lblEndDate.Enabled = false;
                lblStartDate.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
        }

        private void NySSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SSKform sSKform = new SSKform();
            sSKform.ShowDialog();
            _cm.SskManager.ImportFromXml();
            UpdateChart();
            UpdateChartDependingOnTab();
            UpdateBookingsSSK();
            InitializeListBoxes();
        }

        private void NyttRumToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rbHighKompetens_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbLowKompetens_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbEntireDayBooking_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEntireDayBooking.Checked)
                dtpBehTid.Enabled = false;
            else
                dtpBehTid.Enabled = true;
        }

        private void rbChartRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChartRoom.Checked)
            {
                UpdateBookingsRoom();
            }
            else
            {
                UpdateBookingsSSK();
            }
        }

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            dtpScheduleDay.Value = dtpScheduleDay.Value.AddDays(-1);
            //dtpStartDate.Value = dtpStartDate.Value.AddDays(1);
            //dtpEndDate.Value = dtpEndDate.Value.AddDays(1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpScheduleDay.Value = dtpScheduleDay.Value.AddDays(1);
            //dtpStartDate.Value = dtpStartDate.Value.AddDays(1);
            //dtpEndDate.Value = dtpEndDate.Value.AddDays(1);
        }

        private void dtpScheduleDay_ValueChanged(object sender, EventArgs e)
        {
            UpdateChart();
            UpdateChartDependingOnTab();
            lblWeekDay.Text = dtpScheduleDay.Value.DayOfWeek.ToString();
        }

        // Round a DateTime value to the nearest 30 minutes
        private DateTime RoundToNearest30Minutes(DateTime dateTime)
        {
            int minutes = dateTime.Minute;
            int roundedMinutes = ((minutes + 15) / 30) * 30 % 60; // Adjusted rounding to handle cases where the rounded minutes exceed 59
            int hoursToAdd = ((minutes + 15) / 30) == 2 ? 1 : 0; // Adjusted hours to add based on rounded minutes
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour + hoursToAdd, roundedMinutes, 0);
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            // When the value changes, round it to the nearest 30 minutes
            dtpStartTime.Value = RoundToNearest30Minutes(dtpStartTime.Value);
        }
        private void cbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDescription.Text.Equals("Tablett") || cbDescription.Text.Equals("Telefon"))
                cbEntireDayBooking.Checked = true;
            else 
                cbEntireDayBooking.Checked = false;
            Booking.GetTreatmentDuration(out int hour, out int minutes, cbDescription.Text);
            dtpBehTid.Value = new DateTime(dtpBehTid.Value.Year, dtpBehTid.Value.Month, dtpBehTid.Value.Day, hour, minutes, 0);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cm.exportStaff();
            _cm.exportRooms();
            _cm.exportMeetings();
        }

        private void btnSickLeave_Click(object sender, EventArgs e)
        {
            SickLeave sickLeave = new SickLeave(_cm.SskManager);
            DialogResult result = sickLeave.ShowDialog();
            if (result == DialogResult.OK)
            {
                SSK sickSSK = sickLeave.SelectedSSK;

                List<Booking> GetAllBookings = sickSSK.GetAllBookingsFromDay(dtpScheduleDay.Value);
                //if (GetAllBookings.Count > 0)
                {
                    Booking sickBooking = new Booking();
                    sickBooking.SickDay(dtpScheduleDay.Value);
                    //Booking sickBooking = new Booking(GetAllBookings.FirstOrDefault());
                    _cm.AddSickBooking(sickSSK, sickBooking);
                    foreach (Booking booking in GetAllBookings)
                    {
                        if (booking.ID > 2)
                        {
                            _cm.UpdateBooking(sickSSK, booking);
                            UpdateChartDependingOnTab();
                        }
                    }
                }
            }
            UpdateChartDependingOnTab();
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.DataPointLabel)
            {
                int index = (int)result.Series.Points[result.PointIndex].XValue;
                DateTime startOfBooking = DateTime.FromOADate(result.Series.Points[result.PointIndex].YValues[0]);
                DateTime endOfBooking = DateTime.FromOADate(result.Series.Points[result.PointIndex].YValues[1]);
                var description = result.Series.Points[result.PointIndex].Label;
                bool secondTrack = false;
                if (result.Series == chart1.Series[1])
                    secondTrack = true;

                if (description != "Stängt")
                    _cm.ChangeBooking(index, startOfBooking, endOfBooking, description, secondTrack);
                UpdateChartDependingOnTab();

                //MessageBox.Show(ssk.Name + " " + startOfBooking.ToString() + " - " + endOfBooking.ToString());
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime pickedDate = dtpEndDate.Value;
            DateTime lastScheduledDate = _cm.SskManager.ListOfSSK.First().ScheduledDays.Days.Last().StartOfDay;
            if (pickedDate > lastScheduledDate)
            {
                MessageBox.Show($"Finns inget schema som sträcker sig till {pickedDate:dd MMM yyyy}", "Usch då");
                dtpEndDate.Value = lastScheduledDate;
            }
        }
        private void btnClearSSK_Click(object sender, EventArgs e)
        {
            lbAvailableSSK.SelectedIndex = -1;
        }

        private void btnClearAllBookings_Click(object sender, EventArgs e)
        {
            _cm.ClearAllBookings();
            UpdateChart();
            UpdateChartDependingOnTab();
        }

        private void importeraSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cm.ImportSchedules();
        }

        private void återkommandeMötenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecurringMeetings recurringMeetings = new RecurringMeetings(_cm.SskManager, _cm.MeetingManager);
            recurringMeetings.ShowDialog();
            _cm.AddMeetingBookings();
            UpdateChart();
            UpdateChartDependingOnTab();
        }
    }
}
//Written by:
//Lord Erik III of house Fura, Opressor of Dmax, Delineator Supreme, Warrior of RBE
