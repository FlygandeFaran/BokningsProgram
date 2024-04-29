using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BokningsProgram.Managers
{
    public class ExcelImport
    {
        private string filename;
        private List<string> _sskNames;
        //private List<DateTime> _dates;
        private List<DateTime> _startTimes;
        private List<DateTime> _endTimes;
        public ExcelImport()
        {
            _sskNames = new List<string>();
            _startTimes = new List<DateTime>();
            _endTimes = new List<DateTime>();
        }

        public void ImportSSKschedule()
        {
            filename = @"S:\RADIOFYSIK NYSTART\Ö_Erik\02 Programmering\C# scripting\03 Github\BokningsProgram\BokningsProgram\bin\Debug\Pilot_schema.xlsx";
            // Create an instance of Excel Application
            Application excelApp = new Application();

            // Open the Excel workbook
            Workbook workbook = excelApp.Workbooks.Open(filename);

            // Get the first worksheet
            Worksheet worksheet = workbook.Sheets[1];

            // Get cell values
            Range range = worksheet.UsedRange;
            object[,] values = range.Value;

            string cellString = "";
            string startTid = "";
            DateTime date = DateTime.Today;

            // Loop through the cells and print their values
            try
            {
                for (int i = 1; i <= range.Rows.Count; i++)
                {
                    if (i > 1)
                    {
                        _sskNames.Add(values[i, 1].ToString());
                    }
                    for (int j = 1; j < range.Columns.Count; j++)
                    {
                        cellString = values[i, j].ToString();
                        if (i == 1)
                        {
                            date = DateTime.ParseExact(cellString, "ddd  dd  MMM", CultureInfo.GetCultureInfo("sv-SE"));
                        }
                        else
                        {
                            ExtractDates(cellString, date);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                workbook.Close();
                excelApp.Quit();
            }

            // Close Excel
            workbook.Close();
            excelApp.Quit();
        }
        private void ExtractDates(string cellValue, DateTime date)
        {
            // Define the regular expression pattern to match times in HH:mm format
            string pattern = @"\b\d{2}:\d{2}\b";

            // Match the times in the input string using Regex
            MatchCollection matches = Regex.Matches(cellValue, pattern);

            // Extract the times from the matches
            string startTimeStr = matches[0].Value;
            double startTimeHour = double.Parse(startTimeStr.Substring(0, 2));
            double startTimeMinute = double.Parse(startTimeStr.Substring(3, 2));

            string endTimeStr = matches[1].Value;
            double endTimeHour = double.Parse(endTimeStr.Substring(0, 2));
            double endTimeMinute = double.Parse(endTimeStr.Substring(3, 2));

        }
        private void GetSSKnames()
        {

        }
        private void GetDates()
        {

        }
        private void GetStartAndEndTimes()
        {

        }
    }
}
