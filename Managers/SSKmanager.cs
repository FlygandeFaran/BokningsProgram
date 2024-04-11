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

        public List<SSK> ListOfSSK
        {
            get { return _listOfSSK; }
        }

        public SSKmanager()
        {
            _listOfSSK = new List<SSK>();
            filename = "SSK.xml"; //Updatera efter dagvårdens IT-miljö

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
                if (availableSSK is SSK)
                {
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
                else { MessageBox.Show("Hittade ingen ssk"); }

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
                if (!ssk.IsItBooked(booking, ssk.ScheduledDays))
                {
                    sskOK = ssk.IsCompetentEnough(booking);
                    if (sskOK)
                        return ssk;
                }
            }
            return availableSSK;
        }
        public bool CheckBookingForSelectedSSK(Booking booking, SSK ssk)
        {
            bool sskOK = false;

            if (!ssk.IsItBooked(booking, ssk.ScheduledDays))
            {
                sskOK = ssk.IsCompetentEnough(booking);
                if (sskOK)
                    return sskOK;
                else
                    MessageBox.Show("Sköterska kan inte lägga piccline");
            }
            return sskOK;
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
