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

namespace BokningsProgram.Managers
{
    public class ClinicalManager
    {
        //private DateTime _endOfDay;
        private MeetingManager _meetingManager;
        private SSKmanager _sskManager;
        private RoomManager _roomManager;
        private int _bookingID;

        public MeetingManager MeetingManager
        {
            get { return _meetingManager; }
            set { _meetingManager = value; }
        }
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
            _meetingManager = new MeetingManager();
            _roomManager = new RoomManager();
            _sskManager = new SSKmanager();
            GetID();
            //ska tas bort innan klar
            //RensaOchStartaOmDatabas();

            InitializeStaff();
            InitializeRooms();
            initializeMeetings();
        }

        private void RensaOchStartaOmDatabas()
        {
            File.Delete("SSK.xml");
            File.Delete("Rooms.xml");
            CreateRooms();
            CreateSSK();
            ImportSchedules();

            exportMeetings();
            exportRooms();
            exportStaff();
        }

        private void InitializeStaff()
        {
            _sskManager.ImportFromXml();
        }
        private void GetID()
        {
            string filename = "bookingID.txt";
            _bookingID = int.Parse(File.ReadAllText(filename));
            string content = (++_bookingID).ToString();
            File.WriteAllText(filename, content);

        }
        public void ImportSchedules()
        {
            ExcelImport excelImport = new ExcelImport();
            excelImport.ImportSchedules(_sskManager, _roomManager);
            _sskManager.GenerateSecondSchedule();
            _roomManager.CreateAllBeds();
        }
        private void CreateSSK()
        {
            List<KompetensLevel> kompetensLevelsErik = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevelsMaiar = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett };
            List<KompetensLevel> kompetensLevelsLinnea = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett, KompetensLevel.Telefon };

            _sskManager.ListOfSSK.Add(new SSK("Erik", "34VB", kompetensLevelsErik));
            _sskManager.ListOfSSK.Add(new SSK("Maiar", "56gh", kompetensLevelsMaiar));
            _sskManager.ListOfSSK.Add(new SSK("Linnea", "16LL", kompetensLevelsLinnea));
        }
        public void exportStaff()
        {
            _sskManager.ExportToXml();
        }
        private void initializeMeetings()
        {
            _meetingManager.ImportFromXml();
        }
        public void exportMeetings()
        {
            _meetingManager.ExportToXml();
        }

        private void InitializeRooms()
        {
            _roomManager.ImportFromXml();
        }
        private void CreateRooms()
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
        }
        public void exportRooms()
        {
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
                if (selectedBooking.Description.Equals("Lunch"))
                {
                    EditLunchBooking(selectedSSK, selectedBooking, newBooking);
                }
                else
                    EditBooking(selectedSSK, selectedBooking, selectedRoom, newBooking, changeBooking.Ssk);

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
        private void EditLunchBooking(SSK selectedSSK, Booking selectedBooking, Booking newBooking)
        {
            DailySchedule ds = selectedSSK.GetDailyScheduleOfBooking(selectedBooking);
            ds.RemoveBooking(selectedBooking);
            if (selectedSSK.HasSecondSchedule)
            {
                Booking tempBooking = new Booking(selectedBooking);
                selectedBooking = ScheduledDays.GetBooking(tempBooking.StartTime, tempBooking.EndTime, tempBooking.Description, selectedSSK, true);
                if (selectedBooking == null)
                    selectedBooking = ScheduledDays.GetBooking(tempBooking.StartTime, tempBooking.EndTime, tempBooking.Description, selectedSSK, false);
                ds = selectedSSK.GetDailyScheduleOfBooking(selectedBooking);
                ds.RemoveBooking(selectedBooking);
            }
            bool ok = SuggestBookingForSpecificBooking(newBooking, selectedSSK, 1);
            if (!ok)
            {
                SuggestBookingForSpecificBooking(selectedBooking, selectedSSK, 1);
                MessageBox.Show("Kunde inte flytta lunchen dit");
            }
        }
        public void AddMeetingBookings()
        {
            int i;
            foreach (Meeting meeting in _meetingManager.ListOfMeetings)
            {
                int interval = meeting.Intervall * 7;
                foreach (string sskName in meeting.NamesOfSSK)
                {
                    bool intervalOK = true;
                    i = 0;
                    SSK ssk = _sskManager.GetSSKfromName(sskName);
                    foreach (var days in ssk.ScheduledDays.Days)
                    {
                        if (days.StartOfDay > meeting.Time)
                        {
                            if (i == interval)
                            {
                                intervalOK = true;
                            }
                            bool dayOK = meeting.DayOfWeek.Any(d => d.Equals(days.StartOfDay.DayOfWeek));
                            if (dayOK && intervalOK)
                            {
                                i = 0;
                                DateTime start = new DateTime(days.StartOfDay.Year, days.StartOfDay.Month, days.StartOfDay.Day, meeting.Time.Hour, 0, 0);
                                DateTime end = new DateTime(days.StartOfDay.Year, days.StartOfDay.Month, days.StartOfDay.Day, meeting.Time.Hour + 1, 0, 0);
                                Booking booking = new Booking(start, end, meeting.NameOfMeeting, RoomCategory.Dubbel, false);
                                GetID();
                                bool bookingOK = SuggestBookingForSpecificBooking(booking, ssk, _bookingID);
                                if (bookingOK)
                                {
                                    meeting.BookedMeetings.Add(booking);
                                }
                                intervalOK = false;
                            }
                            i++;
                        }
                    }
                }
            }
        }

        private void EditBooking(SSK selectedSSK, Booking selectedBooking, Room selectedRoom, Booking newBooking, SSK newSSK)
        {
            DailySchedule ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
            if (ds == null)
                ds = selectedRoom.GetDailyScheduleOfBooking(selectedBooking);
            ds.RemoveBooking(selectedBooking);

            SuggestBooking(newBooking, newSSK, false);

            ds = selectedSSK.GetDailyScheduleOfBooking(selectedBooking);
            ds.RemoveBooking(selectedBooking);
        }

        private void SuggestBooking(Booking booking, bool isNewBooking)
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
                    if (booking.ID > 2 || isNewBooking)
                    {
                        GetID();
                        _sskManager.AddBooking(booking, availableSSK, sskSecondTrackBooking, _bookingID);
                        _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, _bookingID);
                    }
                    else
                    {
                        _sskManager.AddBooking(booking, availableSSK, sskSecondTrackBooking, booking.ID);
                        _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, booking.ID);
                    }
                }
                else
                    MessageBox.Show("Hittade inget ledigt rum för bokningen", "Hoppsan");
            }
            else
                MessageBox.Show("Hittade ingen ledig tid för bokningen", "Hoppsan");

        }
        public bool SuggestBookingForSpecificBooking(Booking booking, SSK ssk, int bookingID)
        {
            bool sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk, false);
            if (sskOK && ssk.HasSecondSchedule)
                sskOK = _sskManager.CheckBookingForSelectedSSK(booking, ssk, true);
            
            if (sskOK)
            {
                _sskManager.AddBooking(booking, ssk, false, bookingID);
                if (ssk.HasSecondSchedule)
                    _sskManager.AddBooking(booking, ssk, true, bookingID);
            }
            return sskOK;
        }
        //Föreslår en bokning med medföljande ssk, om inte går körs vanliga suggestbooking
        public void SuggestBooking(Booking booking, SSK ssk, bool isNewBooking)
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

                        if (booking.ID > 2 || isNewBooking)
                        {
                            GetID();
                            _sskManager.AddBooking(booking, ssk, sskSecondTrackBooking, _bookingID);
                            _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, _bookingID);
                        }
                        else
                        {
                            _sskManager.AddBooking(booking, ssk, sskSecondTrackBooking, booking.ID);
                            _roomManager.AddBooking(booking, availableRoom, roomSecondTrackBooking, booking.ID);
                        }
                    }
                }
                else
                {
                    ContinueToSearchForSlotDialog continueToSearchForSlotDialog = new ContinueToSearchForSlotDialog();
                    DialogResult result = continueToSearchForSlotDialog.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        SuggestBooking(booking, isNewBooking);
                    }
                }
            }
            else
            {
                SuggestBooking(booking, isNewBooking);
            }
        }
        public void SuggestMultipleBookings(List<Booking> multipleBookings)
        {
            SSK ssk = GetFreeSSK(multipleBookings, out List<Booking> bookings);
            if (ssk is SSK)
            {
                foreach (var booking in bookings)
                {
                    SuggestBooking(booking, ssk, true);
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
            GetID();
            _sskManager.AddBooking(sickBooking, sickSSK, false, _bookingID);
            if (sickSSK.HasSecondSchedule)
                _sskManager.AddBooking(sickBooking, sickSSK, true, _bookingID);
        }
        public void ClearAllBookings()
        {
            _sskManager.ClearAllBookings();
            _roomManager.ClearAllBookings();
        }
        public List<string> BookingDescriptions()
        {
            List<string> bookingDescriptions = new List<string>
            {
                "Abraxane/Gemzar",
                "CAPOX",
                "Cemiplimab",
                "Cisplatin",
                "Docetaxel",
                "EC",
                "FLOT",
                "FLV",
                "FLV/Bevacizumab",
                "FOLFIRI",
                "FOLFOX",
                "Gemcitabin",
                "Gemcitabin/Nab-Paklitaxel",
                "Gemzar",
                "Ipilimumab/Nivolumab",
                "Karboplatin/Etoposid",
                "Karboplatin/Irinotekan",
                "Karboplatin/Paklitaxel",
                "Nivolumab",
                "Paklitaxel",
                "Piccline",
                "R-CHOP",
                "Rituximab",
                "Rituximab/Bendamustin",
                "Trastuzumab",
                "",
                "Telefon",
                "Tablett",
                "",
                "Vanlig"
            };

            return bookingDescriptions;
        }
    }
}
