using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class DailySchedule
    {
		private List<Booking> _listOfBookings;
        private DateTime _startOfDay;
        private DateTime _endOfDay;

        public DateTime StartOfDay
        {
            get { return _startOfDay; }
            set { _startOfDay = value; }
        }
        public DateTime EndOfDay
		{
			get { return _endOfDay; }
			set { _endOfDay = value; }
		}
		public List<Booking> ListOfBookings
		{
			get { return _listOfBookings; }
			set { _listOfBookings = value; }
        }
		public DailySchedule()
		{
            _listOfBookings = new List<Booking>();
        }

		public DailySchedule(DateTime startOfDay, DateTime endOfDay) //Använd när jag har schema för SSK
		{
			_listOfBookings = new List<Booking>();
			_startOfDay = startOfDay;
			_endOfDay = endOfDay;
		}
		public void AddBooking(Booking booking)
		{
			_listOfBookings.Add(booking);
			_listOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
		}
	}
}
