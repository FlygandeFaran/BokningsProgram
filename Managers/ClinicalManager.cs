using BokningsProgram.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

            //ska tas bort innan klar
            File.Delete("SSK.xml");
            File.Delete("Rooms.xml");
            exportRooms();
            exportStaff();
            InitializeStaff();
            InitializeRooms();
        }
        private void InitializeStaff()
        {
            _sskManager.ImportFromXml();
        }

        private void exportStaff()
        {
            _sskManager.ListOfSSK.Add(new SSK("Erik", "34VB", KompetensLevel.Pickline));
            _sskManager.ListOfSSK.Add(new SSK("Linnea", "16LL", KompetensLevel.None));
            _sskManager.ExportToXml();
        }

        private void InitializeRooms()
        {
            _roomManager.ImportFromXml();
        }

        private void exportRooms()
        {
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 3));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 4));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Quad, 7));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 8));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 9));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 12));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 13));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 14));

            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 16));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 17));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 23));

            _roomManager.ListOfRooms.Add(new Room(RoomCategory.PicclineIn, 1));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.PicclineOm, 2));
            _roomManager.ExportToXml();
        }
        //Öppnar en ny ruta med möjlighet att uppdatera bookning genom att ta bort och lägga till uppdaterade bookning
        public bool ChangeBooking(int index, DateTime startOfBooking, DateTime endOfBooking)
        {
            bool ok = false;
            var ssk = _sskManager.ListOfSSK[index];

            Booking selectedBooking = ScheduledDays.GetBooking(startOfBooking, endOfBooking, ssk);


            Room selectedRoom = _roomManager.GetRoomFromBooking(selectedBooking);

            if (selectedBooking is Booking)
            {
                ChangeBooking changeBooking = new ChangeBooking(selectedBooking, ssk, _roomManager.ListOfRooms, _sskManager.ListOfSSK);
                DialogResult dlgResult = changeBooking.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    Booking newBooking = selectedBooking.CopyBooking(selectedBooking);
                    DailySchedule ds = ssk.ScheduledDays.GetDailyScheduleOfBooking(selectedBooking);
                    ds.RemoveBooking(newBooking);
                    ds = selectedRoom.ScheduledDays.GetDailyScheduleOfBooking(selectedBooking);
                    ds.RemoveBooking(newBooking);

                    SuggestBooking(newBooking, changeBooking.Ssk);
                    
                    ok = true;
                }
            }
            else
                MessageBox.Show("Kunde inte hitta någon bokning", "Hoppsan");
            return ok;
        }
        private void SuggestBooking(Booking booking)
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
        public void SuggestBooking(Booking booking, SSK ssk)
        {
            //Check for ssk
            bool sskOK = false;
            if (ssk is SSK)
            {
                sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk);
                if (sskOK)
                {
                    bool roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom);
                    if (roomOK)
                    {
                        //lägg till bekräftelse av användaren
                        _sskManager.AddBooking(booking, ssk);
                        _roomManager.AddBooking(booking, availableRoom);
                    }
                }
                else
                {
                    ContinueToSearchForSlotDialog continueToSearchForSlotDialog = new ContinueToSearchForSlotDialog();
                    DialogResult result = continueToSearchForSlotDialog.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        SuggestBooking(booking);
                    }
                }
            }
            else
            {
                SuggestBooking(booking);
            }
        }
    }
}
