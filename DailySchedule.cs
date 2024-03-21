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

		public List<Booking> ListOfBookings
		{
			get { return _listOfBookings; }
			set { _listOfBookings = value; }
		}
		public DailySchedule()
		{
			_listOfBookings = new List<Booking>();
		}
		public void AddBooking(Booking booking)
		{
			_listOfBookings.Add(booking);
			_listOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
		}
	}
}
