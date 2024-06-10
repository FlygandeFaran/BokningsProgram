using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokningsProgram
{
    public class Room : BookableItem
    {
        private RoomCategory _roomType;
        private string _roomNumber;

        public RoomCategory RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        public string RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        public Room(RoomCategory roomType, string roomNumber)
        {
            _roomType = roomType;
            _roomNumber = roomNumber;
        }
        public Room() { }
        public void CreateAllBeds()
        {
            switch (_roomType)
            {
                case RoomCategory.Enkel:
                    break;
                case RoomCategory.Dubbel:
                    this.HasSecondSchedule = true;
                    foreach (var day in ScheduledDays.Days)
                    {
                        day.AddSecondListOfBookings(day.StartOfDay);
                    }
                    break;
                case RoomCategory.Quad:
                    this.HasSecondSchedule = true;
                    foreach (var day in ScheduledDays.Days)
                    {
                        day.AddSecondListOfBookings(day.StartOfDay);
                        day.AddSecondListOfBookings(day.StartOfDay);
                        day.AddSecondListOfBookings(day.StartOfDay);
                    }
                    break;
                case RoomCategory.PicclineIn:
                    break;
                case RoomCategory.PicclineOm:
                    break;
                default:
                    break;
            }
        }
    }
}
