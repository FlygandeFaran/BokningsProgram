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
        public bool CheckAvailabilityForBooking(Booking booking, out Booking newBooking, out SSK availableSSK, bool secondTrack)
        {
            bool ok = true;
            newBooking = new Booking();
            newBooking.CopyBooking(booking);
            bool sskOK = false;
            availableSSK = new SSK();

            while (ok)
            {
                if (newBooking.EndTime.Hour > _endOfDay)
                {
                    //bool secondTrackAvailable = SetFirstTrackToFull();
                    //if (!secondTrackAvailable)
                    {
                        newBooking = booking;
                        break;
                    }
                    //newBooking = booking; // börjar om igen med ursprungliga bokningen
                }
                availableSSK = CheckBookingForSSK(newBooking, out sskOK, secondTrack);
                if (availableSSK is SSK)
                {
                    if (sskOK)
                        ok = false;

                }
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);
                //else { MessageBox.Show("Hittade ingen ssk"); }

            }
            return sskOK;
        }
        public void AddBooking(Booking booking, SSK newSSK)
        {
            _listOfSSK.FirstOrDefault(s => s.HSAID.Equals(newSSK.HSAID)).AddBooking(booking);//bokar SSK
        }
        private SSK CheckBookingForSSK(Booking booking, out bool sskOK, bool secondTrack)
        {
            SSK availableSSK = null;
            sskOK = false;
            ScheduledDays scheduledDays = null;

            foreach (KompetensLevel kompetensLevel in Enum.GetValues(typeof(KompetensLevel)))//sorterar efter kompetenser
            {
                foreach (SSK ssk in _listOfSSK)
                {
                    if (ssk.Kompetenser.Contains(kompetensLevel))
                    {
                        if (secondTrack && ssk.Kompetenser.Contains(KompetensLevel.Piccline))//om ssk har kompetens piccline kan de även ha 2 spår
                            scheduledDays = ssk.ScheduledDaysSecondTrack;
                        else
                            scheduledDays = ssk.ScheduledDays;
                        if (!ssk.IsItBooked(booking, scheduledDays))
                        {
                            sskOK = ssk.IsCompetentEnough(booking);
                            if (sskOK)
                            {
                                availableSSK = ssk;
                                break;
                            }
                        }
                    }
                }
                if (sskOK)
                    break;
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
    }
}
