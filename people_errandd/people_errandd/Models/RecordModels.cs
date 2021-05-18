using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace people_errandd.Models
{
    public class RecordModels
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string status { get; set; }
        public string time { get; set; }

        public string image { get; set; }
        public string workorworkoff { get; set; }
        public string color { get; set; }

        
        public string leavegoouttime { get; set; }
        public string backgoouttime { get; set; }
        public string location { get; set; }
        public string messagegoout { get; set; }
        public string statusgoout { get; set; }
        public string leavedayoff { get; set; }
        public string backdayoff { get; set; }
        public string selection { get; set; }
        public string messagedayoff { get; set; }
        public string statusdayoff { get; set; }



    }
}