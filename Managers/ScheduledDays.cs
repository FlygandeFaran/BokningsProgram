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
        public ScheduledDays() { }
        public ScheduledDays(string hsaID)
        {
            _hsaID = hsaID;
            _dagar = new List<DailySchedule>();
            GenerateSCheduleDays();
        }
        public ScheduledDays(int roomNumber)
        {
            _roomNumber = roomNumber;
            _dagar = new List<DailySchedule>();
            GenerateSCheduleDays();
        }
        public static Booking GetBooking(DateTime start, DateTime end, SSK ssk)
        {
            DailySchedule schedule = ssk.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(start.DayOfYear));
            Booking booking = schedule.ListOfBookings.FirstOrDefault(b => { return b.StartTime.Equals(start) && b.EndTime.Equals(end); });
            return booking;
        }
        public static Booking GetBooking(DateTime start, DateTime end, Room room)
        {
            DailySchedule schedule = room.ScheduledDays.Days.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(start.DayOfYear));
            Booking booking = schedule.ListOfBookings.FirstOrDefault(b => { return b.StartTime.Equals(start) && b.EndTime.Equals(end) && b.RoomRequired.Equals(room.RoomType); });
            return booking;
        }
        private void GenerateSCheduleDays()
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
            DailySchedule ds = _dagar.FirstOrDefault(d => d.StartOfDay.DayOfYear.Equals(booking.StartTime.DayOfYear));
            return ds;
        }
    }
}
