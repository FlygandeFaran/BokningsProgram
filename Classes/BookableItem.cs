﻿using System;
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
            //_scheduledDays.GenerateSCheduleDays();
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
                isItBooked = !_schedule.CheckAvailabilityForFullDay(secondTrack);
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
            if (!isItBooked && secondTrack)
                ok = false;
            return isItBooked;
        }
        public void AddBooking(Booking booking, bool secondTrack, int bookingID)
        {
            _schedule = _scheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear == booking.StartTime.DayOfYear);
            _schedule.AddBooking(booking, secondTrack, bookingID);
        }
        public List<Booking> GetAllBookingsFromDay(DateTime date)
        {
            List<Booking> bookings = new List<Booking>();
            DailySchedule ds = _scheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear == date.DayOfYear);
            foreach (var booking in ds.FirstlistOfBookings)
            {
                if (booking.ID != 0)
                    bookings.Add(booking);
            }
            if (_hasSecondSchedule)
                foreach (var booking in ds.SecondlistOfBookings)
                {
                    if (booking.ID != 0)
                        bookings.Add(booking);
                }
            return bookings;
        }
        public DailySchedule GetDailyScheduleOfBooking(Booking booking)
        {
            DailySchedule ds = _scheduledDays.GetDailyScheduleOfBooking(booking);
            return ds;
        }
        public void ClearAllBookings()
        {
            foreach (var day in _scheduledDays.Days)
            {
                day.FirstlistOfBookings.RemoveAll(b => b.ID > 2);
                if (day.SecondlistOfBookings != null)
                {
                    day.SecondlistOfBookings.RemoveAll(b => b.ID > 2);
                }
            }
        }
    }
}
