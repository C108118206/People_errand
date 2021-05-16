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
    class Login : HttpResponse, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private static string _company;
        //public ICommand LoginButton { get; set; }

        //public static string company
        //{
        //    get { return _company; }
        //    set
        //    {
        //        if(_company!=value)
        //        {
        //            _company = value;
        //            //OnPropertyChanged("company");
        //           // UpdateProduct();
        //        }
        //    }
        //}
        //public Login()
        //{
        //    LoginButton =new Command(async() =>
        //    {
        //        await ConfirmCompanyHash(company);
        //    });
        //}

        public static async Task<bool> ConfirmCompanyHash(string code)
        {
            response = await client.GetAsync(basic_url + ControllerNameCompany + code);
            if (response.StatusCode.ToString() == "OK")
            {
                string json = await response.Content.ReadAsStringAsync();
                string[] word = json.Split('\n');
                //company companies = JsonConvert.DeserializeObject<company>(json);
                companyHash = word[0];
                return true;
            }
            return false;
        }
        public static async Task<bool> ConfirmUUID(string UUID)
        {
            response = await client.GetAsync(basic_url + ControllerNameEmployee + UUID);

            if (response.StatusCode.ToString() == "OK")
            {
                //string json = await response.Content.ReadAsStringAsync();
                //employee employee = JsonConvert.DeserializeObject<employee>(json);
                return true;
            }
            return false;
        }
        public static async Task SetUUID()
        {
            var _UUID = Preferences.Get("uuid", "");
            List<employee> employees = new List<employee>();
            employee employee = new employee();
            employee.companyhash = companyHash;
            employee.phonecode = _UUID;
            employees.Add(employee);
            var str = JsonConvert.SerializeObject(employees);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            response = await client.PostAsync(basic_url + ControllerNameEmployee + "regist_employee", content);
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