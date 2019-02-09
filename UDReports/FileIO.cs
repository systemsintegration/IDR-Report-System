using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UDReports
{
    public class FileIO
    {
        string DesktopLocation = $@"C:\Users\{Environment.UserName}\{Environment.SpecialFolder.Desktop.ToString()}//Reports/";

        public void WriteToDesktop(List<UnitDiary> list)
        {
            int dateMonth = DateTime.Now.Month;
            int dateDay = DateTime.Now.Day;
            string dayValue = dateDay.ToString();
            if(dateDay < 10)
            {
                dayValue = "0" + dateDay.ToString();
            }
            string dateValue = dateMonth.ToString();
            if(dateMonth < 10)
            {
                dateValue = "0" + dateMonth.ToString();
            }
            Type DiaryType = typeof(UnitDiary);
            StringBuilder builder = new StringBuilder();

            foreach (var value in DiaryType.GetProperties())
            {
                builder.Append($"{value.Name}, ");
            }
            builder.Remove(builder.Length - 2, 2);

            if (!Directory.Exists(DesktopLocation))
            {
                Directory.CreateDirectory(DesktopLocation);
            }

            using(StreamWriter writer = new StreamWriter($@"{DesktopLocation}/DiaryReport{DateTime.Now.Year}{dateValue}{dayValue}.csv"))
            {
                writer.WriteLine(builder.ToString());
                StringBuilder ColumnValues = new StringBuilder();

                foreach (var Diary in list)
                {
                    foreach (var item in DiaryType.GetProperties())
                    {
                        if(item.GetValue(Diary, null) != null)
                        {
                            ColumnValues.Append($"{item.GetValue(Diary, null)}, ");
                        }
                    }
                    ColumnValues.Remove(ColumnValues.Length - 2, 2);
                    writer.WriteLine(ColumnValues.ToString());
                    ColumnValues.Clear();
                }
            }
        }
    }
}
