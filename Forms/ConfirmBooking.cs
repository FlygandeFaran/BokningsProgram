using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokningsProgram.Managers
{
    public partial class ConfirmBooking : Form
    {
        public ConfirmBooking(string sskName, string roomNumber, Booking booking)
        {
            InitializeComponent();
            lblBeh.Text = booking.Description;
            lblRoom.Text = roomNumber;
            lblTime.Text = booking.StartTime.ToString("HH:mm") + " - " + booking.EndTime.ToString("HH:mm");
            lblSSK.Text = sskName;
            lblBeh.BackColor = booking.TaskColor;
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }
    }
}
