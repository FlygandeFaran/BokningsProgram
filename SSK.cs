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
        //}
        public SSK() { }
        public SSK(string name, string HSAid, KompetensLevel kompetens)
        {
			_name = name;
			_HSAid = HSAid;
			_kompetens = kompetens;
			_schedule = new DailySchedule();
		}
        public bool IsCompetentEnough(Booking booking)
        {
            bool sskOK = false;

            if (booking.RoomRequired == RoomCategory.PicclineIn && _kompetens == KompetensLevel.Pickline)
            {
                sskOK = true;
            }
            else if (booking.RoomRequired != RoomCategory.PicclineIn)
            {
                sskOK = true;
            }
                
            return sskOK;
            
        }
		public bool IsTheyBooked(Booking newBooking) //bra engelska...
        {
            int NoOfBookings = _schedule.ListOfBookings.Count;
            if (NoOfBookings == 0) //Om det inte finns någon bokning är det garanterat ledigt
                return false;

            bool ok = false;
            bool noMoreBookings = false;
            int i = 0;

            while (!ok) //kollar om bokning passar in i schemat
            {
                Booking booking = _schedule.ListOfBookings[i];
                if (CheckAvailabilityBeforeFirstBooking(newBooking, i, booking))//False om det finns lucka innan först bokade tid
                    ok = true;
                else if (CheckAvailabilityBetweenBookings(newBooking, NoOfBookings, i, booking))//False om det finns tid mellan två bokningar
                    ok = true;
                else if (ok = CheckAvailabilityAfterLastBooking(newBooking, booking, i, NoOfBookings))//False om det finns tid efter sista bokningen
                    ok = true;

                i++;
                if (i == NoOfBookings && !ok)//Om det inte finns någon tid alls
                {
                    ok = true;
                    noMoreBookings = true;//isTheyBooked blir true
                }
            }
            return noMoreBookings;
		}

        private bool CheckAvailabilityBeforeFirstBooking(Booking newBooking, int i, Booking firstBooking)
        {
            if (newBooking.EndTime < firstBooking.StartTime && i == 0)
            {
                return true;
            }
            return false;
        }
        private bool CheckAvailabilityBetweenBookings(Booking newBooking, int NoOfBookings, int i, Booking firstBooking)
        {
            if (NoOfBookings > 0 && NoOfBookings - 1 > i)
            {
                Booking secondBooking = _schedule.ListOfBookings[i + 1];
                if (firstBooking.EndTime <= newBooking.StartTime && secondBooking.StartTime >= newBooking.EndTime)
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckAvailabilityAfterLastBooking(Booking newBooking, Booking lastBooking, int i, int NoOfBookings)
        {
            if (NoOfBookings > 0)
            {
                lastBooking = _schedule.ListOfBookings[NoOfBookings - 1];
                if (i == NoOfBookings - 1 && newBooking.StartTime >= lastBooking.EndTime)
                {
                    return true;
                }
            }
            return false;
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
