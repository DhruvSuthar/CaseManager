using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManager.Modules
{
    public class Strings
    {
        public static string ConnectionString { get { return "Persist Security Info = False; Integrated Security = SSPI; database = CaseMgmtData; server = GAMERSREPUBLIC\\SQLEXPRESS"; } }

        //Tables
        public static string Patient = "PatientData";
        public static string Stats = "UsageStats";
        public static string DailyStats = "DailyStats";

        //Columns
        public static string LastModified = "LastModified";
        public static string Count = "CaseCount";
        public static string RevOld = "RevFromOld";
        public static string RevNew = "RevFromNew";
        public static string Expired = "Expired";
        public static string PatientName = "Name";
        public static string CaseID = "CID";
        public static string CaseDate = "CaseDate";
        public static string ExpiresOn = "Expdate";
        public static string Date = "Date";
        public static string PatientInstance = "Data";
        public static string Amount = "Amount";
        public static string Day = "Day";
        public static string Month = "Month";
        public static string Year = "Year";

        //Images
        public static string Patient_Dark = "/Assets/patient-dark.png";
        public static string Patient_Light = "/Assets/patient-light.png";
        public static string Stats_Dark = "/Assets/statistics-dark.png";
        public static string Stats_Light = "/Assets/statistics-light.png";
    }
}
