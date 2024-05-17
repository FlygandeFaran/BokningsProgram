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
    public partial class ChangeBooking : Form
    {
        public Booking Booking { get; set; }
        public SSK Ssk { get; set; }
        public Room Room { get; set; }

        public ChangeBooking(Booking booking, SSK ssk, List<Room> rooms, List<SSK> ssks)
        {
            InitializeComponent();
            lbAvailableRoom.DataSource = rooms;
            lbAvailableSSK.DataSource = ssks;
            InitializeGUI();

            Booking = booking;
            dtpStartTime.Value = booking.StartTime;
            TimeSpan behTid = booking.EndTime - booking.StartTime;
            dtpBehTid.Value = new DateTime(booking.StartTime.Year, booking.StartTime.Month, booking.StartTime.Day, behTid.Hours, behTid.Minutes, 0);
            //lbAvailableSSK.SelectedItem = ssk;
            lbAvailableSSK.SelectedIndex = -1;
            lbAvailableRoom.SelectedIndex = -1;
            lblBooking.Text = booking.Description;
        }
        private void InitializeGUI()
        {
            dtpBehTid.CustomFormat = "HH:mm";
            dtpBehTid.ShowUpDown = true;
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.ShowUpDown = true;
            lbAvailableRoom.DisplayMember = "RoomNumber";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Booking.StartTime = dtpStartTime.Value;
            DateTime date = dtpStartTime.Value;
            Booking.EndTime = new DateTime(date.Year, date.Month, date.Day, date.AddHours(dtpBehTid.Value.Hour).Hour, date.AddMinutes(dtpBehTid.Value.Minute).Minute, 0);

            Ssk = lbAvailableSSK.SelectedItem as SSK;
            Room = lbAvailableRoom.SelectedItem as Room;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lbAvailableSSK.SelectedIndex = -1;
            lbAvailableRoom.SelectedIndex = -1;
        }
    }
}
