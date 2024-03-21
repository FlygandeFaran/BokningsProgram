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

		public List<DailySchedule> Dagar
		{
			get { return _dagar; }
			//set { _dagar = value; }
		}
	}
}
