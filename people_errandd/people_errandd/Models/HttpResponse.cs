using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using people_errandd.Models;
using System.Text;

namespace people_errandd.Models
{

    public class HttpResponse
    {
        //static company c = new company();
        public static HttpClient client = new HttpClient();
        public static HttpResponseMessage response = new HttpResponseMessage();
        public static readonly string basic_url = "http://163.18.110.100/api/";//主機ㄉURL  
        public static readonly string ControllerNameCompany = "Companies/";//Company api
        public static readonly string ControllerNameEmployee = "employees/";//Employee api
        public static readonly string ControllerNameWorkRecord = "EmployeeWorkRecords/";//workRecord api
        public static readonly string ControllerNameLeaveRecord = "EmployeeLeaveRecords/";//LeaveRecord api
        public static readonly string ControllerNameTripRecord = "EmployeeTripRecords/";//TripRecord api
        public static readonly string ControllerNameInformation = "EmployeeInformations/";//EmployeeInformations api
       // public static string _HashAccount { get; set; }
        public static string companyHash { get; set; }
        public static string GetResponse { get; set; }
        //public static string uuid { get; set; }
        //static string company_hash = "67103E3E43ED266D8FC2F37CEB11E6";        
        //public static async Task workPost(int workTypeId)
        //{

        //   
        //}



    }
}