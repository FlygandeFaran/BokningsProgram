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
        private bool _hasSecondSchedule;
        private ScheduledDays _scheduledDays;

        public ScheduledDays ScheduledDays
        {
            get { return _scheduledDays; }
            set { _scheduledDays = value; }
        }
        public bool HasSecondSchedule
        {
            get { return _hasSecondSchedule; }
            set { _hasSecondSchedule = value; }
        }
        public BookableItem()
        {
            _scheduledDays = new ScheduledDays();
            _scheduledDays.GenerateSCheduleDays();
        }
        public bool IsItBooked(Booking newBooking, bool secondTrack)
        {
            _schedule = _scheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear == newBooking.StartTime.DayOfYear);
            int NoOfBookings;
            if (secondTrack && _hasSecondSchedule)
            {
                NoOfBookings = _schedule.SecondlistOfBookings.Count;
            }
            else
            {
                NoOfBookings = _schedule.FirstlistOfBookings.Count;
            }

            bool ok = false;
            bool isItBooked = false;
            int i = 0;

            if (newBooking.FullDay)
                isItBooked = !_schedule.CheckAvailabilityForFullDay();
            else
            {
                while (!ok) //kollar om bokning passar in i schemat
                {
                    ok = _schedule.CheckAvailability(newBooking, i, secondTrack);

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
        public void AddBooking(Booking booking, bool secondTrack, int bookingID)
        {
            _schedule.AddBooking(booking, secondTrack, bookingID);
        }
        public DailySchedule GetDailyScheduleOfBooking(Booking booking, bool secondTrack)
        {
            DailySchedule ds = _scheduledDays.GetDailyScheduleOfBooking(booking, secondTrack);
            return ds;
        }
    }
}
