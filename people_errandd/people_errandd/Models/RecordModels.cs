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

    }
}