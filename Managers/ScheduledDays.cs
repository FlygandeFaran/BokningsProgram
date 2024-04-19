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
        public void GenerateSCheduleDays()
		{
			DateTime date = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
                _dagar.Add(new DailySchedule(startOfDay, endOfDay));
                date = date.AddDays(1);
            }
            //Load excelsheet and create new DailySchedules for each day with an end and start time
        }
        public DailySchedule GetDailyScheduleOfBooking(Booking booking)
        {
            DailySchedule ds = null;
            ds = _dagar.FirstOrDefault(dailySchedule =>
                                    dailySchedule.FirstlistOfBookings.Any(booked => booked.ID == booking.ID) ||
                                    dailySchedule.SecondlistOfBookings.Any(booked => booked.ID == booking.ID));

            return ds;
        }
    }
}
