using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace BokningsProgram
{
    public class RoomManager
    {
        private string filename;
        private double _endOfDay;
        private List<Room> _listOfRooms;
        //private List<Room> _singleRoomList;
        //private List<Room> _doubleRoomList;
        //private List<Room> _quadRoomList;
        //private List<Room> _piccRoomList;

        public List<Room> ListOfRooms
        {
            get { return _listOfRooms; }
        }

        public RoomManager()
        {
            _endOfDay = 16; //Dagen slutar kl 16 för rummen
            _listOfRooms = new List<Room>();
            filename = "Rooms.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public Room GetRoomFromBooking(Booking booking)
        {
            Room bookedRoom = _listOfRooms.FirstOrDefault(room =>
                                                            room.RoomType == booking.RoomRequired &&
                                                            room.ScheduledDays.Days.Any(s => s.FirstlistOfBookings.Any(booked =>
                                                            booked.StartTime == booking.StartTime &&
                                                            booked.EndTime == booking.EndTime &&
                                                            booked.Description == booking.Description)));
            if (bookedRoom is Room)
                return bookedRoom;
            else
            {
                bookedRoom = _listOfRooms.FirstOrDefault(room =>
                                                            room.RoomType == booking.RoomRequired &&
                                                            room.ScheduledDays.Days.Any(s => s.SecondlistOfBookings.Any(booked =>
                                                            booked.StartTime == booking.StartTime &&
                                                            booked.EndTime == booking.EndTime &&
                                                            booked.Description == booking.Description)));
            }
            return bookedRoom;
        }
        public bool CheckAvailabilityForBooking(Booking booking, out Booking newBooking, out Room availableRoom, bool secondTrack)
        {
            bool ok = true;
            newBooking = booking;
            bool roomOK = false;
            availableRoom = new Room();

            while (ok)
            {
                availableRoom = CheckBookingForRoom(newBooking, out roomOK, secondTrack);
                if (availableRoom is Room)
                {
                    if (roomOK)
                        ok = false;
                    else
                        newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);

                    if (booking.EndTime.Hour > _endOfDay)
                    {
                        //if (!secondTrack)
                        //{
                        //MessageBox.Show("Hittade ingen ledig tid för bokningen");
                        break;
                        //}
                        //newBooking = booking; // börjar om igen med ursprungliga bokningen
                    }
                }
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);
            }

            return roomOK;
        }
        public Room CheckBookingForRoom(Booking booking, out bool roomOK, bool secondTrack)
        {
            roomOK = false;
            int j = 0;
            RoomCategory originalRoomCategory = booking.RoomRequired;
            Room tempRoom = _listOfRooms[j];
            while (!roomOK)
            {
                tempRoom = _listOfRooms[j];
                if ((secondTrack && tempRoom.HasSecondSchedule) || !secondTrack)
                {
                    if (booking.RoomRequired.Equals(tempRoom.RoomType))
                    {
                        if (!tempRoom.IsItBooked(booking, secondTrack))
                        {
                            roomOK = true;
                            return tempRoom;
                        }
                    }
                }
                j++;

                if (j == _listOfRooms.Count && booking.RoomRequired == RoomCategory.PicclineOm)
                {
                    roomOK = true;
                    MessageBox.Show("Hittade inget ledigt rum vid den här tiden. Vänligen välj ny tid");
                }
                else if (j == _listOfRooms.Count && !roomOK)
                {
                    if (originalRoomCategory == RoomCategory.Enkel || originalRoomCategory == RoomCategory.PicclineIn)
                    {
                        booking = SingleRoomQueue(booking);
                    }
                    else if (originalRoomCategory == RoomCategory.Dubbel || originalRoomCategory == RoomCategory.Quad)
                    {
                        booking = DoubleRoomQueue(booking);
                    }
                    j = 0;
                }
            }
            
            return tempRoom;
        }
        public void AddBooking(Booking booking, Room newRoom, bool secondRoomTrack)
        {
            _listOfRooms.FirstOrDefault(r => r.RoomNumber.Equals(newRoom.RoomNumber)).AddBooking(booking, secondRoomTrack);//bokar SSK
        }

        private Booking SingleRoomQueue(Booking booking)
        {
            switch (booking.RoomRequired)
            {
                case RoomCategory.Enkel:
                    booking.RoomRequired = RoomCategory.Dubbel;
                    break;
                case RoomCategory.Dubbel:
                    booking.RoomRequired = RoomCategory.Quad;
                    break;
                case RoomCategory.Quad:
                    booking.RoomRequired = RoomCategory.PicclineIn;
                    break;
                case RoomCategory.PicclineIn:
                    booking.RoomRequired = RoomCategory.PicclineOm;
                    break;
            }
            return booking;
        }
        private Booking DoubleRoomQueue(Booking booking)
        {
            switch (booking.RoomRequired)
            {
                case RoomCategory.Dubbel:
                    booking.RoomRequired = RoomCategory.Quad;
                    break;
                case RoomCategory.Quad:
                    booking.RoomRequired = RoomCategory.Enkel;
                    break;
                case RoomCategory.Enkel:
                    booking.RoomRequired = RoomCategory.Dubbel;
                    break;
                case RoomCategory.PicclineIn:
                    booking.RoomRequired = RoomCategory.PicclineOm;
                    break;
            }
            return booking;
        }
        public void ImportFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                _listOfRooms = (List<Room>)serializer.Deserialize(fileStream);
            }
        }
        public void ExportToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, _listOfRooms);
            }
        }
    }
}
