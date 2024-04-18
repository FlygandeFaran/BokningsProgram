using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsProgram
{
    public class Room : BookableItem
    {
        private List<ScheduledDays> _scheduleForBeds;
        //private ScheduledDays _scheduledDays;
        private RoomCategory _roomType;
        private string _roomNumber;

        public List<ScheduledDays> ScheduleForBeds
        {
            get { return _scheduleForBeds; }
            set { _scheduleForBeds = value; }
        }
        //public ScheduledDays ScheduledDays
        //{
        //    get { return _scheduledDays; }
        //    set { _scheduledDays = value; }
        //}
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
            CreateAllBeds();
            //_scheduledDays = new ScheduledDays(_roomNumber);
        }
        public Room() { }
        public DailySchedule GetDailyScheduleOfBookingFromRoom(Booking booking)
        {
            DailySchedule ds = null;
            foreach (var bed in _scheduleForBeds)
            {
                ds = bed.GetDailyScheduleOfBooking(booking);
                if (ds is DailySchedule)
                    return ds;
            }
            return ds;
        }
        private void CreateAllBeds()
        {
            _scheduleForBeds = new List<ScheduledDays>();
            switch (_roomType)
            {
                case RoomCategory.Enkel:
                    _scheduleForBeds.Add(new ScheduledDays());
                    break;
                case RoomCategory.Dubbel:
                    _scheduleForBeds.Add(new ScheduledDays());
                    _scheduleForBeds.Add(new ScheduledDays());
                    break;
                case RoomCategory.Quad:
                    _scheduleForBeds.Add(new ScheduledDays());
                    _scheduleForBeds.Add(new ScheduledDays());
                    _scheduleForBeds.Add(new ScheduledDays());
                    _scheduleForBeds.Add(new ScheduledDays());
                    break;
                case RoomCategory.PicclineIn:
                    _scheduleForBeds.Add(new ScheduledDays());
                    break;
                case RoomCategory.PicclineOm:
                    _scheduleForBeds.Add(new ScheduledDays());
                    break;
                default:
                    break;
            }
        }
    }
}
