using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace people_errandd.Models
{

    public class work
    {
        //  public int ID { get; set; }
        public string hashAccount { get; set; }

        public int workTypeId { get; set; }
        public double coordinateX { get; set; }
        public double coordinateY { get; set; }
        //  public DateTime Date { get; set; }

    }
    public class company
    {

        public string CompanyId { get; set; }
        public string CompanyHash { get; set; }
        public string ManagerHash { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class employee
    {
        public string employeeId { get; set; }
        public string hashaccount { get; set; }
        public string name { get; set; }
        public string phonecode { get; set; }
        public DateTime createTime { get; set; }

        public string companyhash { get; set; }


    }

}