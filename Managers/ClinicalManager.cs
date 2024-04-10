using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BokningsProgram.Managers
{
    public class ClinicalManager
    {
        //private DateTime _endOfDay;
        private SSKmanager _sskManager;
        private RoomManager _roomManager;

        public RoomManager RoomManager
        {
            get { return _roomManager; }
            set { _roomManager = value; }
        }
        public SSKmanager SskManager
        {
            get { return _sskManager; }
            set { _sskManager = value; }
        }

        public ClinicalManager()
        {
            _roomManager = new RoomManager();
            _sskManager = new SSKmanager();
            //DateTime today = DateTime.Now;
            //_endOfDay = new DateTime(today.Year, today.Month, today.Day, 16, 0, 0);

            InitializeStaff();
        }
        private void InitializeStaff()
        {
            _sskManager.ImportFromXml();
            //_sskm.ListOfSSK.Add(new SSK("Erik", "34VB", KompetensLevel.Pickline));
            //_sskm.ListOfSSK.Add(new SSK("Linnea", "16LL", KompetensLevel.None));
            _sskManager.ExportToXml();
        }

        public void SuggestBooking(Booking booking)
        {
            //Check for ssk
            bool sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out SSK availableSSK);
            if (sskOK)
            {
                bool roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom);
                if (roomOK)
                {
                    //lägg till bekräftelse av användaren
                    _sskManager.AddBooking(booking, availableSSK);
                    _roomManager.AddBooking(booking, availableRoom);
                }
            }
        }
    }
}
