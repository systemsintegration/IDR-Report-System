using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace UDReports
{
    public class UnitDiary
    {
        public int DiaryYear { get; set; }
        public int DiaryNumber { get; set; }
        public string DiaryDate { get; set; }
        public string CertifierID { get; set; }
        public int CertifierEDIPI { get; set; }
        public string CertifierLastName { get; set; }
        public string CycleDate { get; set; }
        public int CycleNumber { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public int Total { get; set; }
        public bool Uploaded { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }

        public List<UnitDiary> GetDiaries()
        {
            List<UnitDiary> diaries = new List<UnitDiary>();
            Database database = new Database();
            SQLiteDataReader reader = database.DataReader($"SELECT UDYear, UDNumber, UDDate, CertifierID, CertifierEDIPI, LastName, CycleDate, CycleNumber, Accepted, Rejected, Total, Uploaded, Uploadedby, UploadedOn " +
                $"FROM DiaryTable2018 WHERE Uploaded = '{Uploaded}'");
            while (reader.Read())
            {
                if (Uploaded == false)
                {
                    diaries.Add(new UnitDiary
                    {
                        DiaryYear = reader.GetInt32(0),
                        DiaryNumber = reader.GetInt32(1),
                        DiaryDate = reader.GetDateTime(2).ToShortDateString(),
                        CertifierID = reader.GetString(3),
                        CertifierEDIPI = reader.GetInt32(4),
                        CertifierLastName = reader.GetString(5),
                        CycleDate = reader.GetDateTime(6).ToShortDateString(),
                        CycleNumber = reader.GetInt32(7),
                        Accepted = reader.GetInt32(8),
                        Rejected = reader.GetInt32(9),
                        Total = reader.GetInt32(10),
                        Uploaded = bool.Parse(reader.GetString(11))
                    });
                }
                if(Uploaded == true)
                {
                    diaries.Add(new UnitDiary
                    {
                        DiaryYear = reader.GetInt32(0),
                        DiaryNumber = reader.GetInt32(1),
                        DiaryDate = reader.GetDateTime(2).ToShortDateString(),
                        CertifierID = reader.GetString(3),
                        CertifierEDIPI = reader.GetInt32(4),
                        CertifierLastName = reader.GetString(5),
                        CycleDate = reader.GetDateTime(6).ToShortDateString(),
                        CycleNumber = reader.GetInt32(7),
                        Accepted = reader.GetInt32(8),
                        Rejected = reader.GetInt32(9),
                        Total = reader.GetInt32(10),
                        Uploaded = bool.Parse(reader.GetString(11)),
                        UploadedBy = reader.GetString(12),
                        UploadedOn = reader.GetDateTime(13)
                    });
                }
            }
            return diaries.OrderBy(o => o.DiaryNumber).ToList();
        }

        public void SaveReport(List<UnitDiary> list)
        {
            FileIO fileIO = new FileIO();
            fileIO.WriteToDesktop(list);
        }
    }
}
