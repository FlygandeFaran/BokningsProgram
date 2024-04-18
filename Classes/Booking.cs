using System;
using System.Collections.Generic;
using System.Drawing;
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
        //public SSK bookingSSK { get; set; }
        //public Room bookingRoom { get; set; }

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
        public void CopyBooking(Booking booking)
        {
            _roomRequired = booking.RoomRequired;
            _endTime = booking.EndTime;
            _startTime = booking.StartTime;
            _description = booking.Description;
            _fullDay = booking.FullDay;
            _taskColor = booking.TaskColor;
            _taskTextColor = booking.TaskTextColor;
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
                    _taskColor = Color.LightCyan;
                    break;
                case "Stängt":
                    _taskColor = Color.LightGray;
                    _taskTextColor = _taskColor;
                    break;
                case "Lunch":
                    _taskColor = Color.LightCoral;
                    _taskTextColor = _taskColor;
                    break;
                default:
                    _taskColor = Color.LightPink;
                    break;
            }
        }
    }
}
