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

    }
}
