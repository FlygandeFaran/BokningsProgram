using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class ScheduledDays
    {
		private List<DailySchedule> _dagar;
		private string _hsaID;
		private int _roomNumber;

        public List<DailySchedule> Days
		{
			get { return _dagar; }
            set { _dagar = value; }
        }
        public ScheduledDays()
        {
            _dagar = new List<DailySchedule>();
            //GenerateSCheduleDays();
        }
        //public ScheduledDays(string hsaID)
        //{
        //    _hsaID = hsaID;
        //    _dagar = new List<DailySchedule>();
        //    GenerateSCheduleDays();
        //}
        //public ScheduledDays(int roomNumber)
        //{
        //    _roomNumber = roomNumber;
        //    _dagar = new List<DailySchedule>();
        //    GenerateSCheduleDays();
        //}
        public static Booking GetBooking(DateTime start, DateTime end, string description, SSK ssk, bool secondTrack)
        {
            Booking booking;
            if (secondTrack)
            {
                booking = ssk.ScheduledDays.Days.SelectMany(ds =>
                                                                ds.SecondlistOfBookings).FirstOrDefault(booked =>
                                                                booked.StartTime == start &&
                                                                booked.EndTime == end &&
                                                                booked.Description == description);
            }
            else
            {
                booking = ssk.ScheduledDays.Days.SelectMany(ds =>
                                                                ds.FirstlistOfBookings).FirstOrDefault(booked =>
                                                                booked.StartTime == start &&
                                                                booked.EndTime == end &&
                                                                booked.Description == description);
            }
            return booking;
        }
        public void GenerateSCheduleDaysForSSK(List<DateTime> startTimes, List<DateTime> endTimes)
        {
            //DateTime date = DateTime.Now;
            //for (int i = 0; i < 10; i++)
            //{
            //    DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
            //    DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
            //    _dagar.Add(new DailySchedule(startOfDay, endOfDay));
            //    date = date.AddDays(1);
            //}
            for (int i = 0; i < startTimes.Count; i++)
            {
                var day = _dagar.FirstOrDefault(d => d.StartOfDay.DayOfYear == startTimes[i].DayOfYear && d.StartOfDay.Year == startTimes[i].Year);
                if (day == null)
                    _dagar.Add(new DailySchedule(startTimes[i], endTimes[i]));
            }
        }
        public void GenerateSCheduleDaysForRooms(List<DateTime> dates)
        {
            foreach (var day in dates)
            {
                DateTime startOfDay;
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                    startOfDay = new DateTime(day.Year, day.Month, day.Day, 16, 0, 0);
                else
                    startOfDay = new DateTime(day.Year, day.Month, day.Day, 7, 0, 0);

                DateTime endOfDay = new DateTime(day.Year, day.Month, day.Day, 16, 0, 0);
                var date = _dagar.FirstOrDefault(d => d.StartOfDay.DayOfYear == day.DayOfYear && d.StartOfDay.Year == day.Year);
                if (date == null)
                    _dagar.Add(new DailySchedule(startOfDay, endOfDay));
            }
            //Load excelsheet and create new DailySchedules for each day with an end and start time
        }
        public DailySchedule GetDailyScheduleOfBooking(Booking booking)
        {
            DailySchedule ds = null;
            ds = _dagar.FirstOrDefault(dailySchedule =>
                                    dailySchedule.FirstlistOfBookings.Any(booked => booked.ID == booking.ID &&
                                                                            booked.StartTime == booking.StartTime) ||
                                    dailySchedule.SecondlistOfBookings.Any(booked => booked.ID == booking.ID &&
                                                                            booked.StartTime == booking.StartTime));

            return ds;
        }
    }
}
