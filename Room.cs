using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Room
    {
        private DailySchedule _schedule;
        private RoomCategory _roomType;
        private int _roomNumber;

        public DailySchedule Schedule
        {
            get { return _schedule; }
            set { _schedule = value; }
        }
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
            _schedule = new DailySchedule();
        }
        public void AddBooking(Booking booking)
        {
            _schedule.AddBooking(booking);
        }
        public bool IsItBooked(Booking newBooking) //bra engelska...
        {
            bool ok = false;
            for (int i = 0; i < _schedule.ListOfBookings.Count - 1; i++)
            {
                Booking firstBooking = _schedule.ListOfBookings[i];
                Booking secondBooking = _schedule.ListOfBookings[i + 1];

                if (firstBooking.EndTime < newBooking.StartTime && secondBooking.StartTime > newBooking.EndTime)
                {
                    ok = true;
                }
            }
            return ok;
        }
    }
}
