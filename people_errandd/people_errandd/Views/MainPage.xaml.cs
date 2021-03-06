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
            var clr = Color.FromHex("#FFFFFF"); 
            this.BarBackgroundColor = clr;
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Audits.ItemsSource = await MainPageViewModel.GetAudit();
            Audits.IsVisible = Audits.ItemsSource != null;
            AuditText.IsVisible = Audits.IsVisible;
            workOn.IsEnabled = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOnButtonStauts", workOn.IsEnabled = true);
            workOff.IsEnabled = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOffButtonStauts", workOff.IsEnabled = false);
            workOn.Opacity = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOnButtonView", workOn.Opacity = 1);
            workOff.Opacity = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOffButtonView", workOff.Opacity = 0.2);
            workOnText.Opacity = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOnText", workOnText.Opacity = 1);
            workOffText.Opacity = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkOffText", workOffText.Opacity = 0.2);
            Console.WriteLine(Preferences.Get("HashAccount", ""));
            username.Text = Preferences.Get("UserName", "");
            worktimetitle.Text = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkTimeTitle", "");
            worktime.Text = Preferences.Get(Preferences.Get("HashAccount", "") + "WorkTime", "");
        }
        protected override void OnDisappearing()
        {
            if (geoLocation.cts != null && !geoLocation.cts.IsCancellationRequested)
                geoLocation.cts.Cancel();
            base.OnDisappearing();
        }

        private async void GoToWork(object sender, EventArgs e)
        {
            workOn.BackgroundColor = Color.White;
            try
            {
                if (allowTap)
                {
                    
                    allowTap = false;
                    if (await Work.GetWorkType() == 2 || await Work.GetWorkType() == 0)
                    {
                        (double x, double y) = await geoLocation.GetLocation("WorkOn");
                        if (await geoLocation.GetCurrentLocation(x, y) != true)
                        {
                            if (DeviceInfo.Platform == DevicePlatform.Android)
                            {
                                await DisplayAlert("????????????", "??????????????????????????????????????????\n(??????->??????????????????->??????)", "??????");
                            }
                            else
                            {
                                await DisplayAlert("????????????", "??????????????????????????????????????????\n(??????->??????->??????)", "??????");
                            }
                            //if (!await DisplayAlert("", "?????????????????????????\n(????????????:" + Preferences.Get("CompanyAddress", "") + ")", "??????", "??????"))
                            //    {
                            //        return;
                            //    }
                            return;
                        }
                        if (await Work.PostWork(1, x, y, true))
                        {
                            await DisplayAlert("", "??????????????????", "??????");
                            WorkOnSet();
                        }
                        else
                        {
                            await DisplayAlert("", "????????????", "??????");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("", "????????????", "??????");
                    }
                    else
                    {
                        await DisplayAlert("", "?????????", "??????");
                    }
                }
            }
            catch (Exception)
            {
                
                await DisplayAlert("", "????????????", "??????");
            }
            finally
            {
                
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    workOn.BackgroundColor = Color.White;
                    allowTap = true;
                    return false;
                });
            }
        }
        private async void OffWork(object sender, EventArgs e)
        {
            workOff.BackgroundColor = Color.White;
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (await Work.GetWorkType() == 1)
                    {
                        (double x, double y) = await geoLocation.GetLocation("WorkOff");
                        if (await geoLocation.GetCurrentLocation(x, y) != true)
                        {
                            if (DeviceInfo.Platform == DevicePlatform.Android)
                            {
                                await DisplayAlert("????????????", "??????????????????????????????????????????\n(??????->??????????????????->??????)", "??????");
                            }
                            else
                            {
                                await DisplayAlert("????????????", "??????????????????????????????????????????\n(??????->??????->??????)", "??????");
                            }
                            //if (!await DisplayAlert("", "?????????????????????????\n(????????????:" + Preferences.Get("CompanyAddress", "") + ")", "??????", "??????"))
                            //{
                            //    return;
                            //}
                            return;
                        }
                        if (await Work.PostWork(2, x, y, true))
                        {
                            await DisplayAlert("", "??????????????????", "??????");
                            WorkOffSet();
                        }
                        else
                        {
                            await DisplayAlert("", "????????????", "??????");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("", "????????????", "??????");
                    }
                    else
                    {

                        await DisplayAlert("", "?????????", "??????");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "????????????", "??????");
            }
            finally
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    workOff.BackgroundColor = Color.White;
                    allowTap = true;
                    return false;
                });
            }
        }

        public void WorkOffSet()
        {
            //Preferences.Set("statusNow", status.Text = "?????????");
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffButtonStauts", workOff.IsEnabled = false);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnButtonStauts", workOn.IsEnabled = true);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnButtonView", workOn.Opacity = 1);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffButtonView", workOff.Opacity = 0.2);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnText", workOnText.Opacity = 1);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffText", workOffText.Opacity = 0.2);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkTimeTitle", worktimetitle.Text = "???????????? at ");
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkTime", worktime.Text = DateTime.Now.ToString("t"));
            //Preferences.Set("statusBack", "#CB2E2E");
            //statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
        }
        public void WorkOnSet()
        {
            //Preferences.Set("statusNow", status.Text = "?????????");
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnButtonStauts", workOn.IsEnabled = false);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffButtonStauts", workOff.IsEnabled = true);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnButtonView", workOn.Opacity = 0.2);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffButtonView", workOff.Opacity = 0.8);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOnText", workOnText.Opacity = 0.2);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkOffText", workOffText.Opacity = 0.8);
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkTimeTitle", worktimetitle.Text = "???????????? at ");
            Preferences.Set(Preferences.Get("HashAccount", "") + "WorkTime", worktime.Text = DateTime.Now.ToString("t"));
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
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    allowTap = true;
                    return false;
                });
            }
        }
        private async void GoOutButton(object sender, EventArgs e)
        {
            GoOut.BackgroundColor = Color.White;
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await PopupNavigation.Instance.PushAsync(new AdvanceGoOut("?????????"));
                    // await Navigation.PushAsync(new GoOut());
                }
            }
            finally
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    workOff.BackgroundColor = Color.White;
                    allowTap = true;
                    return false;
                });
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
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    allowTap = true;
                    return false;
                });
            }
        }
        private async void DayOffButton(object sender, EventArgs e)
        {
            DayOff.BackgroundColor = Color.White;
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
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    
                    allowTap = true;
                    return false;
                });
            }
        }

        private async void GpsButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (GPSText.Text == "???????????????")
                        DependencyService.Get<IAppSettingsHelper>().OpenAppSetting();
                    else
                    {
                        //var supportsUri = await Launcher.CanOpenAsync("");
                        //if (supportsUri)
                        //{
                        //    Console.WriteLine("true");
                        //    await Launcher.OpenAsync("");
                        //}                                
                        await PopupNavigation.Instance.PushAsync(new MapPage());
                    }
                }
            }
            finally
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    allowTap = true;
                    return false;
                });
            }
        }
        void OnGoToWorkButtonPressed(object sender, EventArgs args)
        {
            workOn.BackgroundColor = Color.FromHex("#E0E0E0");
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                workOn.BackgroundColor = Color.White;
                return true;
            });

        }
        void OnOffWorkButtonPressed(object sender, EventArgs args)
        {
            workOff.BackgroundColor = Color.FromHex("#E0E0E0");
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                workOff.BackgroundColor = Color.White;
                return true;
            });

        }
        void OnGoOutButtonPressed(object sender, EventArgs args)
        {
            GoOut.BackgroundColor = Color.FromHex("#E0E0E0");
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                GoOut.BackgroundColor = Color.White;
                return true;
            });

        }
        void OnDayOffButtonPressed(object sender, EventArgs args)
        {
            DayOff.BackgroundColor = Color.FromHex("#E0E0E0");
            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                DayOff.BackgroundColor = Color.White;
                return true;
            });

        }
        
    }
}

