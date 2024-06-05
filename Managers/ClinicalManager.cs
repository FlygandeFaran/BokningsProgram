using BokningsProgram.Classes;
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
            File.Delete(@"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\SSK.xml");
            File.Delete(@"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\Rooms.xml");
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
            string filename = @"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\bookingID.txt";
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
            List<KompetensLevel> kompetensLevels1 = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels2 = new List<KompetensLevel>() { KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels3 = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett, KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels4 = new List<KompetensLevel>() { KompetensLevel.Piccline, KompetensLevel.Tablett, KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels5 = new List<KompetensLevel>() { KompetensLevel.Tablett, KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels6 = new List<KompetensLevel>() { KompetensLevel.Tablett, KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels7 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels8 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels9 = new List<KompetensLevel>() { KompetensLevel.Tablett };
            List<KompetensLevel> kompetensLevels10 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels11 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels12 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels13 = new List<KompetensLevel>() { KompetensLevel.Telefon };
            List<KompetensLevel> kompetensLevels14 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels15 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels16 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels17 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels18 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels19 = new List<KompetensLevel>() { KompetensLevel.None };
            List<KompetensLevel> kompetensLevels20 = new List<KompetensLevel>() { KompetensLevel.None };

            _sskManager.ListOfSSK.Add(new SSK("Johanna Axelsson", "34VB", kompetensLevels1));
            _sskManager.ListOfSSK.Add(new SSK("Anna Back", "56gh", kompetensLevels2));
            _sskManager.ListOfSSK.Add(new SSK("Marie Högsberg", "16LL", kompetensLevels3));
            _sskManager.ListOfSSK.Add(new SSK("Monica Kjellvén", "16LL", kompetensLevels3));
            _sskManager.ListOfSSK.Add(new SSK("Maria Sihver", "16LL", kompetensLevels4));
            _sskManager.ListOfSSK.Add(new SSK("Karin Svärd", "16LL", kompetensLevels5));
            _sskManager.ListOfSSK.Add(new SSK("Gustaf Leonardsson", "16LL", kompetensLevels6));
            _sskManager.ListOfSSK.Add(new SSK("Seiko Ishikawa", "16LL", kompetensLevels7));
            _sskManager.ListOfSSK.Add(new SSK("Elaheh Esfandyari Kajouri Rad", "16LL", kompetensLevels8));
            _sskManager.ListOfSSK.Add(new SSK("Liciane Carvalho", "16LL", kompetensLevels9));
            _sskManager.ListOfSSK.Add(new SSK("Emily Eilertsen Eriksson", "16LL", kompetensLevels10));
            _sskManager.ListOfSSK.Add(new SSK("Ann-Cathrine Malmberg", "16LL", kompetensLevels11));
            _sskManager.ListOfSSK.Add(new SSK("Emma Briander", "16LL", kompetensLevels12));
            _sskManager.ListOfSSK.Add(new SSK("Sara Perone", "16LL", kompetensLevels13));
            _sskManager.ListOfSSK.Add(new SSK("Estela Panduro", "16LL", kompetensLevels14));
            _sskManager.ListOfSSK.Add(new SSK("Dinh Hy", "16LL", kompetensLevels15));
            _sskManager.ListOfSSK.Add(new SSK("Sagal Ali", "16LL", kompetensLevels16));
            _sskManager.ListOfSSK.Add(new SSK("Maria Jonsson", "16LL", kompetensLevels17));
            _sskManager.ListOfSSK.Add(new SSK("Elena Skaf", "16LL", kompetensLevels18));
            _sskManager.ListOfSSK.Add(new SSK("Jenny Zwärd", "16LL", kompetensLevels19));
            _sskManager.ListOfSSK.Add(new SSK("Jeanette Sparrenlöv", "16LL", kompetensLevels20));
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
                else if (ds == null)
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

            FirstAvailableBooking(booking, out Booking modifiedBooking, out Room availableRoom, out SSK availableSSK, out bool sskSecondTrackBooking, out bool roomSecondTrackBooking);

            if (availableRoom is Room && availableSSK is SSK)
            {
                ConfirmBooking confirmBooking = new ConfirmBooking(availableSSK.Name, availableRoom.RoomNumber, booking);
                DialogResult result = confirmBooking.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //lägg till bekräftelse av användaren
                    if (booking.ID > 2 || isNewBooking)
                    {
                        GetID();
                        _sskManager.AddBooking(modifiedBooking, availableSSK, sskSecondTrackBooking, _bookingID);
                        _roomManager.AddBooking(modifiedBooking, availableRoom, roomSecondTrackBooking, _bookingID);
                    }
                    else
                    {
                        _sskManager.AddBooking(modifiedBooking, availableSSK, sskSecondTrackBooking, booking.ID);
                        _roomManager.AddBooking(modifiedBooking, availableRoom, roomSecondTrackBooking, booking.ID);
                    }
                }
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
                    Room availableRoom = _roomManager.CheckBookingForRoom(booking, out bool roomOK, roomSecondTrackBooking);
                    if (!roomOK)
                    {
                        roomSecondTrackBooking = true;
                        availableRoom = _roomManager.CheckBookingForRoom(booking, out roomOK, roomSecondTrackBooking);//Check second track
                    }
                    if (roomOK)
                    {
                        //lägg till bekräftelse av användaren
                        ConfirmBooking confirmBooking = new ConfirmBooking(ssk.Name, availableRoom.RoomNumber, booking);
                        DialogResult result = confirmBooking.ShowDialog();
                        if (result == DialogResult.OK)
                        {
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
        private void FirstAvailableBooking(Booking booking, out Booking newBooking, out Room availableRoom, out SSK availableSSK, out bool secondTrackSSK, out bool secondTrackRoom)
        {
            bool bookingOK = false;
            secondTrackSSK = false;
            secondTrackRoom = false;
            bool sskOK = false;
            bool roomOK = false;
            newBooking = null;
            availableRoom = null;
            availableSSK = null;

            while (!bookingOK)
            {
                sskOK = _sskManager.CheckAvailabilityForBooking(booking, out booking, out availableSSK, secondTrackSSK);
                secondTrackRoom = false;
                Booking tempBooking = new Booking(booking);
                availableRoom = _roomManager.CheckBookingForRoom(tempBooking, out roomOK, secondTrackRoom);
                if (!roomOK)
                {
                    tempBooking = new Booking(booking);
                    secondTrackRoom = true;
                    availableRoom = _roomManager.CheckBookingForRoom(tempBooking, out roomOK, secondTrackRoom);
                }

                if (availableSSK == null)
                {
                    if (!secondTrackSSK)
                        secondTrackSSK = true;
                    else
                        break;
                }
                else if (sskOK && roomOK)
                {
                    bookingOK = true;
                    newBooking = booking;
                }
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
                                    ok = CheckRoomWithSelectedBooking(newBooking);
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

        private bool CheckRoomWithSelectedBooking(Booking booking)
        {
            bool secondTrack = false;
            Room availableRoom = _roomManager.CheckBookingForRoom(booking, out bool roomOK, secondTrack);
            if (!roomOK)
            {
                secondTrack = true;
                availableRoom = _roomManager.CheckBookingForRoom(booking, out roomOK, secondTrack);
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
