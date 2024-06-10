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
            filename = @"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\Rooms.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public Room GetRoomFromBooking(Booking booking)
        {
            Room bookedRoom = _listOfRooms.FirstOrDefault(room =>
                                                            room.ScheduledDays.Days.Any(s => s.FirstlistOfBookings.Any(booked =>
                                                            booked.ID == booking.ID)));
            if (bookedRoom is Room)
                return bookedRoom;
            else
            {
                bookedRoom = _listOfRooms.FirstOrDefault(room =>
                                                            room.ScheduledDays.Days.Any(s => s.SecondlistOfBookings.Any(booked =>
                                                            booked.ID == booking.ID)));
            }
            return bookedRoom;
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

                if (j == _listOfRooms.Count && !roomOK)
                {
                    if (originalRoomCategory == RoomCategory.Enkel)
                    {
                        booking = SingleRoomQueue(booking);
                    }
                    else if (originalRoomCategory == RoomCategory.Dubbel || originalRoomCategory == RoomCategory.Quad)
                    {
                        booking = DoubleRoomQueue(booking);
                    }
                    else if (originalRoomCategory == RoomCategory.PicclineOm)
                    {
                        booking = PiccOmQueue(booking);
                    }
                    else if (booking.RoomRequired == RoomCategory.Quad)
                    {
                        roomOK = false;
                        break;
                    }
                    else
                    {
                        roomOK = false;
                        break;
                    }
                    j = 0;
                }
            }
            
            return tempRoom;
        }
        public void AddBooking(Booking booking, Room newRoom, bool secondRoomTrack, int bookingID)
        {
            _listOfRooms.FirstOrDefault(r => r.RoomNumber.Equals(newRoom.RoomNumber)).AddBooking(booking, secondRoomTrack, bookingID);//bokar SSK
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
            }
            return booking;
        }
        private Booking DoubleRoomQueue(Booking booking)
        {
            switch (booking.RoomRequired)
            {
                case RoomCategory.Dubbel:
                    booking.RoomRequired = RoomCategory.Enkel;
                    break;
                case RoomCategory.Enkel:
                    booking.RoomRequired = RoomCategory.Quad;
                    break;
            }
            return booking;
        }
        private Booking PiccOmQueue(Booking booking)
        {
            switch (booking.RoomRequired)
            {
                case RoomCategory.PicclineOm:
                    booking.RoomRequired = RoomCategory.Dubbel;
                    break;
                case RoomCategory.Dubbel:
                    booking.RoomRequired = RoomCategory.Enkel;
                    break;
                case RoomCategory.Enkel:
                    booking.RoomRequired = RoomCategory.Quad;
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
        public void CreateAllBeds()
        {
            foreach (var room in ListOfRooms)
            {
                room.CreateAllBeds();
            }
        }
        public void ClearAllBookings()
        {
            foreach (Room room in ListOfRooms)
            {
                room.ClearAllBookings();
            }
        }
    }
}
