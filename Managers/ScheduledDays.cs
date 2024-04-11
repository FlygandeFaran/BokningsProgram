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
        private void GenerateSCheduleDays()
		{
			DateTime date = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
				date = date.AddDays(i);
                DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
                DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
                _dagar.Add(new DailySchedule(startOfDay, endOfDay));
			}
			//Load excelsheet and create new DailySchedules for each day with an end and start time
		}
	}
}
