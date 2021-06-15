using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace people_errandd.Models
{
    public class WorkRecordModels
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string status { get; set; }
        public string time { get; set; }
    }
    public class DayOffRecordModels
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string   Reason { get; set; }
        public string DayOffType { get; set; }
        public string Date { get; set; }
    }
    public class GoOutRecordModels
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
    }


}
