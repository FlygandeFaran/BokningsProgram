using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BokningsProgram
{
    public class Booking
    {
        private bool _fullDay;
        private RoomCategory _roomRequired;
        private Color _taskColor;
        private string _description;
        private DateTime _startTime;
        private DateTime _endTime;
        private Color _taskTextColor;
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Color TaskTextColor
        {
            get { return _taskTextColor; }
            set { _taskTextColor = value; }
        }
        public bool FullDay
        {
            get { return _fullDay; }
            set { _fullDay = value; }
        }
        public RoomCategory RoomRequired
        {
            get { return _roomRequired; }
            set { _roomRequired = value; }
        }
        public Color TaskColor
        {
            get { SetColorToTask(); return _taskColor; }
            set { _taskColor = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public Booking() { }
        public Booking(DateTime start, DateTime end, string description, RoomCategory roomRequired, bool fullDay)
        {
            _fullDay = fullDay;
            _roomRequired = roomRequired;
            _startTime = start;
            _endTime = end;
            _description = description;
            SetColorToTask();
        }
        public Booking(Booking booking)
        {
            _roomRequired = booking.RoomRequired;
            _endTime = booking.EndTime;
            _startTime = booking.StartTime;
            _description = booking.Description;
            _fullDay = booking.FullDay;
            _taskColor = booking.TaskColor;
            _taskTextColor = booking.TaskTextColor;
            _id = booking.ID;
        }
        public void SickDay(DateTime date)
        {

            _startTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            _endTime = new DateTime(date.Year, date.Month, date.Day, 23, 0, 0);
            _description = "Sjuk";
            SetColorToTask();
        }
        public Booking GenerateNewBookingSuggestion(Booking booking)
        {
            booking.StartTime = booking.StartTime.AddHours(0.5);
            booking.EndTime = booking.EndTime.AddHours(0.5);
            return booking;
        }
        private void SetColorToTask()
        {
            _taskTextColor = Color.Black;
            switch (_description)
            {
                case "Piccline":
                    _taskColor = Color.LightGreen;
                    break;
                case "Cytostatika":
                    _taskColor = Color.LightSalmon;
                    break;
                case "Stängt":
                    _taskColor = Color.LightGray;
                    _taskTextColor = _taskColor;
                    break;
                case "Lunch":
                    _taskColor = Color.LightCoral;
                    _taskTextColor = _taskColor;
                    break;
                case "Sjuk":
                    _taskColor = Color.LightCoral;
                    break;
                default:
                    _taskColor = Color.LightPink;
                    break;
            }
        }
        static public void GetTreatmentDuration(out int hour, out int minutes, string description)
        {
            hour = 0;
            minutes = 0;
            switch (description)
            {
                case "Piccline":
                    hour = 1;
                    minutes = 30;
                    break;
                case "Cytostatika":
                    hour = 1;
                    minutes = 30;
                    break;
                case "Abraxane/Gemzar":
                    hour = 2;
                    minutes = 0;
                    break;
                case "CAPOX":
                    hour = 3;
                    minutes = 0;
                    break;
                case "Cemiplimab":
                    hour = 1;
                    minutes = 0;
                    break;
                case "Cisplatin":
                    hour = 5;
                    minutes = 0;
                    break;
                case "Docetaxel":
                    hour = 2;
                    minutes = 0;
                    break;
                case "EC":
                    hour = 2;
                    minutes = 0;
                    break;
                case "FLOT":
                    hour = 3;
                    minutes = 0;
                    break;
                case "FLV":
                    hour = 1;
                    minutes = 0;
                    break;
                case "FLV/Bevacizumab":
                    hour = 2;
                    minutes = 0;
                    break;
                case "FOLFIRI":
                    hour = 2;
                    minutes = 0;
                    break;
                case "FOLFOX":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Gemcitabin":
                    hour = 1;
                    minutes = 0;
                    break;
                case "Gemcitabin/Nab-Paklitaxel":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Gemzar":
                    hour = 1;
                    minutes = 0;
                    break;
                case "Ipilimumab/Nivolumab":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Karboplatin/Etoposid":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Karboplatin/Irinotekan":
                    hour = 2;
                    minutes = 30;
                    break;
                case "Karboplatin/Paklitaxel":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Nivolumab":
                    hour = 2;
                    minutes = 0;
                    break;
                case "Paklitaxel":
                    hour = 1;
                    minutes = 30;
                    break;
                case "R-CHOP":
                    hour = 3;
                    minutes = 0;
                    break;
                case "Rituximab":
                    hour = 2;
                    minutes = 30;
                    break;
                case "Rituximab/Bendamustin":
                    hour = 3;
                    minutes = 0;
                    break;
                case "Trastuzumab":
                    hour = 1;
                    minutes = 0;
                    break;
                default:
                    hour = 1;
                    break;
            }
        }
    }
}
