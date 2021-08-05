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
using System.Threading.Tasks;

namespace people_errandd
{
    public interface IAppSettingsHelper
    {
        void OpenAppSetting();
    }
    public partial class App : Application
    {      
        static Database dataBase;
        Work work = new Work();
        InformationViewModel information = new InformationViewModel();
        geoLocation location = new geoLocation();
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
            Device.SetFlags(new[] { "Expander_Experimental" });
            MainPage = new SharedTransitionNavigationPage(new LoginPage());
            //NavigationPage
        }

        protected async override void OnStart()
        {       
            bool hasKey = Preferences.ContainsKey("HashAccount");
            if (hasKey)
            {
                Console.WriteLine(Preferences.Get("HashAccount", ""));
                MainPage = new SharedTransitionNavigationPage(new MainPage());
                await information.GetUserName(Preferences.Get("HashAccount", ""));
                //NavigationPage
            }
            await GetLocation();
            GetConnectivity("start");
            var Seconds = TimeSpan.FromSeconds(20);
            Device.StartTimer(Seconds, () => {
                GetLocation();
                return true;
            });
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
        private async Task GetLocation()
        {
            Preferences.Set("gpsText", "定位已開啟");
            Preferences.Set("GpsButtonColor", "#5C76B1");
            try
            {
                (Latitude, Longitude) =await location.GetLocation("Back");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        private async void GetConnectivity(string status)
        {        
            Page page = MainPage;
            var _page = new MainPage();
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