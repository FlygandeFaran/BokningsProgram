using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Booking
    {
        private Color _taskColor;
        private string _description;
        private DateTime _startTime;
        private DateTime _endTime;

        public Color TaskColor
        {
            get { return _taskColor; }
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
        public Booking(DateTime start, DateTime end, string description)
        {
            _startTime = start;
            _endTime = end;
            _description = description;
            SetColorToTask();
        }
        private void SetColorToTask()
        {
            switch (_description)
            {
                default:
                    _taskColor = Color.Green;
                    break;
            }
        }
    }
}
