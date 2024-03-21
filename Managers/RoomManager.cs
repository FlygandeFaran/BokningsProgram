using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class RoomManager
    {
        private List<Room> _listOfRooms;

        public List<Room> ListOfRooms
        {
            get { return _listOfRooms; }
            set { _listOfRooms = value; }
        }

        public RoomManager()
        {
            _listOfRooms = new List<Room>();
        }
    }
}
