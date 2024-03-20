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

namespace BokningsProgram
{
    public partial class MainForm : Form
    {
        private List<string> names;
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            names = new List<string> { "Erik", "Linnea", "Thomas", "Edita" };
            dtpBehTid.CustomFormat = "HH:mm";
            dtpBehTid.ShowUpDown = true;
            DateTime idag = DateTime.Now;
            DateTime dt = new DateTime(idag.Year, idag.Month, idag.Day, 1, 0, 0);
            dtpBehTid.Value = dt;

            InitializeChart();
        }
        private void InitializeChartTest()
        {

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

            DateTime today = DateTime.Now;

            DateTime start = new DateTime(today.Year, today.Month, today.Day, 10, 0, 0);
            DateTime end = new DateTime(today.Year, today.Month, today.Day, 11, 0, 0);

            Series serie2 = CreateNewSeries();

            addTask(serie, 0, start, end, Color.Aqua, "Piccline");
            addTask(serie2, 0, start, end, Color.Yellow, "Piccline");
            addTask(serie, 1, start, end, Color.Aqua, "Piccline");
            addTask(serie, 2, start, end, Color.Aqua, "Piccline");
            addTask(serie, 3, start, end, Color.Aqua, "Piccline");

            chart1.Series.Add(serie2);
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

        private void addTask(Series s, int who, DateTime startTime,
                                 DateTime endTime, Color color, string task)
        {
            int pt = s.Points.AddXY(who, startTime, endTime);
            s.Points[pt].AxisLabel = names[who];
            s.Points[pt].Label = task;
            s.Points[pt].Color = color;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

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
