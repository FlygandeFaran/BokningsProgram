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
                    //else
                    //    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);

                    if (booking.EndTime.Hour > _endOfDay)
                    {
                        bool secondTrackAvailable = SetFirstTrackToFull();
                        if (!secondTrackAvailable)
                        {
                            MessageBox.Show("Hittade ingen ledig tid för bokningen");
                            break;
                        }
                        newBooking = booking; // börjar om igen med ursprungliga bokningen
                    }
                }
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);
                //else { MessageBox.Show("Hittade ingen ssk"); }

            }
            return sskOK;
        }

        private bool SetFirstTrackToFull()
        {
            bool ok = false;
            foreach (SSK ssk in _listOfSSK)
            {
                if (ssk.Kompetens == KompetensLevel.Piccline && !ssk.IsFirstTrackFull)
                {
                    ssk.IsFirstTrackFull = true;
                    ok = true;
                }
            }
            return ok;
        }

        public void AddBooking(Booking booking, SSK newSSK)
        {
            _listOfSSK.FirstOrDefault(s => s.HSAID.Equals(newSSK.HSAID)).AddBooking(booking);//bokar SSK
        }
        private SSK CheckBookingForSSK(Booking booking, out bool sskOK)
        {
            sskOK = CheckCompetensAndAvailabilityOfTrack(booking, out SSK availableSSK);
            return availableSSK;
        }

        private bool CheckCompetensAndAvailabilityOfTrack(Booking booking, out SSK availableSSK)
        {
            bool sskOK = false;
            ScheduledDays scheduledDays = null;
            foreach (SSK ssk in _listOfSSK)
            {
                if (ssk.IsFirstTrackFull)
                    scheduledDays = ssk.ScheduledDaysSecondTrack;
                else
                    scheduledDays = ssk.ScheduledDays;
                if (!ssk.IsItBooked(booking, scheduledDays))
                {
                    sskOK = ssk.IsCompetentEnough(booking);
                    availableSSK = ssk;
                    return sskOK;
                }
            }
            availableSSK = null;
            return sskOK;
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
