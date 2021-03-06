﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public int CashTaken { get; set; }

        public Patient()
        {
            CaseDate = DateTime.Now;
            ExpDate = CaseDate.AddMonths(3);
            HistoryData = new List<History>();
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static Patient GetPatient(string data)
        {
            return JsonConvert.DeserializeObject<Patient>(data);
        }
    }
}
