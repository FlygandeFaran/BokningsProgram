using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokningsProgram.Managers
{
    public class ExcelImport
    {
        private string filename;
        //private List<DateTime> _dates;
        //private List<DateTime> _startTimes;
        //private List<DateTime> _endTimes;
        private List<DateTime> _startTimes;
        private List<DateTime> _endTimes;
        private List<DateTime> _dates;
        public ExcelImport()
        {
            _dates = new List<DateTime>();
        }

        public void ImportSchedules(SSKmanager sm, RoomManager rm)
        {
            filename = @"S:\RADIOFYSIK NYSTART\Ö_Erik\02 Programmering\C# scripting\03 Github\BokningsProgram\BokningsProgram\bin\Debug\Kopia av Pilot schema.xlsx";
            // Create an instance of Excel Application
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Open the Excel workbook
            Workbook workbook = excelApp.Workbooks.Open(filename);

            // Get the first worksheet
            Worksheet worksheet = workbook.Sheets[1];

            // Get cell values
            Range range = worksheet.UsedRange;
            object[,] values = range.Value;
            var len = values.Length;
            string cellString = "";
            DateTime date = DateTime.Today;

            // Loop through the cells and print their values
            string msg = "";
            try
            {
                for (int i = 1; i <= range.Rows.Count; i++)
                {
                    _startTimes = new List<DateTime>();
                    _endTimes = new List<DateTime>();
                    for (int j = 2; j < range.Columns.Count; j++)
                    {
                        cellString = values[i, j].ToString();
                        if (i == 1)//rubrik i excelbladet
                        {
                            date = DateTime.ParseExact(cellString.Substring(0, 12), "ddd  dd  MMM", CultureInfo.GetCultureInfo("sv-SE"));
                            _dates.Add(date);
                        }
                        else if (cellString.ToLower().Contains("semester") || string.IsNullOrEmpty(cellString))
                        {
                            date = _dates.ElementAt(j - 2);
                            date = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
                            _startTimes.Add(date);
                            date = new DateTime(date.Year, date.Month, date.Day, 16, 0, 0);
                            _endTimes.Add(date);
                        }
                        else
                        {
                            date = _dates.ElementAt(j - 2);
                            ExtractDates(cellString, date);
                        }
                    }
                    if (i > 1)
                    {
                        if (!sm.ListOfSSK.Any(s => s.Name.Equals(values[i, 1].ToString())))
                        {
                            //i++;
                            msg += "\n" + values[i, 1].ToString();
                        }
                        else
                        {
                            SSK ssk = sm.ListOfSSK.FirstOrDefault(s => s.Name.Equals(values[i, 1].ToString()));
                            GenerateScheduleForSSK(ssk);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                workbook.Close();
                excelApp.Quit();
                MessageBox.Show(error);
            }
            if (!msg.Equals(""))
            {
                MessageBox.Show("Kunde inte hitta följande ssk i systemet:\n" + msg + "\n\nKontrollera att de heter samma i systemet som i Heroma");
            }

            // Close Excel
            workbook.Close();
            excelApp.Quit();

            GenerateScheduleForRooms(rm);
        }
        private void ExtractDates(string cellValue, DateTime date)
        {
            // Define the regular expression pattern to match times in HH:mm format
            string pattern = @"\b\d{2}:\d{2}\b";

            // Match the times in the input string using Regex
            MatchCollection matches = Regex.Matches(cellValue, pattern);

            // Extract the times from the matches
            string startTimeStr = matches[0].Value;
            int startTimeHour = int.Parse(startTimeStr.Substring(0, 2));
            int startTimeMinute = int.Parse(startTimeStr.Substring(3, 2));

            date = new DateTime(date.Year, date.Month, date.Day, startTimeHour, startTimeMinute, 0);
            _startTimes.Add(date);

            string endTimeStr = matches[1].Value;
            int endTimeHour = int.Parse(endTimeStr.Substring(0, 2));
            int endTimeMinute = int.Parse(endTimeStr.Substring(3, 2));

            if (endTimeHour > 16)
                endTimeHour = 16;
            date = new DateTime(date.Year, date.Month, date.Day, endTimeHour, endTimeMinute, 0);
            _endTimes.Add(date);
        }
        private void GenerateScheduleForSSK(SSK ssk)
        {
            ssk.ScheduledDays.GenerateSCheduleDaysForSSK(_startTimes, _endTimes);
        }
        private void GenerateScheduleForRooms(RoomManager rm)
        {
            foreach (Room room in rm.ListOfRooms)
            {
                room.ScheduledDays.GenerateSCheduleDaysForRooms(_startTimes);
            }
        }
    }
}
