using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BokningsProgram
{
    public class SSK
    {
        private DailySchedule _schedule;
		private string _name;
		private string _HSAid;
        private KompetensLevel _kompetens;
        private bool _isBooked;

        public DailySchedule Schedule
		{
			get { return _schedule; }
			set { _schedule = value; }
		}
		public string HSAID
		{
			get { return _HSAid; }
			set { _HSAid = value; }
		}
		public string Name
		{
            get { return _name; }
			set { _name = value; }
        }
        [XmlAttribute] // Include the enum value in the XML output
        public KompetensLevel Kompetens
		{
			get { return _kompetens; } 
			set { _kompetens = value; } 
		}
		//public bool IsBokad
		//{
		//	get { return _isBooked; }
  //      }
        public SSK() { }
        public SSK(string name, string HSAid, KompetensLevel kompetens)
        {
			_name = name;
			_HSAid = HSAid;
			_kompetens = kompetens;
			_schedule = new DailySchedule();
		}
		public bool IsTheyBooked(Booking newBooking) //bra engelska...
		{
			bool ok = false;
			int NoOfBookings = _schedule.ListOfBookings.Count;

            for (int i = 0; i < NoOfBookings; i++)
			{
				Booking firstBooking = _schedule.ListOfBookings[i];

				if (newBooking.EndTime < firstBooking.StartTime)
				{
					ok = true;
				}
				if (NoOfBookings > 0 && NoOfBookings - 1 > i)
				{
                    Booking secondBooking = _schedule.ListOfBookings[i + 1];
                    if (firstBooking.EndTime < newBooking.StartTime || secondBooking.StartTime > newBooking.EndTime)
                    {
                        ok = true;
                    }
                }
            }
			return ok;
		}
		public void AddBooking(Booking booking)
		{
			_schedule.AddBooking(booking);
		}
        public override string ToString()
        {
			string strOut = $"{_name}, {_HSAid}, {_kompetens}";//Ta bort kompetens när QA är klar
			return strOut;
        }
    }
}
