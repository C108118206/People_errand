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

namespace people_errandd.ViewModels
{
    class Login : HttpResponse, INotifyPropertyChanged//繼承HttpResponse,實作INPC
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static async Task<bool> ConfirmCompanyHash(string code)
        {
            response = await client.GetAsync(basic_url + ControllerNameCompany + code);//HTTP GET
            if (response.StatusCode.ToString() == "OK")
            {
                string jsonCompany= await response.Content.ReadAsStringAsync();//將JSON轉成string
                string[] _CompanyInformation= jsonCompany.Split('\n');//分割字串
                companyHash = _CompanyInformation[0];
                return true;
            }
            return false;
        }
        public static async Task<bool> ConfirmUUID(string UUID)//判斷裝置UUID是否存在資料庫
        {
            response = await client.GetAsync(basic_url + ControllerNameEmployee + UUID);

            if (response.StatusCode.ToString() == "OK")
            {
                return true;
            }
            return false;
        }
        public static async Task SetUUID()
        {
            var _UUID = Preferences.Get("uuid", "");//存取裝置UUID  
            List<employee> employees = new List<employee>();
            employee employee = new employee()
            { 
            companyhash = companyHash,
            phonecode = _UUID
            };   
            employees.Add(employee);
            var str = JsonConvert.SerializeObject(employees);//序列化成json
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");//set content-Type header
            response = await client.PostAsync(basic_url + ControllerNameEmployee + "regist_employee", content);//HTTP POST
        }
        public static async Task<string> GetHashAccount(string uuid)
        {
            response = await client.GetAsync(basic_url + ControllerNameEmployee + uuid);
            string HashAccount = await response.Content.ReadAsStringAsync();//將JSON轉成string
            return HashAccount;
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