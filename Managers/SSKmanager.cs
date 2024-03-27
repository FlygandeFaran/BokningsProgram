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
    public class SSKmanager
    {
        private string filename;
        private List<SSK> _listOfSSK;
        private RoomManager _roomManager;

        public List<SSK> ListOfSSK
        {
            get { return _listOfSSK; }
        }
        public RoomManager RoomManager
        {
            get { return _roomManager; }
        }

        public SSKmanager()
        {
            _listOfSSK = new List<SSK>();
            _roomManager = new RoomManager();
            filename = "SSK.xml"; //Updatera efter dagvårdens IT-miljö
        }
        public void ImportFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SSK>));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                _listOfSSK = (List<SSK>)serializer.Deserialize(fileStream);
            }
        }
        public void ExportToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SSK>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, _listOfSSK);
            }
        }
        public void SuggestBooking(Booking booking)
        {
            bool ok = true;
            DateTime today = DateTime.Now;
            DateTime endOfDay = new DateTime(today.Year, today.Month, today.Day, 16, 0, 0);

            while (ok)
            {
                CheckBookingForSSK(booking, out bool sskOK);
                _roomManager.AddBooking(booking, out bool roomOK);

                if (sskOK && roomOK)
                    ok = false;
                else
                    booking = booking.GenerateBookingSuggestion(booking);

                if (booking.EndTime > endOfDay)
                {
                    MessageBox.Show("Hittade ingen ledig tid för bokningen");
                    break;
                }
            }
            if (!ok)
                AddBooking(booking);
        }
        public void AddBooking(Booking booking)
        {
            bool ok = false;
            SSK availableSSK = new SSK();
            Room availableRoom;

            availableSSK = CheckBookingForSSK(booking, out bool sskOK);
            availableRoom = _roomManager.AddBooking(booking, out bool roomOK);

            if (sskOK && roomOK)
                ok = true;

            if (ok)
            {
                _listOfSSK.FirstOrDefault(s => s.HSAID.Equals(availableSSK.HSAID)).AddBooking(booking);//bokar SSK
                _roomManager.ListOfRooms.FirstOrDefault(r => r.Equals(availableRoom)).AddBooking(booking);//bokar rummet
                //booking.bookingSSK = availableSSK;
                //booking.bookingRoom = availableRoom;
            }
        }
        private SSK CheckBookingForSSK(Booking booking, out bool sskOK)
        {
            sskOK = false;
            SSK availableSSK = new SSK();

            foreach (SSK ssk in _listOfSSK)
            {
                if (!ssk.IsTheyBooked(booking))
                {
                    if (booking.RoomRequired == RoomCategory.PicclineIn && ssk.Kompetens == KompetensLevel.Pickline)
                    {
                        availableSSK = ssk;
                        sskOK = true;
                        return availableSSK;
                    }
                    else if (booking.RoomRequired != RoomCategory.PicclineIn)
                    {
                        availableSSK = ssk;
                        sskOK = true;
                        return availableSSK;
                    }
                }
            }
            return availableSSK;
        }
        //public void RemoveSSK(string HSAid)
        //{
        //    // Find the person with the given name and remove them from the list
        //    SSK personToRemove = _listOfSSK.FirstOrDefault(s => s.HSAID == HSAid);
        //    if (personToRemove != null)
        //    {
        //        _listOfSSK.Remove(personToRemove);
        //        Console.WriteLine($"SSK '{HSAid}' borttagen.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"SSK '{HSAid}' not found.");
        //    }
        //}
        //public void AddSSK(SSK newSSK)
        //{
        //    _listOfSSK.Add(newSSK);
        //    ExportToXml();
        //}
    }
}
