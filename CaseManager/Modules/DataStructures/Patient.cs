using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManager.Modules.DataStructures
{
    public class Patient
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime CaseDate { get; set; }
        public DateTime ExpDate { get; set; }
        public List<History> HistoryData { get; set; }
        public float CashTaken { get; set; }

        public Patient()
        {
            CaseDate = DateTime.Now;
            ExpDate = CaseDate.AddMonths(3);
            HistoryData = new List<History>();
        }
    }
}
