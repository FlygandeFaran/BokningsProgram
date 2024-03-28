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
        SSKmanager _sskm;
        //private List<string> names;
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            dtpBehTid.CustomFormat = "HH:mm";
            dtpBehTid.ShowUpDown = true;
            DateTime idag = DateTime.Now;
            DateTime dt = new DateTime(idag.Year, idag.Month, idag.Day, 1, 0, 0);
            dtpBehTid.Value = dt;

            cbDescription.Items.Add("Piccline");
            cbDescription.Items.Add("Cytostatika");
            cbDescription.Items.Add("Vanlig");

            InitializeStaff();
            InitializeListBoxes();

            CreateFakeBookings();

            //InitializeBookings();
            InitializeSSKaxis();
        }
        private void InitializeStaff()
        {
            _sskm = new SSKmanager();
            _sskm.ImportFromXml();
            //_sskm.ListOfSSK.Add(new SSK("Erik", "34VB", KompetensLevel.Pickline));
            //_sskm.ListOfSSK.Add(new SSK("Linnea", "16LL", KompetensLevel.None));
            _sskm.ExportToXml();

        }
        private void InitializeListBoxes()
        {
            foreach (var item in _sskm.ListOfSSK)
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

            Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel);

            starttime = 10;
            duration = 1;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            newBooking = new Booking(start, end, "Piccline", RoomCategory.PicclineIn);
            _sskm.AddBooking(newBooking);

            starttime = 15;
            duration = 1;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            newBooking = new Booking(start, end, "Vanlig", RoomCategory.Dubbel);
            _sskm.AddBooking(newBooking);

            starttime = 14;
            duration = 2;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);
            newBooking = new Booking(start, end, "Vanlig", RoomCategory.Dubbel);
            _sskm.AddBooking(newBooking);

            UpdateBookingsSSK();
        }

        private void InitializeChart()
        {
            var ca = chart1.ChartAreas[0];

            //X axis settings
            ca.AxisX.Interval = 1;
            //ca.AxisX.IsLabelAutoFit = true;
            //ca.AxisX.ScaleView.Size = 5;

            //Y axis settings
            DateTime StartOfDay = DateTime.Now.AddHours(6 - DateTime.Now.Hour);
            DateTime EndOfDay = DateTime.Now.AddHours(17 - DateTime.Now.Hour);
            ca.AxisY.LabelStyle.Format = "HH:mm";
            ca.AxisY.IntervalType = DateTimeIntervalType.Minutes;
            ca.AxisY.Interval = 30;
            ca.AxisY.Maximum = EndOfDay.ToOADate();
            ca.AxisY.Minimum = StartOfDay.ToOADate();


            //Behövs för att skapa rader för varje SSK i bilden

        }

        private void InitializeRoomAxis()
        {
            InitializeChart();
            var serie = chart1.Series[0];
            int starttime = 2;
            int duration = 1;
            DateTime today = DateTime.Now;
            DateTime start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);
            for (int i = 0; i < _sskm.RoomManager.ListOfRooms.Count; i++)
            {
                Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel);
                addTaskRoom(serie, i, newBooking);
            }
        }

        private void InitializeSSKaxis()
        {
            InitializeChart();
            var serie = chart1.Series[0];
            int starttime = 2;
            int duration = 1;
            DateTime today = DateTime.Now;
            DateTime start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);
            for (int i = 0; i < _sskm.ListOfSSK.Count; i++)
            {
                Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel);
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
            s.Points[pt].AxisLabel = _sskm.ListOfSSK[who].Name;
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
        }
        private void addTaskRoom(Series s, int index, Booking booking)
        {
            int pt = s.Points.AddXY(index, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _sskm.RoomManager.ListOfRooms[index].RoomNumber.ToString();
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
        }
        private void UpdateBookingsSSK()
        {
            var serie = chart1.Series[0];
            serie.Points.Clear();
            InitializeSSKaxis();
            for (int i = 0; i < _sskm.ListOfSSK.Count; i++)
            {
                SSK tempSSK = _sskm.ListOfSSK[i];
                for (int j = 0; j < tempSSK.Schedule.ListOfBookings.Count; j++)
                {
                    Booking tempBooking = tempSSK.Schedule.ListOfBookings[j];
                    addTaskSSK(serie, i, tempBooking);
                }
            }
        }
        private void UpdateBookingsRoom()
        {
            var serie = chart1.Series[0];
            serie.Points.Clear();
            InitializeRoomAxis();
            for (int i = 0; i < _sskm.RoomManager.ListOfRooms.Count; i++)
            {
                Room tempRoom = _sskm.RoomManager.ListOfRooms[i];
                for (int j = 0; j < tempRoom.Schedule.ListOfBookings.Count; j++)
                {
                    Booking tempBooking = tempRoom.Schedule.ListOfBookings[j];
                    addTaskRoom(serie, i, tempBooking);
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            GetBookingTime(out start, out end);

            string strOut = cbDescription.Text;

            RoomCategory roomRequired = GetRequiredRoom();

            Booking newBooking = new Booking(start, end, cbDescription.Text, roomRequired);
            _sskm.SuggestBooking(newBooking);

            if (rbChartSSK.Checked)
                UpdateBookingsSSK();
            else
                UpdateBookingsRoom();
            //MessageBox.Show($"Bokning har skapats för rum  med SSK ");
        }

        private void GetBookingTime(out DateTime start, out DateTime end)
        {
            int starttime = 7;
            int duration = DateTime.Parse(dtpBehTid.Text).Hour;
            DateTime today = DateTime.Now;
            if (cbEntireDayBooking.Checked)
            {
                start = new DateTime(today.Year, today.Month, today.Day, 7, 0, 0);
                end = new DateTime(today.Year, today.Month, today.Day, 16, 0, 0);
            }
            else
            {
                start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
                end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);
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
                lblStart.Enabled = true;
                lblSlut.Enabled = true;
                dtpSlutar.Enabled = true;
                dtpStartar.Enabled = true;
            }
            else if (!cbFlerdagsbeh.Checked)
            {
                lblStart.Enabled = false;
                lblSlut.Enabled = false;
                dtpSlutar.Enabled = false;
                dtpStartar.Enabled = false;
            }
        }

        private void NySSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SSKform sSKform = new SSKform();
            sSKform.ShowDialog();
            _sskm.ImportFromXml();
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
    }
}
