using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;

namespace people_errandd.Models
{
    class Login : HttpResponse, INotifyPropertyChanged//繼承HttpResponse,實作INPC
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private static string GetResponse;
        public async Task<bool> ConfirmCompanyHash(string code)
        {
            response = await client.GetAsync(basic_url + ControllerNameCompany + code);//HTTP GET
            if (response.StatusCode.ToString() == "OK")
            {
                GetResponse = await response.Content.ReadAsStringAsync();//將JSON轉成string
                string[] _CompanyInformation = GetResponse.Split('\n');//分割字串
                Preferences.Set("CompanyHash",_CompanyInformation[0]);
                return true;
            }
            return false;
        }
        public async Task<bool> ConfirmUUID(string UUID)//判斷裝置UUID是否存在資料庫
        {
            response = await client.GetAsync(basic_url + ControllerNameEmployee + UUID);
            if (response.StatusCode.ToString() == "OK")
            {
                return true;
            }
            return false;
        }
        public async Task<bool> SetUUID()
        {
            var _UUID = Preferences.Get("uuid", "");//存取裝置UUID  
            List<employee> employees = new List<employee>();
            employee employee = new employee()
            {
                companyhash =Preferences.Get("CompanyHash",""),
                phonecode = _UUID
            };
            employees.Add(employee);
            try
            {
                var str = JsonConvert.SerializeObject(employees);//序列化成json
                HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");//set content-Type header
                response = await client.PostAsync(basic_url + ControllerNameEmployee + "regist_employee", content);//HTTP POST               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<string> GetHashAccount(string uuid)
        {
            response = await client.GetAsync(basic_url + ControllerNameEmployee + uuid);
            GetResponse = await response.Content.ReadAsStringAsync();//將JSON轉成string
            return GetResponse;
        }
        public async Task<bool> SetInformation(string _Name, string _Email)
        {
            try
            {
                List<information> informations = new List<information>();
                information information = new information()
                {
                    hashaccount = await GetHashAccount(Preferences.Get("uuid", "")),
                    name = _Name,
                    email = _Email
                };
                informations.Add(information);
                var str = JsonConvert.SerializeObject(informations);
                HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
                response = await client.PostAsync(basic_url + ControllerNameInformation + "add_information", content);
                Preferences.Set("UserName", _Name);
                Preferences.Set("email", _Email);
                
                if (response.StatusCode.ToString() == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                return false;
            }
        }
        public async Task<bool> Reviewed()
        {
            try
            {
                string _Ha = await GetHashAccount(Preferences.Get("uuid", ""));
                response = await client.GetAsync(basic_url + ControllerNameInformation + _Ha);
                GetResponse = await response.Content.ReadAsStringAsync();
                //information UserInf = JsonConvert.DeserializeObject<information>(GetResponse);
                string[] _UserInf = GetResponse.Split(',');
                if (_UserInf[1] != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            return false;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // 若 PropertyChanged 有被綁定，則將會執行這個事件，
                // 以進行頁面控制項的內容更新
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}