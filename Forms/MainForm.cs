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
            dtpBehTid.Value = dt;

            //cbDescription.Items.Add("Piccline");
            cbDescription.Items.Add("Cytostatika");
            cbDescription.Items.Add("Vanlig");

            InitializeListBoxes();

            CreateFakeBookings();

            //InitializeBookings();
            UpdateSSKaxis();
        }
        private void InitializeListBoxes()
        {
            foreach (var item in _cm.SskManager.ListOfSSK)
            {
                lbAvailableSSK.Items.Add(item);
            }
        }
        private void InitializeBookings()
        {
            //UpdateBookings();
        }
        private void CreateFakeBookings()
        {
            int starttime = 2;
            int duration = 1;
            DateTime today = DateTime.Now;
            DateTime start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel, false);

            starttime = 10;
            duration = 1;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            newBooking = new Booking(start, end, "Piccline", RoomCategory.PicclineIn, false);
            SSK ssk = lbAvailableSSK.SelectedItem as SSK;
            _cm.SuggestBooking(newBooking, ssk);

            starttime = 15;
            duration = 1;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            newBooking = new Booking(start, end, "Vanlig", RoomCategory.Dubbel, false);
            _cm.SuggestBooking(newBooking, ssk);

            starttime = 14;
            duration = 2;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);
            newBooking = new Booking(start, end, "Vanlig", RoomCategory.Dubbel, false);
            _cm.SuggestBooking(newBooking, ssk);

            UpdateBookingsSSK();
        }

        private void UpdateChart()
        {
            var ca = chart1.ChartAreas[0];

            //X axis settings
            ca.AxisX.Interval = 1;
            //ca.AxisX.IsLabelAutoFit = true;
            //ca.AxisX.ScaleView.Size = 5;
            DateTime date = dtpScheduleDay.Value;
            //Y axis settings
            DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
            DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
            ca.AxisY.LabelStyle.Format = "HH:mm";
            ca.AxisY.IntervalType = DateTimeIntervalType.Minutes;
            ca.AxisY.Interval = 30;
            ca.AxisY.Maximum = endOfDay.ToOADate();
            ca.AxisY.Minimum = startOfDay.ToOADate();


            //Behövs för att skapa rader för varje SSK i bilden

        }

        private void UpdateRoomAxis()
        {
            UpdateChart();
            var serie = chart1.Series[0];
            int starttime = 2;
            int duration = 1;
            //DateTime today = DateTime.Now;
            DateTime date = dtpScheduleDay.Value;
            DateTime start = new DateTime(date.Year, date.Month, date.Day, starttime, 0, 0);
            DateTime end = new DateTime(date.Year, date.Month, date.Day, starttime + duration, 0, 0);
            for (int i = 0; i < _cm.RoomManager.ListOfRooms.Count; i++)
            {
                Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel, false);
                addTaskRoom(serie, i, newBooking);
            }
        }

        private void UpdateSSKaxis()
        {
            UpdateChart();
            var serie = chart1.Series[0];
            int starttime = 2;
            int duration = 1;
            DateTime date = dtpScheduleDay.Value;
            DateTime start = new DateTime(date.Year, date.Month, date.Day, starttime, 0, 0);
            DateTime end = new DateTime(date.Year, date.Month, date.Day, starttime + duration, 0, 0);
            for (int i = 0; i < _cm.SskManager.ListOfSSK.Count; i++)
            {
                Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel, false);
                addTaskSSK(serie, i, newBooking);
            }
        }
        private static Series CreateNewSeries()
        {
            return new Series
            {
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.RangeBar,
                YValueType = ChartValueType.Auto,
                XValueType = ChartValueType.Auto,
                IsXValueIndexed = false,
                YValuesPerPoint = 2
            };
        }

        private void addTaskSSK(Series s, int who, Booking booking)
        {
            int pt = s.Points.AddXY(who, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _cm.SskManager.ListOfSSK[who].Name;
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
        }
        private void addTaskRoom(Series s, int index, Booking booking)
        {
            int pt = s.Points.AddXY(index, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _cm.RoomManager.ListOfRooms[index].RoomNumber.ToString();
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
        }
        private void UpdateBookingsSSK()
        {
            var serie = chart1.Series[0];
            serie.Points.Clear();
            UpdateSSKaxis();
            for (int i = 0; i < _cm.SskManager.ListOfSSK.Count; i++)
            {
                SSK tempSSK = _cm.SskManager.ListOfSSK[i];
                DailySchedule scheduleOfTheDay = tempSSK.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(dtpScheduleDay.Value.DayOfYear));
                if (scheduleOfTheDay is DailySchedule)
                {
                    lblWarning.Text = "";
                    for (int j = 0; j < scheduleOfTheDay.ListOfBookings.Count; j++)
                    {
                        Booking tempBooking = scheduleOfTheDay.ListOfBookings[j];
                        addTaskSSK(serie, i, tempBooking);
                    }
                }
                else
                {
                    lblWarning.Text = "Finns inget schema för den här dagen";
                }
            }
        }
        private void UpdateBookingsRoom()
        {
            var serie = chart1.Series[0];
            serie.Points.Clear();
            UpdateRoomAxis();
            for (int i = 0; i < _cm.RoomManager.ListOfRooms.Count; i++)
            {
                Room tempRoom = _cm.RoomManager.ListOfRooms[i];
                DailySchedule scheduleOfTheDay = tempRoom.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(dtpScheduleDay.Value.DayOfYear));
                for (int j = 0; j < scheduleOfTheDay.ListOfBookings.Count; j++)
                {
                    Booking tempBooking = scheduleOfTheDay.ListOfBookings[j];
                    addTaskRoom(serie, i, tempBooking);
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            GetBookingTime(out DateTime start, out DateTime end);

            string strOut = cbDescription.Text;

            RoomCategory roomRequired = GetRequiredRoom();
            Booking newBooking = new Booking(start, end, strOut, roomRequired, cbEntireDayBooking.Checked);
            _cm.SuggestBooking(newBooking, lbAvailableSSK.SelectedItem as SSK);
            UpdateChartDependingOnTab();
            //MessageBox.Show($"Bokning har skapats för rum  med SSK ");
        }

        private void UpdateChartDependingOnTab()
        {
            if (rbChartSSK.Checked)
                UpdateBookingsSSK();
            else
                UpdateBookingsRoom();
        }

        private void GetBookingTime(out DateTime start, out DateTime end)
        {
            int starttime = 7;
            //int startHour = dtpStartTime.Value.Hour;
            //int startMinute = dtpStartTime.Value.Minute;
            int durationHour = DateTime.Parse(dtpBehTid.Text).Hour;
            int durationMinute = DateTime.Parse(dtpBehTid.Text).Minute;
            DateTime date = dtpScheduleDay.Value;
            if (cbEntireDayBooking.Checked)
            {
                start = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                end = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
            }
            else
            {
                start = new DateTime(date.Year, date.Month, date.Day, starttime, 0, 0);
                end = new DateTime(date.Year, date.Month, date.Day, starttime + durationHour, durationMinute, 0);
                //start = new DateTime(date.Year, date.Month, date.Day, startHour, startMinute, 0);
                //end = new DateTime(date.Year, date.Month, date.Day, startHour + durationHour, startMinute + durationMinute, 0);
            }
        }

        private RoomCategory GetRequiredRoom()
        {
            RoomCategory roomRequired;

            if (cbNystart.Checked)
                roomRequired = RoomCategory.Enkel;
            else if (cbPiccline.Checked)
                roomRequired = RoomCategory.PicclineIn;
            else
                roomRequired = RoomCategory.Dubbel;
            return roomRequired;
        }

        private void cbFlerdagsbeh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlerdagsbeh.Checked)
            {
                lblEndDate.Enabled = true;
                lblStartDate.Enabled = true;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
            else if (!cbFlerdagsbeh.Checked)
            {
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

        private void cbPiccline_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPiccline.Checked)
            {
                cbDescription.Text = "Piccline";
                cbDescription.Enabled = false;
            }
            else 
            { 
                cbDescription.Enabled = true; 
            }
        }

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            dtpScheduleDay.Value = dtpScheduleDay.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpScheduleDay.Value = dtpScheduleDay.Value.AddDays(1);
        }

        private void dtpScheduleDay_ValueChanged(object sender, EventArgs e)
        {
            UpdateChart();
            UpdateChartDependingOnTab();
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

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = (int)result.Series.Points[result.PointIndex].XValue;
                DateTime startOfBooking = DateTime.FromOADate(result.Series.Points[result.PointIndex].YValues[0]);
                DateTime endOfBooking = DateTime.FromOADate(result.Series.Points[result.PointIndex].YValues[1]);

                bool ok = _cm.ChangeBooking(index, startOfBooking, endOfBooking);
                if (ok)
                    UpdateChartDependingOnTab();

                //MessageBox.Show(ssk.Name + " " + startOfBooking.ToString() + " - " + endOfBooking.ToString());
            }
        }
    }
}
//Written by:
//Lord Erik III of house Fura, Opressor of Dmax, Delineator Supreme, Warrior of RBE
