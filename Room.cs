using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Room
    {
        private RoomCategory _roomType;
        private int _roomNumber;

        public RoomCategory RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        public int RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        public Room(RoomCategory roomType, int roomNumber)
        {
            _roomType = roomType;
            _roomNumber = roomNumber;
        }
    }
}
