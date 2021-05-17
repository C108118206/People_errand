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

namespace people_errandd
{
    public partial class App : Application
    {
        static phoneCodeDataBase dataBase;
        public static phoneCodeDataBase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new phoneCodeDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data.db3"));
                }
                return dataBase;
            }
        }
        public App()
        {
            InitializeComponent();
            CultureInfo ChineseCulture = new CultureInfo("zh-TW");
            CultureInfo.DefaultThreadCurrentCulture = ChineseCulture; 
                MainPage = new NavigationPage(new LoginPage());
            
        }

        protected override void OnStart()
        {
            bool hasKey = Preferences.ContainsKey("Login");
            if (hasKey)
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}