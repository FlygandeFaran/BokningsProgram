using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private DateTime _endOfDay;
        private string filename;
        private List<SSK> _listOfSSK;

        public List<SSK> ListOfSSK
        {
            get { return _listOfSSK; }
        }

        public SSKmanager()
        {
            _listOfSSK = new List<SSK>();
            filename = @"\\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\xml\SSK.xml"; //Updatera efter dagvårdens IT-miljö
            //ImportSSKschedule();
            _endOfDay = new DateTime(1900, 1, 1, 16, 0, 0);
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
            newBooking = new Booking(booking);
            bool sskOK = false;
            availableSSK = new SSK();

            while (ok)
            {
                if (newBooking.EndTime.TimeOfDay > _endOfDay.TimeOfDay)
                {
                    {
                        newBooking = booking;
                        break;
                    }
                }
                availableSSK = CheckBookingForAnySSK(newBooking, out sskOK, secondTrack);
                if (availableSSK is SSK)
                {
                    if (sskOK)
                        ok = false;

                }
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);

            }
            return sskOK;
        }
        public void AddBooking(Booking booking, SSK newSSK, bool secondTrack, int bookingID)
        {
            newSSK.AddBooking(booking, secondTrack, bookingID);//bokar SSK
        }
        public SSK CheckBookingForSSK(Booking booking, SSK ssk, out bool secondTrack)
        {
            bool sskOK = false;
            secondTrack = false;
            if (ssk is SSK)
            {
                sskOK = CheckBookingForSelectedSSK(booking, ssk, secondTrack);
                if (!sskOK)
                {
                    secondTrack = true;
                    sskOK = CheckBookingForSelectedSSK(booking, ssk, secondTrack);
                    if (sskOK)
                        return ssk;
                }
                else
                    return ssk;
            }
            else
            {
                ssk = CheckBookingForAnySSK(booking, out sskOK, secondTrack);
                if (!sskOK)
                {
                    secondTrack = true;
                    ssk = CheckBookingForAnySSK(booking, out sskOK, secondTrack);
                    if (sskOK)
                        return ssk;
                }
                else
                    return ssk;
            }
            ssk = null; //Fanns ingen ledig ssk
            return ssk;
        }
        public SSK CheckBookingForAnySSK(Booking booking, out bool sskOK, bool secondTrack)
        {
            SSK availableSSK = null;
            sskOK = false;

            foreach (KompetensLevel kompetensLevel in Enum.GetValues(typeof(KompetensLevel)))//sorterar efter kompetenser
            {
                foreach (SSK ssk in _listOfSSK)
                {
                    if ((secondTrack && ssk.HasSecondSchedule) || !secondTrack)
                    {
                        if (ssk.Kompetenser.Contains(kompetensLevel))
                        {
                            if (!ssk.IsItBooked(booking, secondTrack))
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
                }
                if (sskOK)
                    break;
            }

            return availableSSK;
        }
        public bool CheckBookingForSelectedSSK(Booking booking, SSK ssk, bool secondTrack)
        {
            bool sskOK = false;

            if (!ssk.IsItBooked(booking, secondTrack))
            {
                sskOK = ssk.IsCompetentEnough(booking);
                if (sskOK)
                    return sskOK;
                else
                    MessageBox.Show("Sköterska kan inte lägga piccline");
            }
            return sskOK;
        }
        public bool CheckBookingForSelectedSSKWithVariableTime(Booking booking, out Booking newBooking, SSK ssk)
        {
            bool ok = true;
            newBooking = new Booking(booking);
            bool sskOK = false;

            while (ok)
            {
                if (newBooking.EndTime.TimeOfDay > _endOfDay.TimeOfDay)
                {
                    {
                        newBooking = booking;
                        break;
                    }
                }
                sskOK = !ssk.IsItBooked(newBooking, false);
                if (!sskOK)
                {
                    sskOK = !ssk.IsItBooked(newBooking, true);
                    if (sskOK)
                    {
                        ok = false;
                    }
                }
                if (sskOK)
                {
                    return sskOK;
                }
                else
                    newBooking = newBooking.GenerateNewBookingSuggestion(newBooking);
            }
            return sskOK;
        }
        public void GenerateSecondSchedule()
        {
            foreach (var ssk in ListOfSSK)
            {
                ssk.GenerateSecondBookings();
            }
        }
        public void ClearAllBookings()
        {
            foreach (SSK ssk in ListOfSSK)
            {
                ssk.ClearAllBookings();
            }
        }
        public SSK GetSSKfromName(string sskName)
        {
            SSK ssk = _listOfSSK.FirstOrDefault(s => s.Name.Equals(sskName));
            return ssk;
        }
        public SSK GetSSKFromBooking(Booking booking)
        {
            SSK bookedSSK = null;
            if (booking.Description != "Lunch")
            {
                bookedSSK = _listOfSSK.FirstOrDefault(ssk =>
                                                            ssk.ScheduledDays.Days.Any(ds => 
                                                            ds.FirstlistOfBookings.Any(booked => booked.ID == booking.ID) ||
                                                            ds.SecondlistOfBookings.Any(booked => booked.ID == booking.ID)));
            }
            else
            {
                bookedSSK = _listOfSSK.FirstOrDefault(ssk =>
                                                            ssk.ScheduledDays.Days.Any(ds => 
                                                            ds.FirstlistOfBookings.Any(booked => booked == booking) ||
                                                            ds.FirstlistOfBookings.Any(booked => booked == booking)));
            }
            return bookedSSK;
        }
    }
}
