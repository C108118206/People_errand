using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using people_errandd.Views;



namespace people_errandd.ViewModels
{
    //class ValidatorViewModel : NotifyPropertyChanged
    //{
    //    public information Information { get; set; }
    //    public string phone = string.Empty;
    //    public string Phone
    //    {
    //        get { return phone; }
    //        set { SetProperty(ref phone, value); }
    //    }
    //    string email = string.Empty;
    //    public string Email
    ////    {
    ////        get { return email; }
    ////        set { SetProperty(ref email, value); }
    ////    }
    ////    private ICommand EnterCommand;
    ////    public ICommand enterCommand
    ////    {
    ////        get
    ////        {
    ////            return EnterCommand ?? (EnterCommand = new Command(ExecuteLoginCommand));
    ////        }
    ////    }
    ////    private readonly IValidator _validator;
    ////    public ValidatorViewModel()
    ////    {
    ////        _validator = new UserValidator();
    ////    }
    ////    private string validateMsg;
    ////    public string ValidateMsgEmail
    ////    {
    ////        get
    ////        {
    ////            return validateMsg;
    ////        }
    ////        set
    ////        {
    ////            SetProperty(ref validateMsg, value);
    ////        }
    ////    }
    ////    public string ValidateMsgPhone
    ////    {
    ////        get
    ////        {
    ////            return validateMsg;
    ////        }
    ////        set
    ////        {
    ////            SetProperty(ref validateMsg, value);
    ////        }
    ////    }
    ////    private async void ExecuteLoginCommand(object obj)
    ////    {

    ////        try
    ////        {
    ////            if (Information == null)
    ////            {
    ////                Information = new information();
    ////            }
    ////            Information.phone = phone;
    ////            Information.email = email;
    ////            Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    ////            Match matchemail = regexemail.Match(email);
    ////            Regex regexphone = new Regex("^09");
    ////            Match matchphone = regexphone.Match(phone);
    ////            if (matchemail.Success&&matchphone.Success)
    ////            {
    ////                var Page = new AboutPage();
    ////                //TODO 作服务端登录验证
    ////                await Page.DisplayAlert("","修改成功","確認");
    ////                await Page.Navigation.PopAsync();
    ////            }
    ////            else if(matchemail.Success)
    ////            {
    ////                ValidateMsgPhone = "輸入格式錯誤";
    ////            }
    ////            else if (matchphone.Success)
    ////            {
    ////                ValidateMsgEmail = "輸入格式錯誤";
    ////            }

    ////        }
    ////        catch (Exception ex)
    ////        {
    ////            ValidateMsgEmail = ex.Message;
    ////        }
    ////        finally
    ////        {
    ////        }
    ////        //await Task.FromResult("");
    ////    }
    ////}

    //public interface IValidationRule<T>
    //{
    //    string ValidationMessage { get; set; }
    //    bool Check(T value);
    //}
    //class ValidatorViewModel
    //{
    //    public class EmailRule<T> : IValidationRule<T>
    //    {
    //        public string ValidationMessage { get; set; }

    //        public bool Check(T value)
    //        {
    //            if (value == null)
    //            {
    //                return false;
    //            }
    //            var str = value as string;
    //            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    //            Match match = regex.Match(str);
    //            return match.Success;
    //        }
    //    }
    //    public ValidatableObject<string> UserName
    //    {
    //        get
    //        {
    //            return _userName;
    //        }
    //        set
    //        {
    //            _userName = value;
    //            RaisePropertyChanged(() => UserName);
    //        }
    //    }

    //    public ValidatableObject<string> Password
    //    {
    //        get
    //        {
    //            return _password;
    //        }
    //        set
    //        {
    //            _password = value;
    //            RaisePropertyChanged(() => Password);
    //        }
    //    }
    //}
    
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

    }
}


