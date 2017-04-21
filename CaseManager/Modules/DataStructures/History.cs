using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManager.Modules.DataStructures
{
    public class History
    {
        public DateTime Date { get; set; }
        public string BloodPressure { get; set; }
        public float Temperature { get; set; }
        public string HistoryText { get; set; }
        public string Treatment { get; set; }
    }
}
