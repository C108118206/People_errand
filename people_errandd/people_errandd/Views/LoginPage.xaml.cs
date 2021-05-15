using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.ViewModels;
using people_errandd.Models;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //隱藏navigationpage導航欄。
            NavigationPage.SetHasNavigationBar(this, false);

            Animation ani = new Animation();

            var deviceId = Preferences.Get("me", string.Empty);
           if(string.IsNullOrEmpty(deviceId))
            {
                deviceId = Guid.NewGuid().ToString();
                Preferences.Set("me", deviceId);
                
            }

        }
        
        private async void LogInButton(object sender, EventArgs e)
        {
            //var m = Preferences.Get("me","");
            //await DisplayAlert("", m, "ok");
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
            //try
            //{
            //    if (await HttpResponse.employee(company.Text.Trim(), account.Text.Trim()))
            //    {
            //        Navigation.InsertPageBefore(new MainPage(), this);
            //        await Navigation.PopAsync();
                    
            //    }
            //    else if (company.Text.Trim() == "0" && account.Text.Trim() == "manager")
            //    {
            //        Navigation.InsertPageBefore(new MainPageeM(), this);
            //        await Navigation.PopToRootAsync();
            //    }   
            //    else
            //    {
            //        await DisplayAlert("錯誤", "輸入錯誤", "請重新輸入");
            //    }
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
            
        }

    }
}