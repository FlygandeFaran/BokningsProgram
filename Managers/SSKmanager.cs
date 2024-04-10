using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BokningsProgram
{
    public class SSKmanager
    {
        private double _endOfDay;
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

            DateTime today = DateTime.Now;
            _endOfDay = 16;
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
        public bool CheckAvailabilityForBooking(Booking booking, out Booking newBooking, out SSK availableSSK)
        {
            bool ok = true;
            newBooking = booking;
            bool sskOK = false;
            availableSSK = new SSK();

            while (ok)
            {
                availableSSK = CheckBookingForSSK(newBooking, out sskOK);

                if (sskOK)
                    ok = false;
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);

                if (booking.EndTime.Hour > _endOfDay)
                {
                    MessageBox.Show("Hittade ingen ledig tid för bokningen");
                    break;
                }
            }
            return sskOK;
        }
        public void AddBooking(Booking booking, SSK newSSK)
        {
            _listOfSSK.FirstOrDefault(s => s.HSAID.Equals(newSSK.HSAID)).AddBooking(booking);//bokar SSK
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
