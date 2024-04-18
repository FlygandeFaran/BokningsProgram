using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class BookableItem
    {
        private DailySchedule _schedule;
        private bool _isFullDayBooked;

        public bool IsFullDayBooked
        {
            get { return _isFullDayBooked; }
            set { _isFullDayBooked = value; }
        }

        public BookableItem()
        {

        }

        public bool IsItBooked(Booking newBooking, ScheduledDays scheduledDays)
        {
            _schedule = scheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear == newBooking.StartTime.DayOfYear);
            int NoOfBookings = _schedule.ListOfBookings.Count;
            if (NoOfBookings == 0) //Om det inte finns någon bokning är det garanterat ledigt
                return false;

            bool ok = false;
            bool isItBooked = false;
            int i = 0;

            if (newBooking.FullDay && !IsFullDayBooked)
                isItBooked = !_schedule.CheckAvailabilityForFullDay();
            else
            {
                while (!ok) //kollar om bokning passar in i schemat
                {
                    Booking booking = _schedule.ListOfBookings[i];

                    ok = _schedule.CheckAvailability(newBooking, i);

                    i++;
                    if (i == NoOfBookings && !ok)//Om det inte finns någon tid alls
                    {
                        ok = true;
                        isItBooked = true;//isTheyBooked blir true
                    }
                }
            }

            return isItBooked;
        }
        public void AddBooking(Booking booking)
        {
            if (booking.FullDay)
            {
                IsFullDayBooked = true;
            }
            _schedule.AddBooking(booking);
        }
    }
}
