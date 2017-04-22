using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseManager.Modules;

namespace CaseManager.Modules.DataStructures
{
    public class DataModel
    {
        public Patient CurrentPatient { get; set; }
        public string CaseCount { get; set; }
        private int count;
        public DateTime LastModified { get; set; }
        public int RevenueFromNew { get; set; }
        public int RevenueFromOld { get; set; }
        public DataProvider DataSource { get; set; }
        public DailyStats TodaysStats { get; set; } = new DailyStats();

        public DataModel()
        {
            GetDataFromDB();
        }

        public void ResetData()
        {
            CurrentPatient = new Patient();
            LastModified = DateTime.Now;
            count = 1;
            CaseCount = LastModified.Year.ToString() + LastModified.Month.ToString() + "-" + count.ToString();
            RevenueFromNew = 0;
            RevenueFromOld = 0;  
        }

        public void IncrCase()
        {
            count++;
            CaseCount = CaseCount.Split('-')[0] + "-" + count.ToString();
        }

        public void DecrCase()
        {
            count--;
            CaseCount = CaseCount.Split('-')[0] + "-" + count.ToString();
        }

        private void NewPatient()
        {
            CurrentPatient = new Patient();
            IncrCase();
            CurrentPatient.ID = CaseCount;
        }

        public void ClearPatientData()
        {
            CurrentPatient = new Patient();
            CurrentPatient.ID = CaseCount;
        }

        public void SubmitPatient()
        {
            //TODO: Insert PatientData to DB
            NewPatient();
        }

        public async void GetDataFromDB()
        {
            if (DataSource == null) DataSource = new DataProvider();
            var rows = await DataSource.Select(Strings.Stats, Strings.LastModified + "," + Strings.Count + "," + Strings.RevNew + "," + Strings.RevOld);
            int rCount = rows.Count - 1;
            if (rCount>0)
            {
                if(!CheckNewMonth(rows[rCount]))
                {
                    LastModified = DateTime.Parse(rows[rCount][0]);
                    count = int.Parse(rows[rCount][1]);
                    RevenueFromNew = int.Parse(rows[rCount][2]);
                    RevenueFromOld = int.Parse(rows[rCount][3]);
                    CaseCount = LastModified.Year.ToString() + LastModified.Month.ToString() + "-" + count;
                }
                CaseExpiryCheck();
            }
            else
            {
                DataSource.Insert(new List<string>() { DateTime.Today.ToString("yyyyMMdd ")+DateTime.Today.ToString().Split(' ')[1], "0", "0", "0" }, Strings.Stats);
            }
            InitializeDailyStats();
        }

        private void CaseExpiryCheck()
        {
            DataSource.Update(Strings.Patient, Strings.Expired + "='True'", Strings.CaseDate + "<'" + DateTime.Now.AddMonths(-3).ToString() + "'");
        }

        private bool CheckNewMonth(List<string> list)
        {
            var ModifiedDate = DateTime.Parse(list[0]);
            var Now = DateTime.Now;
            if(Now.Month-ModifiedDate.Month != 0)
            {
                if(Now.Day != ModifiedDate.Day)
                {
                    LastModified = Now;
                    count = 0;
                    CaseCount = Now.Year.ToString() + Now.Month.ToString() + "-" + count;
                    RevenueFromNew = 0;
                    RevenueFromOld = 0;
                    DataSource.Insert(new List<string>() { Now.ToString(), "0", "0", "0" }, Strings.Stats);
                    return true;
                }
            }
            return false;
        }

        public async void InitializeDailyStats()
        {
            var row = await DataSource.Select(Strings.DailyStats, Strings.RevNew + "," + Strings.RevOld, Strings.Day + "='" + TodaysStats.Today.Day + "' AND " + Strings.Month + "='" + TodaysStats.Today.Month + "' AND " + Strings.Year + "='" + TodaysStats.Today.Year + "'");
            if (row.Count != 0) 
            {
                TodaysStats.RevFromNew = int.Parse(row[0][0]);
                TodaysStats.RevFromOld = int.Parse(row[0][1]);
            }
            else
            {
                DataSource.Insert(new List<string>() { TodaysStats.Today.Day.ToString(), TodaysStats.Today.Month.ToString(), TodaysStats.Today.Year.ToString(), TodaysStats.RevFromNew.ToString(), TodaysStats.RevFromOld.ToString() }, Strings.DailyStats);
            }
        }
    }
}