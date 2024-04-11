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
                DateTime startOfDay = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                DateTime endOfDay = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
                _dagar.Add(new DailySchedule(startOfDay, endOfDay));
                date = date.AddDays(1);
            }
			//Load excelsheet and create new DailySchedules for each day with an end and start time
		}
	}
}
