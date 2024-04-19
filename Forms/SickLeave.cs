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
    public partial class SickLeave : Form
    {
        private SSK _selectedSSK;

        public SSK SelectedSSK
        {
            get { return _selectedSSK; }
            set { _selectedSSK = value; }
        }

        public SickLeave(SSKmanager sskm)
        {
            InitializeComponent();

            lbSSK.DataSource = sskm.ListOfSSK;
        }

        private void btnEditBookings_Click(object sender, EventArgs e)
        {
            
            if (lbSSK.SelectedItem != null)
                _selectedSSK = (SSK)lbSSK.SelectedItem;
        }
    }
}
