using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Room
    {
        private ScheduledDays _scheduledDays;
        private DailySchedule _schedule;
        private RoomCategory _roomType;
        private int _roomNumber;

        public ScheduledDays ScheduledDays
        {
            get { return _scheduledDays; }
            set { _scheduledDays = value; }
        }
        //public DailySchedule Schedule
        //{
        //    get { return _schedule; }
        //    set { _schedule = value; }
        //}
        public RoomCategory RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        public int RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        public Room(RoomCategory roomType, int roomNumber)
        {
            _roomType = roomType;
            _roomNumber = roomNumber;
            _scheduledDays = new ScheduledDays(_roomNumber);
        }
        public Room() { }
        public void AddBooking(Booking booking)
        {
            _schedule.AddBooking(booking);
        }
        public bool IsItBooked(Booking newBooking) //bra engelska...
        {
            _schedule = _scheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear == newBooking.StartTime.DayOfYear);
            int NoOfBookings = _schedule.ListOfBookings.Count;
            if (NoOfBookings == 0) //Om det inte finns någon bokning är det garanterat ledigt
                return false;

            bool ok = false;
            bool noMoreBookings = false;
            int i = 0;

            while (!ok) //kollar om bokning passar in i schemat
            {
                Booking booking = _schedule.ListOfBookings[i];
                if (CheckAvailabilityBeforeFirstBooking(newBooking, i, booking))//False om det finns lucka innan först bokade tid
                    ok = true;
                else if (CheckAvailabilityBetweenBookings(newBooking, NoOfBookings, i, booking))//False om det finns tid mellan två bokningar
                    ok = true;
                else if (ok = CheckAvailabilityAfterLastBooking(newBooking, i, NoOfBookings))//False om det finns tid efter sista bokningen
                    ok = true;

                i++;
                if (i == NoOfBookings && !ok)//Om det inte finns någon tid alls
                {
                    ok = true;
                    noMoreBookings = true;//isTheyBooked blir true
                }
            }
            return noMoreBookings;

            //bool ok = false;
            //for (int i = 0; i < _schedule.ListOfBookings.Count - 1; i++)
            //{
            //    Booking firstBooking = _schedule.ListOfBookings[i];
            //    Booking secondBooking = _schedule.ListOfBookings[i + 1];

            //    if (firstBooking.EndTime < newBooking.StartTime && secondBooking.StartTime > newBooking.EndTime)
            //    {
            //        ok = true;
            //    }
            //}
            //return ok;
        }
        private bool CheckAvailabilityBeforeFirstBooking(Booking newBooking, int i, Booking firstBooking)
        {
            if (newBooking.EndTime < firstBooking.StartTime && i == 0)
            {
                return true;
            }
            return false;
        }
        private bool CheckAvailabilityBetweenBookings(Booking newBooking, int NoOfBookings, int i, Booking firstBooking)
        {
            if (NoOfBookings > 0 && NoOfBookings - 1 > i)
            {
                Booking secondBooking = _schedule.ListOfBookings[i + 1];
                if (firstBooking.EndTime <= newBooking.StartTime && secondBooking.StartTime >= newBooking.EndTime)
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckAvailabilityAfterLastBooking(Booking newBooking, int i, int NoOfBookings)
        {
            if (NoOfBookings > 0)
            {
                Booking lastBooking = _schedule.ListOfBookings[NoOfBookings - 1];
                if (i == NoOfBookings - 1 && newBooking.StartTime >= lastBooking.EndTime)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
