using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManager.Modules.DataStructures
{
    public class DailyStats
    {
        public DateTime Today { get; set; } = DateTime.Today;
        public int RevFromNew { get; set; }
        public int RevFromOld { get; set; }
    }
}
