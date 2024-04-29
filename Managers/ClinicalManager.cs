using BokningsProgram.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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
        private int _bookingID;

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
            GetID();
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
            ExcelImport excelImport = new ExcelImport();
            //excelImport.ImportSSKschedule();
        }
        private void GetID()
        {
            string filename = "bookingID.txt";
            _bookingID = int.Parse(File.ReadAllText(filename));

        }
        public void UpdateID()
        {
            string filename = "bookingID.txt";
            string content = (++_bookingID).ToString();
            File.WriteAllText(filename, content);
        }

        private void exportStaff()
        {
            List<KompetensLevel> kompetensLevelsErik = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevelsMaiar = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett };
            List<KompetensLevel> kompetensLevelsLinnea = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett, KompetensLevel.Telefon };

            _sskManager.ListOfSSK.Add(new SSK("Erik", "34VB", kompetensLevelsErik));
            _sskManager.ListOfSSK.Add(new SSK("Maiar", "56gh", kompetensLevelsMaiar));
            _sskManager.ListOfSSK.Add(new SSK("Linnea", "16LL", kompetensLevelsLinnea));
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
        public bool ChangeBooking(int index, DateTime startOfBooking, DateTime endOfBooking, string description, bool secondTrack)
        {
            bool ok = false;
            var selectedSSK = _sskManager.ListOfSSK[index];

            Booking selectedBooking = ScheduledDays.GetBooking(startOfBooking, endOfBooking, description, selectedSSK, secondTrack);

            if (selectedBooking is Booking)
            {
                ok = UpdateBooking(selectedSSK, selectedBooking);
            }
            else
                MessageBox.Show("Kunde inte hitta någon bokning", "Hoppsan");
            return ok;
        }

        public bool UpdateBooking(SSK selectedSSK, Booking selectedBooking)
        {
            bool ok = false;
            Room selectedRoom = _roomManager.GetRoomFromBooking(selectedBooking);
            Booking newBooking = new Booking(selectedBooking);
            ChangeBooking changeBooking = new ChangeBooking(newBooking, selectedSSK, _roomManager.ListOfRooms, _sskManager.ListOfSSK);
            DialogResult dlgResult = changeBooking.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                DailySchedule ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
                if (ds == null)
                    ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
                ds.RemoveBooking(selectedBooking);

                SuggestBooking(newBooking, changeBooking.Ssk);

                ds = selectedSSK.GetDailyScheduleOfBooking(selectedBooking);
                ds.RemoveBooking(selectedBooking);

                ok = true;
            }
            else if (dlgResult == DialogResult.Abort)
            {
                DailySchedule ds = selectedSSK.GetDailyScheduleOfBooking(selectedBooking);
                ds.RemoveBooking(selectedBooking);
                if (selectedRoom is Room)
                    ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
                if (ds == null)
                    ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
                ds.RemoveBooking(selectedBooking);
            }

            return ok;
        }

        private void SuggestBooking(Booking booking)
        {
            //Check for ssk
            bool sskSecondTrackBooking = false;
            bool roomSecondTrackBooking = false;
            bool sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out SSK availableSSK, false);
            if (!sskOK)
            {
                sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out availableSSK, true);//check second track
                sskSecondTrackBooking = sskOK;
            }

            if (sskOK)
            {
                bool roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom, false);
                if (!roomOK)
                {
                    roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out availableRoom, true);//Check second track
                    roomSecondTrackBooking = roomOK;
                }

                if (roomOK)
                {
                    //lägg till bekräftelse av användaren
                    _bookingID++;
                    _sskManager.AddBooking(booking, availableSSK, sskSecondTrackBooking, _bookingID);
                    _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, _bookingID);
                }
                else
                    MessageBox.Show("Hittade inget ledigt rum för bokningen", "Hoppsan");
            }
            else
                MessageBox.Show("Hittade ingen ledig tid för bokningen", "Hoppsan");

        }
        //Föreslår en bokning med medföljande ssk, om inte går körs vanliga suggestbooking
        public void SuggestBooking(Booking booking, SSK ssk)
        {
            bool roomOK = false;
            //Check for ssk
            bool sskSecondTrackBooking = false;
            bool roomSecondTrackBooking = false;
            if (ssk is SSK)
            {
                bool sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk, sskSecondTrackBooking);
                if (!sskOK)
                {
                    sskSecondTrackBooking = true;
                    sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk, sskSecondTrackBooking);
                }
                if (sskOK)
                {
                    roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out Room availableRoom, sskSecondTrackBooking);
                    if (!roomOK)
                    {
                        sskSecondTrackBooking = true;
                        roomOK = _roomManager.CheckAvailabilityForBooking(booking, out booking, out availableRoom, sskSecondTrackBooking);//Check second track
                    }
                    if (roomOK)
                    {
                        //lägg till bekräftelse av användaren
                        _bookingID++;
                        _sskManager.AddBooking(booking, ssk, sskSecondTrackBooking, _bookingID);
                        _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, _bookingID);
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
        public void SuggestMultipleBookings(List<Booking> multipleBookings)
        {
            SSK ssk = GetFreeSSK(multipleBookings, out List<Booking> bookings);
            if (ssk is SSK)
            {
                foreach (var booking in bookings)
                {
                    SuggestBooking(booking, ssk);
                }
            }
            else
            {
                MessageBox.Show("Hittade ingen tillgänglig tid. Testa att boka var och en för sig", "Aj då");
            }

        }

        private SSK GetFreeSSK(List<Booking> multipleBookings, out List<Booking> bookings)
        {
            SSK noSSK = null;
            bookings = new List<Booking>();

            foreach (KompetensLevel kompetensLevel in Enum.GetValues(typeof(KompetensLevel)))//sorterar efter kompetenser
            {
                foreach (SSK ssk in _sskManager.ListOfSSK)
                {
                    int count = 0;
                    if (ssk.Kompetenser.Contains(kompetensLevel))
                    {
                        bookings = new List<Booking>();
                        foreach (var booking in multipleBookings)
                        {
                            bool ok = true;
                            Booking newBooking = new Booking(booking);
                            while (ok)
                            {
                                ok = _sskManager.CheckBookingForSelectedSSKWithVariableTime(newBooking, out newBooking, ssk);
                                if (ok)
                                    ok = CheckRoomWithSelectedBooking(newBooking, out newBooking);
                                if (ok)
                                {
                                    count++;
                                    ok = false;
                                    bookings.Add(newBooking);
                                }
                            }
                        }
                        if (count == multipleBookings.Count)
                            return ssk;
                    }
                }
            }
            return noSSK;
        }

        private bool CheckRoomWithSelectedBooking(Booking booking, out Booking newBooking)
        {
            bool roomOK = _roomManager.CheckAvailabilityForBooking(booking, out newBooking, out Room availableRoom, false);
            if (!roomOK)
            {
                roomOK = _roomManager.CheckAvailabilityForBooking(newBooking, out newBooking, out availableRoom, true);//Check second track
            }

            return roomOK;
        }
        public void AddSickBooking(SSK sickSSK, Booking sickBooking)
        {
            _bookingID++;
            _sskManager.AddBooking(sickBooking, sickSSK, false, _bookingID);
            if (sickSSK.HasSecondSchedule)
                _sskManager.AddBooking(sickBooking, sickSSK, true, _bookingID);
        }
    }
}
