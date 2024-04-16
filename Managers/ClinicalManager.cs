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
            _sskManager.ListOfSSK.Add(new SSK("Erik", "34VB", KompetensLevel.Piccline));
            _sskManager.ListOfSSK.Add(new SSK("Maiar", "56gh", KompetensLevel.Piccline));
            _sskManager.ListOfSSK.Add(new SSK("Linnea", "16LL", KompetensLevel.None));
            _sskManager.ExportToXml();
        }

        private void InitializeRooms()
        {
            _roomManager.ImportFromXml();
        }

        private void exportRooms()
        {
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 3.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 4.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, "7a"));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, "7b"));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 8.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 9.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 12.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 13.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Dubbel, 14.ToString()));

            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 16.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 17.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.Enkel, 23.ToString()));

            _roomManager.ListOfRooms.Add(new Room(RoomCategory.PicclineIn, 1.ToString()));
            _roomManager.ListOfRooms.Add(new Room(RoomCategory.PicclineOm, 2.ToString()));
            _roomManager.ExportToXml();
        }
        //Öppnar en ny ruta med möjlighet att uppdatera bookning genom att ta bort och lägga till uppdaterade bookning
        public bool ChangeBooking(int index, DateTime startOfBooking, DateTime endOfBooking, string bookableObject, string description)
        {
            bool ok = false;
            var selectedSSK = _sskManager.ListOfSSK[index];

            Booking selectedBooking = ScheduledDays.GetBooking(startOfBooking, endOfBooking, selectedSSK);

            Room selectedRoom = _roomManager.GetRoomFromBooking(selectedBooking);

            if (selectedBooking is Booking)
            {
                ChangeBooking changeBooking = new ChangeBooking(selectedBooking, selectedSSK, _roomManager.ListOfRooms, _sskManager.ListOfSSK);
                DialogResult dlgResult = changeBooking.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    Booking newBooking = new Booking();
                    newBooking.CopyBooking(selectedBooking);
                    DailySchedule ds = selectedSSK.GetDailyScheduleOfBookingFromSSK(selectedBooking);
                    ds.RemoveBooking(newBooking);
                    ds = selectedRoom.GetDailyScheduleOfBookingFromRoom(selectedBooking);
                    ds.RemoveBooking(newBooking);

                    SuggestBooking(newBooking, changeBooking.Ssk);
                    
                    ok = true;
                }
                else if (dlgResult == DialogResult.Abort)
                {
                    DailySchedule ds = selectedSSK.GetDailyScheduleOfBookingFromSSK(selectedBooking);
                    ds.RemoveBooking(selectedBooking);
                    ds = selectedRoom.GetDailyScheduleOfBookingFromRoom(selectedBooking);
                    ds.RemoveBooking(selectedBooking);
                }
            }
            else
                MessageBox.Show("Kunde inte hitta någon bokning", "Hoppsan");
            return ok;
        }
        private void SuggestBooking(Booking booking)
        {
            //Check for ssk
            bool sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out SSK availableSSK, false);
            if (!sskOK)
                sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out availableSSK, true);//check second track

            if (sskOK)
            {
                bool roomOK = !_roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom, false);
                if (!roomOK)
                    roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out availableRoom, true);//Check second track

                if (roomOK)
                {
                    //lägg till bekräftelse av användaren
                    _sskManager.AddBooking(booking, availableSSK);
                    _roomManager.AddBooking(booking, availableRoom);
                }
            }
            else
                MessageBox.Show("Hittade ingen ledig tid för bokningen", "Hoppsan");

        }
        public void SuggestBooking(Booking booking, SSK ssk)
        {
            bool roomOK = false;
            //Check for ssk
            if (ssk is SSK)
            {
                bool sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk);
                if (sskOK)
                {
                    if (!_roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom, false))
                        roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out availableRoom, true);//Check second track
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
