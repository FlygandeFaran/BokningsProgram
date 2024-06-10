using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BokningsProgram.Forms
{
    public class MeetingManager
    {
		private List<Meeting> _listOfMeetings;
        private string filename;

		public List<Meeting> ListOfMeetings
        {
			get { return _listOfMeetings; }
			set { _listOfMeetings = value; }
		}

		public MeetingManager()
		{
			_listOfMeetings = new List<Meeting>();
            filename = @"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\Meetings.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public void AddMeeting(Meeting meeting)
        {
            _listOfMeetings.Add(meeting);
        }
        public void RemoveMeeting(Meeting meeting)
        {
            _listOfMeetings.Remove(meeting);
        }
        public void EditMeeting(Meeting newMeeting, Meeting oldMeeting)
        {
            oldMeeting.NameOfMeeting = newMeeting.NameOfMeeting;
            oldMeeting.Intervall = newMeeting.Intervall;
            oldMeeting.DayOfWeek = newMeeting.DayOfWeek;
            oldMeeting.Time = newMeeting.Time;
        }
        public void ExportToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Meeting>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, _listOfMeetings);
            }
        }
        public void ImportFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Meeting>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                _listOfMeetings = (List<Meeting>)serializer.Deserialize(fileStream);
            }
        }
        public void RemoveSSKfromMeeting(Meeting meeting, SSKmanager sm)
        {
            foreach (var sskName in meeting.NamesOfSSK)
            {
                var ssk = sm.GetSSKfromName(sskName);
                ssk.RemoveMeetingBooking(meeting.NameOfMeeting);
            }
            RemoveMeeting(meeting);
        }
    }
}
