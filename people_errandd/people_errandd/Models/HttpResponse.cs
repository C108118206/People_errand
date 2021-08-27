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
        public static readonly string ControllerNameTrip2Record = "EmployeeTrip2Record/";//TripRecord api
        public static readonly string subscriptionKey = "2f553f597a914324882f8f0f3db42a41";//azure translate api key
        public static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";//azure translate url
        public static readonly string LanguageRoute = "/detect?api-version=3.0";//language route             
        public static string GetResponse { get; set; }
    }
}