using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram.Forms
{
    public class Meeting
    {
		private DateTime _time;
		private List<DayOfWeek> _dayOfWeek;
        private int _interval;
        private List<string> _namesOfSSK;
        private string _nameOfMeeting;
        private List<Booking> _bookedMeetings;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public List<DayOfWeek> DayOfWeek
		{
			get { return _dayOfWeek; }
			set { _dayOfWeek = value; }
        }
        public int Intervall
        {
            get { return _interval; }
            set { _interval = value; }
        }
        public List<string> NamesOfSSK
        {
            get { return _namesOfSSK; }
            set { _namesOfSSK = value; }
        }
        public string NameOfMeeting
        {
            get { return _nameOfMeeting; } 
            set { _nameOfMeeting = value; }
        }
        public List<Booking> BookedMeetings
        {
            get { return _bookedMeetings; }
            set { _bookedMeetings = value; }
        }

        public Meeting()
        {
            _dayOfWeek = new List<DayOfWeek>();
            _namesOfSSK = new List<string>();
            _bookedMeetings = new List<Booking>();
        }
        public Meeting(Meeting meeting)
        {
            _dayOfWeek = meeting.DayOfWeek;
            _interval = meeting.Intervall;
            _nameOfMeeting= meeting.NameOfMeeting;
            _namesOfSSK = meeting.NamesOfSSK;
            _time = meeting.Time;
            _bookedMeetings = meeting.BookedMeetings;
        }
        public override string ToString()
        {
            return _nameOfMeeting;
        }
    }
}
