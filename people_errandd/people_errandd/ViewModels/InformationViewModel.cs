using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using people_errandd.Views;



namespace people_errandd.ViewModels
{   
    class InformationViewModel : HttpResponse
    {
        public async Task<bool> UpdateInformationRecord(string _name, string _phone, string _email)
        {
            List<information> informations = new List<information>();
            information information = new information()
            {
                hashaccount = Preferences.Get("HashAccount", ""),
                name = _name,
                phone = _phone,
                email = _email,
                img = ""
            };          
            informations.Add(information);
            try
            {
                var WorkRecord = JsonConvert.SerializeObject(informations);
                HttpContent content = new StringContent(WorkRecord);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(basic_url + ControllerNameInformation + "update_information", content);
                if (response.StatusCode.ToString() == "OK")
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return false;
        }
        public async Task<information> GetInformation(string _HashAccount)
        {
            try
            {
             response = await client.GetAsync(basic_url + ControllerNameInformation + _HashAccount);
             var result = await response.Content.ReadAsStringAsync();              
             List<information> informations = JsonConvert.DeserializeObject<List<information>>(result);               
             return informations[0];
            }
            catch (Exception)
            {
            }
            return null;
        }
        public async Task<string> GetUserName(string _HashAccount)
        {           
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameInformation + _HashAccount);
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode.ToString() == "OK")
                {
                    List<information> information = JsonConvert.DeserializeObject<List<information>>(result);
                    Preferences.Set("UserName",information[0].name);
                }
            }
            catch (Exception)
            {
            }
            return Preferences.Get("UserName", "User");
        }
        public async Task<bool> ConfirmEmail(string _Email)
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameInformation + "BoolEmployeeInformationEmail?hash_company="+ Preferences.Get("CompanyHash","")+"&email="+_Email);
                var result = await response.Content.ReadAsStringAsync();
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
            }
            return true;
        }
    }
}


