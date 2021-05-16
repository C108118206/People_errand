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
             var deviceId = Preferences.Get("uuid", string.Empty);
            if (string.IsNullOrEmpty(deviceId))
            {
                deviceId = Guid.NewGuid().ToString();
                Preferences.Set("uuid", deviceId);
            }
        }

        private async void LogInButton(object sender, EventArgs e)
        {
            var uuu = Preferences.Get("uuid", "");
            if (await Login.ConfirmCompanyHash(company.Text.Trim()))
            {
                if (await Login.ConfirmUUID(uuu))
                {
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                    Preferences.Set("Login", "exist");
                }
                else
                {
                    await Login.SetUUID();
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("錯誤", "輸入錯誤", "請重新輸入");
            }



        }

    }
}