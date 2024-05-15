using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BokningsProgram
{
    public class SSK : BookableItem
    {
        private string _name;
		private string _HSAid;
        private List<KompetensLevel> _kompetenser;
        //private KompetensLevel _kompetens;

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
        public List<KompetensLevel> Kompetenser
		{
			get { return _kompetenser; } 
			set { _kompetenser = value; } 
		}
        public SSK() { }
        public SSK(string name, string hsaID, List<KompetensLevel> kompetenser)
        {
			_name = name;
			_HSAid = hsaID;
            _kompetenser = kompetenser;
            
            //if (_kompetenser.Contains(KompetensLevel.Piccline))
            //{
            //    this.HasSecondSchedule = true;
            //    foreach (var day in ScheduledDays.Days)
            //    {
            //        day.AddSecondListOfBookings(day.StartOfDay);
            //    }
            //}
        }
        public void GenerateSecondBookings()
        {
            if (_kompetenser.Contains(KompetensLevel.Piccline))
            {
                this.HasSecondSchedule = true;
                foreach (var day in ScheduledDays.Days)
                {
                    day.AddSecondListOfBookings(day.StartOfDay);
                }
            }
        }
        public bool IsCompetentEnough(Booking booking)
        {
            bool sskOK = false;

            if (booking.RoomRequired == RoomCategory.PicclineIn && _kompetenser.Contains(KompetensLevel.Piccline))
            {
                sskOK = true;
            }
            else if (booking.Description.Equals("Telefon") && _kompetenser.Contains(KompetensLevel.Telefon))
            {
                sskOK = true;
            }
            else if (booking.Description.Equals("Tablett") && _kompetenser.Contains(KompetensLevel.Tablett))
            {
                sskOK = true;
            }
            else if (!booking.Description.Equals("Tablett") && !booking.Description.Equals("Telefon") && booking.RoomRequired != RoomCategory.PicclineIn)
            {
                sskOK = true;
            }
                
            return sskOK;
            
        }
        public override string ToString()
        {
			string strOut = $"{_name}, {_HSAid}";//Ta bort kompetens när QA är klar
			return strOut;
        }
    }
}
