using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BokningsProgram
{
    public class RoomManager
    {
        private List<Room> _listOfRooms;
        private List<Room> _singleRoomList;
        private List<Room> _doubleRoomList;
        private List<Room> _quadRoomList;
        private List<Room> _piccRoomList;

        public List<Room> ListOfRooms
        {
            get { return _listOfRooms; }
            set { _listOfRooms = value; }
        }
        public List<Room> SingleRoomList
        {
            get { return _singleRoomList; }
            set { _singleRoomList = value; }
        }
        public List<Room> DoubleRoomList
        {
            get { return _doubleRoomList; }
            set { _doubleRoomList = value; }
        }
        public List<Room> QuadRoomList
        {
            get { return _quadRoomList; }
            set { _quadRoomList = value; }
        }
        public List<Room> PiccRoomList
        {
            get { return _piccRoomList; }
            set { _piccRoomList = value; }
        }

        public RoomManager()
        {
            _listOfRooms = new List<Room>();

            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 3));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 4));
            ListOfRooms.Add(new Room(RoomCategory.Quad, 7));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 8));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 9));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 12));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 13));
            ListOfRooms.Add(new Room(RoomCategory.Dubbel, 14));

            ListOfRooms.Add(new Room(RoomCategory.Enkel, 16));
            ListOfRooms.Add(new Room(RoomCategory.Enkel, 17));
            ListOfRooms.Add(new Room(RoomCategory.Enkel, 23));

            ListOfRooms.Add(new Room(RoomCategory.PicclineIn, 1));
            ListOfRooms.Add(new Room(RoomCategory.PicclineOm, 2));

            CreateListsOfRoomTypes();
        }

        private void CreateListsOfRoomTypes()
        {
            _singleRoomList = new List<Room>();
            _doubleRoomList = new List<Room>();
            _quadRoomList = new List<Room>();
            _piccRoomList = new List<Room>();

            // Populate the lists
            foreach (Room room in ListOfRooms)
            {
                switch (room.RoomType)
                {
                    case RoomCategory.Enkel:
                        _singleRoomList.Add(room);
                        break;
                    case RoomCategory.Dubbel:
                        _doubleRoomList.Add(room);
                        break;
                    case RoomCategory.PicclineIn:
                        _piccRoomList.Add(room);
                        break;
                    case RoomCategory.Quad:
                        _quadRoomList.Add(room);
                        break;
                }
            }
        }
        public Room AddBooking(Booking booking, out bool roomOK)
        {
            roomOK = false;
            int j = 0;
            RoomCategory originalRoomCategory = booking.RoomRequired;
            Room tempRoom = _listOfRooms[j];
            while (!roomOK)
            {
                tempRoom = _listOfRooms[j];
                if (booking.RoomRequired == tempRoom.RoomType && !tempRoom.IsItBooked(booking)) //fortsätt här
                {
                    //tempRoom.AddBooking(booking); //bokas redan i SSKmanager
                    roomOK = true;
                    return tempRoom;
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
    }
}
