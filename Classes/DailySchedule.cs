using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            DateTime lunch = new DateTime(startOfDay.Year, startOfDay.Month, startOfDay.Day, 11, 30, 00);
            AddBooking(new Booking(_startOfDay.AddHours(-3), _startOfDay, "Ledig", RoomCategory.Dubbel, false)); //Spärrar starten av dagen
            AddBooking(new Booking(_endOfDay, _endOfDay.AddHours(3), "Ledig", RoomCategory.Dubbel, false)); //Spärrar slutet av dagen
            AddBooking(new Booking(lunch, lunch.AddHours(1), "Lunch", RoomCategory.Dubbel, false)); //Spärrar lunch
        }
        public bool CheckAvailability(Booking newBooking, int i)
        {
            bool ok = false;
            Booking booking = _listOfBookings[i];
            if (CheckAvailabilityBeforeFirstBooking(newBooking, i, booking))
                ok = true;
            else if (CheckAvailabilityBetweenBookings(newBooking, i, booking))
                ok = true;
            else if (CheckAvailabilityAfterLastBooking(newBooking, i, booking))
                ok = true;

            return ok;
        }
        public bool CheckAvailabilityForFullDay()
        {
            if (_listOfBookings.Count == 3)
            {
                return true;
            }
            return false;
        }
        private bool CheckAvailabilityBeforeFirstBooking(Booking newBooking, int i, Booking firstBooking)
        {
            if (newBooking.EndTime < firstBooking.StartTime && i == 0)
            {
                return true;
            }
            return false;
        }
        private bool CheckAvailabilityBetweenBookings(Booking newBooking, int i, Booking firstBooking)
        {
            int noOfBookings = _listOfBookings.Count;
            if (noOfBookings > 0 && noOfBookings - 1 > i)
            {
                Booking secondBooking = _listOfBookings[i + 1];
                if (firstBooking.EndTime <= newBooking.StartTime && secondBooking.StartTime >= newBooking.EndTime)
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckAvailabilityAfterLastBooking(Booking newBooking, int i, Booking lastBooking)
        {
            int noOfBookings = _listOfBookings.Count;
            if (noOfBookings > 0)
            {
                lastBooking = _listOfBookings[noOfBookings - 1];
                if (i == noOfBookings - 1 && newBooking.StartTime >= lastBooking.EndTime)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddBooking(Booking booking)
		{
			_listOfBookings.Add(booking);
			_listOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
		}
        public void RemoveBooking(Booking booking)
        {
            _listOfBookings.Remove(booking);
            _listOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
        }
        public void EditBooking(Booking booking)
        {

        }
	}
}
