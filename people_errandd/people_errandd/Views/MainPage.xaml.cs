using System;
using Xamarin.Forms;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace people_errandd.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly Work Work = new Work();
        bool allowTap = true;
        private readonly geoLocation geoLocation = new geoLocation();

        public MainPage()
        {
            InitializeComponent();
            //隱藏navigationpage導航欄
            NavigationPage.SetHasNavigationBar(this, false);
            var _hashAccount = Preferences.Get("Login", "");
            HttpResponse._HashAccount = _hashAccount;
            GetLocation();
        }
        private async void GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);
            try
            {
                if (location == null)
                {
                    GPSText.Text = "定位未開啟";
                }
                else
                {
                    GPSText.Text = "定位已開啟";
                    switch (await Work.GetWorkType())
                    {
                        case 0:
                        case 1:
                            await Work.PostWork(1, location.Latitude, location.Longitude, false);
                            break;
                        case 2:
                            await Work.PostWork(2, location.Latitude, location.Longitude, false);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack",""));
            status.Text = Preferences.Get("statusNow", "");
            workOn.IsEnabled = Preferences.Get("WorkOnButtonStauts", workOn.IsEnabled = true);
            workOff.IsEnabled = Preferences.Get("WorkOffButtonStauts", workOff.IsEnabled = false);
            workOn.Opacity = Preferences.Get("WorkOnButtonView", workOn.Opacity = 1);
            workOff.Opacity = Preferences.Get("WorkOffButtonView", workOff.Opacity = 0.2);
            workOnText.Opacity = Preferences.Get("WorkOnText", workOnText.Opacity = 1);
            workOffText.Opacity = Preferences.Get("WorkOffText", workOffText.Opacity = 0.2);
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            await transition.TranslateTo(0, 15, 2000, Easing.BounceIn);
            await transition.TranslateTo(0, 0, 2000, Easing.BounceOut);

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                LabelConnection.FadeTo(0).ContinueWith((result) => { });
                FrameConnection.FadeTo(0).ContinueWith((result) => { });
            }
            else
            {
                LabelConnection.FadeTo(1).ContinueWith((result) => { });
                FrameConnection.FadeTo(0.845621).ContinueWith((result) => { });
            }
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
                        (double x, double y) = await geoLocation.GetLocation();
                        if (geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(1, x, y, true))
                            {
                                await DisplayAlert("", "上班打卡成功", "確定");
                                await App.DataBase.SaveRecordAsync(new WorkRecordModels
                                {
                                    status = "上班",
                                    time = DateTime.Now.ToString()
                                });
                                WorkOnSet();
                            }
                            else
                            {
                                await DisplayAlert("Error", "發生錯誤" + HttpResponse._HashAccount, "確定");
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤\n" + x + "\n" + y, "確定");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("Error", "錯誤" + HttpResponse._HashAccount, "確定");
                    }
                    else
                    {
                        await DisplayAlert("Error", "已上班", "確定");
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "錯誤", "");
                throw;
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
                        (double x, double y) = await geoLocation.GetLocation();
                        if (geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(2, x, y, true))
                            {
                                await DisplayAlert("", "下班打卡成功", "確定");
                                await App.DataBase.SaveRecordAsync(new WorkRecordModels
                                {
                                    status = "下班",
                                    time = DateTime.Now.ToString()
                                });
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
                await DisplayAlert("", "錯誤", "");
                throw;
            }
            finally
            {
                allowTap = true;
            }
        }

        private void WorkOffSet()
        {
            Preferences.Set("statusNow", "已下班");
            status.Text = Preferences.Get("statusNow", "");
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = false);
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 1);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 0.2);
            Preferences.Set("WorkOnText", workOnText.Opacity = 1);
            Preferences.Set("WorkOffText", workOffText.Opacity = 0.2);
            Preferences.Set("statusBack", "F86954");
            statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
            base.OnAppearing();
        }
        private void WorkOnSet()
        {

            Preferences.Set("statusNow", "上班中");
            status.Text = Preferences.Get("statusNow", "");
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = false);
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 0.2);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 1);
            Preferences.Set("WorkOnText", workOnText.Opacity = 0.2);
            Preferences.Set("WorkOffText", workOffText.Opacity = 1);
            Preferences.Set("statusBack", "98E4AA");
            statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
            base.OnAppearing();
        }
        private async void DetailButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new MainpageeDetail());
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
        private async void GoOutButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new GoOut());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void ColleagueButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new ColleaguePage());
                }
            }
            finally
            {
                allowTap = true;
            }
        }
    }
}