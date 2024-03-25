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
        RoomManager _rm;
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

            InitializeStaff();
            InitializeListBoxes();

            CreateFakeBookings();

            //InitializeBookings();

            InitializeChart();
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
            var series = chart1.Series[0];
            int starttime = 2;
            int duration = 1;
            DateTime today = DateTime.Now;
            DateTime start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.PicclineIn);

            addTask(series, 0, newBooking);
            addTask(series, 1, newBooking);


            starttime = 10;
            duration = 1;
            start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            newBooking = new Booking(start, end, "Piccline", RoomCategory.PicclineIn);
            _sskm.AddBooking(newBooking);


            //start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            //end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            //newBooking = new Booking(start, end, "Cytostatika");
            //_sskm.AddBooking(newBooking);

            //starttime = 9;
            //duration = 2;
            //start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            //end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            //newBooking = new Booking(start, end, "Cytostatika");
            //_sskm.AddBooking(newBooking);

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

            UpdateBookings();
        }

        private void InitializeChart()
        {
            var ca = chart1.ChartAreas[0];
            var serie = chart1.Series[0];

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

            int starttime = 2;
            int duration = 1;
            DateTime today = DateTime.Now;
            DateTime start = new DateTime(today.Year, today.Month, today.Day, starttime, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, starttime + duration, 0, 0);

            //Behövs för att skapa rader för varje SSK i bilden
            for (int i = 0; i < _sskm.ListOfSSK.Count; i++)
            {
                Booking newBooking = new Booking(start, end, "vanlig", RoomCategory.Dubbel);
                addTask(serie, i, newBooking);
            }

            //Series serie2 = CreateNewSeries();

            //addTask(serie, 0, start, end, Color.Aqua, "Piccline");
            //addTask(serie2, 0, start, end, Color.Yellow, "Piccline");
            //addTask(serie, 1, start, end, Color.Aqua, "Piccline");
            //addTask(serie, 2, start, end, Color.Aqua, "Piccline");
            //addTask(serie, 3, start, end, Color.Aqua, "Piccline");

            //chart1.Series.Add(serie2);
            //chart1.Series.Add(series3);
            //chart1.Series.Add(series4);
            //chart1.Series.Add(series5);
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

        private void addTask(Series s, int who, Booking booking)
        {
            int pt = s.Points.AddXY(who, booking.StartTime, booking.EndTime);
            s.Points[pt].AxisLabel = _sskm.ListOfSSK[who].Name;
            s.Points[pt].Label = booking.Description;
            s.Points[pt].Color = booking.TaskColor;
        }
        private void UpdateBookings()
        {
            InitializeChart();
            var serie = chart1.Series[0];
            serie.Points.Clear();
            for (int i = 0; i < _sskm.ListOfSSK.Count; i++)
            {
                SSK tempSSK = _sskm.ListOfSSK[i];
                for (int j = 0; j < tempSSK.Schedule.ListOfBookings.Count; j++)
                {
                    Booking tempBooking = tempSSK.Schedule.ListOfBookings[j];
                    addTask(serie, i, tempBooking);
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Bokning har skapats för rum  med SSK ");
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
            if (rbHighKompetens.Checked)
            {

            }
        }

        private void rbLowKompetens_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
