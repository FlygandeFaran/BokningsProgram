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
        private List<Booking> _firstlistOfBookings;
        private List<Booking> _secondlistOfBookings;
        private DateTime _startOfDay;
        private DateTime _endOfDay;
        private bool _isFullDayBooked;
        private bool _hasLunch;

        public bool IsFullDayBooked
        {
            get { return _isFullDayBooked; }
            set { _isFullDayBooked = value; }
        }
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
        public List<Booking> FirstlistOfBookings
        {
            get { return _firstlistOfBookings; }
            set { _firstlistOfBookings = value; }
        }
        public List<Booking> SecondlistOfBookings
        {
            get { return _secondlistOfBookings; }
            set { _secondlistOfBookings = value; }
        }
        public DailySchedule()
        {
            //_firstlistOfBookings = new List<Booking>();
            //_secondlistOfBookings = new List<Booking>();
        }

		public DailySchedule(DateTime startOfDay, DateTime endOfDay, bool HasLunch)
        {
            _firstlistOfBookings = new List<Booking>();
            _startOfDay = startOfDay;
            _endOfDay = endOfDay;
            _isFullDayBooked = false;
            _hasLunch = HasLunch;
            LoadDay(startOfDay, false);
        }

        public void LoadDay(DateTime startOfDay, bool secondTrack)
        {
            DateTime lunch = new DateTime(startOfDay.Year, startOfDay.Month, startOfDay.Day, 11, 30, 00);
            AddBooking(new Booking(_startOfDay.AddHours(-startOfDay.Hour), _startOfDay, "Stängt", RoomCategory.Dubbel, false), secondTrack, 0); //Spärrar starten av dagen
            AddBooking(new Booking(_endOfDay, _endOfDay.AddHours(23 - _endOfDay.Hour), "Stängt", RoomCategory.Dubbel, false), secondTrack, 0); //Spärrar slutet av dagen
            if (StartOfDay.Hour < 16 && _hasLunch)
                AddBooking(new Booking(lunch, lunch.AddHours(1), "Lunch", RoomCategory.Dubbel, false), secondTrack, 1); //Spärrar lunch
        }

        public void AddSecondListOfBookings(DateTime startOfDay)
        {
            _secondlistOfBookings = new List<Booking>();
            LoadDay(startOfDay, true);
        }
        public bool CheckAvailability(Booking newBooking, int i, bool secondTrack)
        {
            bool ok = false;
            Booking booking = null;
            List<Booking> bookings = null;
            if (!IsFullDayBooked && !_firstlistOfBookings.First().Description.Equals("Sjuk"))
            {
                if (_firstlistOfBookings.Count > i && !secondTrack)
                {
                    bookings = _firstlistOfBookings;
                    booking = bookings[i];
                }
                else if (_secondlistOfBookings is List<Booking>)
                {

                    //if (!IsFullDayBooked && _secondlistOfBookings.Count > i && secondTrack) Om man kan jobba samtidigt som telefon/tablett
                    if (_secondlistOfBookings.Count > i && secondTrack)
                    {
                        bookings = _secondlistOfBookings;
                        booking = bookings[i];
                    }
                }
                if (booking is Booking)
                {
                    if (CheckAvailabilityBeforeFirstBooking(newBooking, i, booking))
                        ok = true;
                    else if (CheckAvailabilityBetweenBookings(newBooking, i, booking, bookings))
                        ok = true;
                    else if (CheckAvailabilityAfterLastBooking(newBooking, i, booking, bookings))
                        ok = true;
                }
            }
            return ok;
        }
        public bool CheckAvailabilityForFullDay(bool secondTrack)
        {
            if (_startOfDay.Hour < 16)
            {
                if (_firstlistOfBookings.Count <= 3 && !IsFullDayBooked && !secondTrack)
                {
                    return true;
                }
                else if (_firstlistOfBookings.Count <= 3 && _secondlistOfBookings.Count <= 3 && !IsFullDayBooked && secondTrack)
                {
                    return true;
                }
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
        private bool CheckAvailabilityBetweenBookings(Booking newBooking, int i, Booking firstBooking, List<Booking> listOfBookings)
        {
            int noOfBookings = listOfBookings.Count;
            if (noOfBookings > 0 && noOfBookings - 1 > i)
            {
                Booking secondBooking = listOfBookings[i + 1];
                if (firstBooking.EndTime <= newBooking.StartTime && secondBooking.StartTime >= newBooking.EndTime)
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckAvailabilityAfterLastBooking(Booking newBooking, int i, Booking lastBooking, List<Booking> listOfBookings)
        {
            int noOfBookings = listOfBookings.Count;
            if (noOfBookings > 0)
            {
                lastBooking = listOfBookings[noOfBookings - 1];
                if (i == noOfBookings - 1 && newBooking.StartTime >= lastBooking.EndTime)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddBooking(Booking booking, bool secondTrack, int bookingID)
        {
            booking.ID = bookingID;
            if (secondTrack && _secondlistOfBookings is List<Booking>)
                _secondlistOfBookings.Add(booking);
            else
                _firstlistOfBookings.Add(booking);
            if (booking.FullDay)
                _isFullDayBooked = true;

            SortBookings();
        }

        private void SortBookings()
        {
            _firstlistOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
            if (_secondlistOfBookings is List<Booking>)
                _secondlistOfBookings.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));
        }

        public void RemoveBooking(Booking booking)
        {
            bool bookingExists = _firstlistOfBookings.Any(b => b.Equals(booking));
            if (bookingExists)
            {
                _firstlistOfBookings.Remove(booking);
            }
            else
                _secondlistOfBookings.Remove(booking);
            if (booking.FullDay)
                _isFullDayBooked = false;
            SortBookings();
        }
	}
}
