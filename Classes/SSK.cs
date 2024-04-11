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
        private ScheduledDays _scheduledDays;
        private string _name;
		private string _HSAid;
        private KompetensLevel _kompetens;
        private bool _isBooked;

        public ScheduledDays ScheduledDays
        {
            get { return _scheduledDays; }
            set { _scheduledDays = value; }
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
        public SSK(string name, string hsaID, KompetensLevel kompetens)
        {
			_name = name;
			_HSAid = hsaID;
			_kompetens = kompetens;
            _scheduledDays = new ScheduledDays(_HSAid);
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
        public override string ToString()
        {
			string strOut = $"{_name}, {_HSAid}, {_kompetens}";//Ta bort kompetens när QA är klar
			return strOut;
        }

    }
}
