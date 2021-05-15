using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using people_errandd.Models;
using System.Text;

namespace people_errandd.ViewModels
{

    public class HttpResponse
    {
        //static company c = new company();
        static HttpClient client = new HttpClient();
        static HttpResponseMessage response = new HttpResponseMessage();
        static readonly string basic_url = "http://163.18.110.100/api/";
        static readonly string ControllerNameCompany = "Companies/";
        static readonly string ControllerNameEmployee = "employees/";
        static readonly string ControllerNameWorkRecord = "EmployeeWorkRecords/";
        
        public static string HashAccount { get; set; }
        public static string companyHash { get; set; }
        //static string company_hash = "67103E3E43ED266D8FC2F37CEB11E6";

        public static async Task<bool> company(string code, string id)
        {
            bool login_status = false;
            response = await client.GetAsync(basic_url + ControllerNameCompany + code);
            string json = await response.Content.ReadAsStringAsync();
            company companies = JsonConvert.DeserializeObject<company>(json);       
            if (login_status = companies.Name == id)
            {
                login_status = true;
                companyHash = companies.CompanyHash;
            }
            return login_status;
        }
        public static async Task<bool> employee(string code, string id)
        {
            bool login_status = false;
            response = await client.GetAsync(basic_url + ControllerNameEmployee + code);
            string json = await response.Content.ReadAsStringAsync();
            employee employee = JsonConvert.DeserializeObject<employee>(json);
            if (login_status = employee.name == id)
            {
                login_status = true;
                HashAccount = employee.hashaccount;
            }
            return login_status;
        }
        public static async Task<int> workGet()
        {
            response = await client.GetAsync(basic_url + ControllerNameWorkRecord + HashAccount);
            string json = await response.Content.ReadAsStringAsync();
            work workStatus = JsonConvert.DeserializeObject<work>(json);
            return workStatus.workTypeId;
           
        }
        public static async Task workPost(int workTypeId)
        {
            
            work work = new work();
            work.workTypeId = workTypeId;
            work.hashAccount = HashAccount;
            work.coordinateX = 22.75;
            work.coordinateY = 120.32;
            var JsonString = JsonConvert.SerializeObject(work);
            HttpContent content = new StringContent(JsonString,Encoding.UTF8,"application/json");    
             response=await client.PostAsync(basic_url + ControllerNameWorkRecord+"add_workRecord?",content);
            // await response.Content.ReadAsStringAsync();
            //response.EnsureSuccessStatusCode(); 
            //try
            //{
            //    var location = await Geolocation.GetLastKnownLocationAsync();
            //    if(location!=null)
            //    {

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }



    }
}