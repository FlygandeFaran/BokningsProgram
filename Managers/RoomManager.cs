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
            _listOfRooms = new List<Room>();
            filename = @"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\Rooms.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public Room GetRoomFromBooking(Booking booking)
        {
            Room bookedRoom = _listOfRooms.FirstOrDefault(room =>
                                                            room.ScheduledDays.Days.Any(ds =>
                                                            ds.FirstlistOfBookings.Any(booked => booked.ID == booking.ID) ||
                                                            ds.SecondlistOfBookings.Any(booked => booked.ID == booking.ID)));
            return bookedRoom;
        }
        public Room CheckBookingForRoom(Booking booking, Room room, out bool secondTrack)
        {
            secondTrack = false;
            bool roomOK = false;
            if (room is Room)
            {
                roomOK = CheckBookingForSelectedRoom(booking, room, secondTrack);
                if (!roomOK)
                {
                    secondTrack = true;
                    roomOK = CheckBookingForSelectedRoom(booking, room, secondTrack);
                    if (roomOK)
                        return room;
                    else
                        MessageBox.Show("Finns inget tillgängligt rum med rätt utrsutning");
                }
                else
                    return room;
            }
            else
            {
                room = CheckBookingForAnyRoom(booking, out roomOK, secondTrack);
                if (!roomOK)
                {
                    secondTrack = true;
                    room = CheckBookingForAnyRoom(booking, out roomOK, secondTrack);
                    if (roomOK)
                        return room;
                }
                else
                    return room;
            }
            room = null; //Fanns inget ledigt rum
            return room;
        }
        public Room CheckBookingForAnyRoom(Booking booking, out bool roomOK, bool secondTrack)
        {
            Booking tempBooking = new Booking(booking);
            roomOK = false;
            int j = 0;
            RoomCategory originalRoomCategory = tempBooking.RoomRequired;
            Room tempRoom = _listOfRooms[j];
            while (!roomOK)
            {
                tempRoom = _listOfRooms[j];
                if ((secondTrack && tempRoom.HasSecondSchedule) || !secondTrack)
                {
                    if (tempBooking.RoomRequired.Equals(tempRoom.RoomType))
                    {
                        if (!tempRoom.IsItBooked(tempBooking, secondTrack))
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
                        tempBooking = SingleRoomQueue(tempBooking);
                    }
                    else if (tempBooking.RoomRequired == RoomCategory.Quad)
                    {
                        roomOK = false;
                        break;
                    }
                    else if (originalRoomCategory == RoomCategory.Dubbel || originalRoomCategory == RoomCategory.Quad)
                    {
                        tempBooking = DoubleRoomQueue(tempBooking);
                    }
                    else if (originalRoomCategory == RoomCategory.PicclineOm)
                    {
                        tempBooking = PiccOmQueue(tempBooking);
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
        public bool CheckBookingForSelectedRoom(Booking booking, Room room, bool secondTrack)
        {
            bool roomOK = false;

            if (!room.IsItBooked(booking, secondTrack))
            {
                if (booking.RoomRequired.Equals(RoomCategory.PicclineIn) && room.RoomType.Equals(RoomCategory.PicclineIn))
                    return true;
                else if (booking.RoomRequired != RoomCategory.PicclineIn)
                    return true;
                else
                    return false;
            }
            return roomOK;
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
