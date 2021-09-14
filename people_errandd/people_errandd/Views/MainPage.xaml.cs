using System;
using Xamarin.Forms;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Text;
using Xamarin.CommunityToolkit;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Maps;

namespace people_errandd.Views
{
    public partial class MainPage : TabbedPage
    {
        private readonly Work Work = new Work();
        bool allowTap = true;
        private readonly geoLocation geoLocation = new geoLocation();
        public MainPage()
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);           
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MainPageViewModel mp = new MainPageViewModel();
            await mp.GetAudit();
            workOn.IsEnabled = Preferences.Get("WorkOnButtonStauts", workOn.IsEnabled = true);
            workOff.IsEnabled = Preferences.Get("WorkOffButtonStauts", workOff.IsEnabled = false);
            workOn.Opacity = Preferences.Get("WorkOnButtonView", workOn.Opacity = 1);
            workOff.Opacity = Preferences.Get("WorkOffButtonView", workOff.Opacity = 0.2);
            workOnText.Opacity = Preferences.Get("WorkOnText", workOnText.Opacity = 1);
            workOffText.Opacity = Preferences.Get("WorkOffText", workOffText.Opacity = 0.2);
            username.Text = Preferences.Get("UserName", "");
            worktimetitle.Text = Preferences.Get("WorkTimeTitle","");
            worktime.Text = Preferences.Get("WorkTime","");
        }
        protected override void OnDisappearing()
        {
            if (geoLocation.cts != null && !geoLocation.cts.IsCancellationRequested)
                geoLocation.cts.Cancel();
            base.OnDisappearing();
        }

        private async void GoToWork(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (await Work.GetWorkType() == 2 || await Work.GetWorkType() == 0)
                    {
                        (double x, double y) = await geoLocation.GetLocation("WorkOn");
                        if (await geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(1, x, y, true))
                            {
                                await DisplayAlert("", "上班打卡成功", "確定");                           
                                WorkOnSet();
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤", "確定");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("Error", "網路錯誤", "確定");
                    }
                    else
                    {
                        await DisplayAlert("Error", "已上班", "確定");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "錯誤", "確定");
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void OffWork(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (await Work.GetWorkType() == 1)
                    {
                        (double x, double y) = await geoLocation.GetLocation("WorkOff");
                        if (await geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(2, x, y, true))
                            {
                                await DisplayAlert("", "下班打卡成功", "確定");                               
                                WorkOffSet();
                            }
                            else
                            {
                                await DisplayAlert("Error", "發生錯誤", "確定");
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤", "確定");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("Error", "錯誤", "確定");
                    }
                    else
                    {
                        await DisplayAlert("Error", "已下班", "確定");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "錯誤", "確定");
            }
            finally
            {
                allowTap = true;
            }
        }

        public void WorkOffSet()
        {
            //Preferences.Set("statusNow", status.Text = "已下班");
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = false);
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 1);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 0.2);
            Preferences.Set("WorkOnText", workOnText.Opacity = 1);
            Preferences.Set("WorkOffText", workOffText.Opacity = 0.2);
            Preferences.Set("WorkTimeTitle", worktimetitle.Text="下班打卡 at ");
            Preferences.Set("WorkTime", worktime.Text = DateTime.Now.ToString("t"));
            //Preferences.Set("statusBack", "#CB2E2E");
            //statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
        }
        public void WorkOnSet()
        {
            //Preferences.Set("statusNow", status.Text = "上班中");
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = false);
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 0.2);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 0.8);
            Preferences.Set("WorkOnText", workOnText.Opacity = 0.2);
            Preferences.Set("WorkOffText", workOffText.Opacity = 0.8);
            Preferences.Set("WorkTimeTitle", worktimetitle.Text = "上班打卡 at ");
            Preferences.Set("WorkTime", worktime.Text = DateTime.Now.ToString("t"));
            //Preferences.Set("statusBack", "#4AD395");
            //statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
        }
        private async void OnTapped(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new ImportantAudit());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void GoOutButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await PopupNavigation.Instance.PushAsync(new AdvanceGoOut("請選擇"));
                    // await Navigation.PushAsync(new GoOut());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void AboutPageButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new AboutPage());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void DayOffButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new TakeDayOff());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void GpsButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (GPSText.Text == "定位未開啟")
                        DependencyService.Get<IAppSettingsHelper>().OpenAppSetting();
                    else
                    {
                        await PopupNavigation.Instance.PushAsync(new MapPage());
                    }
                }
            }
            finally
            {
                allowTap = true;
            }
        }
    }
}

