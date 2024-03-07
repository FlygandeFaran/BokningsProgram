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

namespace BokningsProgram
{
    public partial class MainForm : Form
    {
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
