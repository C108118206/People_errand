using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.Views;
using people_errandd.ViewModels;
using people_errandd.Models;
using System.Collections;
using System.Globalization;
using System.IO;
using Xamarin.Essentials;
using Plugin.SharedTransitions;

namespace people_errandd
{public interface IAppSettingsHelper
        {
            void OpenAppSetting();
        }
    public partial class App : Application
    {
        
        static Database dataBase;
        Work work = new Work();
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }
        public static Database DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data.db3"));
                }
                return dataBase;
            }
        }
        public App()
        {
            InitializeComponent();
            CultureInfo ChineseCulture = new CultureInfo("zh-TW");
            CultureInfo.DefaultThreadCurrentCulture = ChineseCulture;
            MainPage = new SharedTransitionNavigationPage(new LoginPage());
            //NavigationPage
        }

        protected override void OnStart()
        {
            GetLocation();
            GetConnectivity("start");
            bool hasKey = Preferences.ContainsKey("Login");
            if (hasKey)
            {
                MainPage = new SharedTransitionNavigationPage(new MainPage());
                //NavigationPage
            }
            
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
            GetLocation();
            GetConnectivity("resume");
            MessagingCenter.Send<App>(this, "Hi");
        }
        private async void GetLocation()
        {
            Preferences.Set("gpsText", "定位已開啟");
            Page page = MainPage;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                Latitude = location.Latitude;
                Longitude = location.Longitude;
            }
            catch (Exception)
            {
                Preferences.Set("gpsText", "定位未開啟");
            }
        }
        private async void GetConnectivity(string status)
        {
            Page page = MainPage;
            try
            {
                if (status == "start")
                {
                    switch (await work.GetWorkType())
                    {
                        case 0:
                        case 1:
                            await work.PostWork(1, Latitude, Longitude, false);
                            break;
                        case 2:
                            await work.PostWork(2, Latitude, Longitude, false);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    await work.GetWorkType();
                }
            }
            catch (Exception)
            {
                await page.DisplayAlert("", "請檢查網路狀態", "確定");
                return;
            }
        }
    }
}