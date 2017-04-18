using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManager.Modules
{
    public class Strings
    {
        public static string ConnectionString { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        //Tables
        public static string Patient = "PatientData";
        public static string Stats = "Statistics";
        public static string Turnover = "Turnover";

        //Columns
        public static string LastModified = "LastModified";
        public static string Count = "CaseCount";
        public static string RevOld = "RevFromOld";
        public static string RevNew = "RevFromNew";
        public static string Expired = "Expired";
        public static string PatientName = "Name";
        public static string CaseID = "CID";
        public static string CaseDate = "CaseDate";
        public static string Date = "Date";
        public static string Amount = "Amount";

    }
}
