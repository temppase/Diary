using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiaryApp.Controlers
{
    public class YearClock
    {
        Paths P = new Paths();

        public int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        }
        public void CreateYear(string year)
        {
            P.CreateFile(P.YearClock + $"year-{year}.csv");
            List<YearModel> Weeks = new List<YearModel>();
            int i = 1;
            int y = int.Parse(year);
            
            for (int Y = GetWeeksInYear(y); Y > 0; Y--)
            {
                Weeks.Add(new YearModel(i, "Empty week"));
                i++;
            }

            using (StreamWriter sw = new StreamWriter(P.YearClock + $"year-{year}.csv", true))
            {
                foreach (var w in Weeks)
                {
                    string data = $"{w.Week};{w.Note};";
                    sw.WriteLine(data);
                }
            }
            //if (File.Exists(P.YearClock + $"year-{year}.csv"))
            //{
            //    foreach (var w in Weeks)
            //    {
            //        string data = $"{w.Week};{w.Note};\n";
            //        File.AppendAllText(P.YearClock + $"year-{year}.csv", data);
            //    }
            //}
        }
        public static YearModel FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            YearModel M = new YearModel(
                Convert.ToInt16(values[0]),
                values[1]
                );
            return M;
        }
        public List<YearModel> ReadYear(string year)
        {
            if (File.Exists(P.YearClock + $"year-{year}.csv"))
            {
                List<YearModel> values = File.
                ReadAllLines(P.YearClock + $"year-{year}.csv")
                    .Select(v => FromCsv(v))
                    .ToList();
                return values;
            }
            else
            {
                List<YearModel> values = new List<YearModel>();
                values.Add(new YearModel(0,"Select year!"));
                return values;
            }
        }
        public void EditWeek(string year, YearModel week)
        {
            Debug.WriteLine($"\nY: {year}\nW: {week.Week}\nN:{week.Note}\n");
            string[] lines = File.ReadAllLines(P.YearClock + $"year-{year}.csv");
            using (StreamWriter sw = new StreamWriter(P.YearClock + $"year-{year}.csv", false))
            {
                foreach (var l in lines)
                {
                    string[] p = l.Split(';');
                    if (p[0] != week.Week.ToString())
                    {
                        string d = $"{p[0]};{p[1]};";
                        sw.WriteLine(d);
                        Debug.WriteLine($"Old values:\n {d}");
                    }
                    else
                    {
                        string d = $"{p[0]};{week.Note};";
                        sw.WriteLine(d);
                        Debug.WriteLine($"New values:\n {d}");
                    }
                }

            }
        }
    }
}
