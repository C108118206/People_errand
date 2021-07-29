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

namespace people_errandd.Views
{
    public partial class MainPage : TabbedPage
    {

        private readonly Work Work = new Work();
        bool allowTap = true;
        private readonly geoLocation geoLocation = new geoLocation();

        Page onboarding;
        public MainPage()
        {
            BindingContext = new TimeDisplay();
            InitializeComponent();

           //if (ShouldShowOnboarding() == true)
           // {
               // App.Current.ModalPopping += Current_ModalPopping;
              //  onboarding = new Onboarding();
              //  Navigation.PushModalAsync(onboarding, false);
          //  }
            //隱藏navigationpage導航欄
            DateTime thisDay = DateTime.Now;
            NavigationPage.SetHasNavigationBar(this, false);

      

            MyEvents = GetEvents();
            MyAnnouncements = GetAnnouncements();
            this.BindingContext = this;
            DateTime dt = DatePicker.Date;
            switch (dt.ToString("dddd"))
            {
                case "星期日":
                    sun.Text = dt.AddDays(0).ToString("dd");
                    mon.Text = dt.AddDays(1).ToString("dd");
                    tue.Text = dt.AddDays(2).ToString("dd");
                    wed.Text = dt.AddDays(3).ToString("dd");
                    thu.Text = dt.AddDays(4).ToString("dd");
                    fri.Text = dt.AddDays(5).ToString("dd");
                    sat.Text = dt.AddDays(6).ToString("dd");

                    sun.BackgroundColor = Color.FromHex("#5C76B1");
                    sun.TextColor = Color.FromHex("#FFFFFF");
                    break;
                case "星期一":
                    sun.Text = dt.AddDays(-1).ToString("dd");
                    mon.Text = dt.AddDays(0).ToString("dd");
                    tue.Text = dt.AddDays(1).ToString("dd");
                    wed.Text = dt.AddDays(2).ToString("dd");
                    thu.Text = dt.AddDays(3).ToString("dd");
                    fri.Text = dt.AddDays(4).ToString("dd");
                    sat.Text = dt.AddDays(5).ToString("dd");

                    mon.BackgroundColor = Color.FromHex("#5C76B1");
                    mon.TextColor = Color.FromHex("#FFFFFF");
                    break;
                case "星期二":
                    sun.Text = dt.AddDays(-2).ToString("dd");
                    mon.Text = dt.AddDays(-1).ToString("dd");
                    tue.Text = dt.AddDays(0).ToString("dd");
                    wed.Text = dt.AddDays(1).ToString("dd");
                    thu.Text = dt.AddDays(2).ToString("dd");
                    fri.Text = dt.AddDays(3).ToString("dd");
                    sat.Text = dt.AddDays(4).ToString("dd");

                    tue.BackgroundColor = Color.FromHex("#5C76B1");
                    tue.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期三":
                    sun.Text = dt.AddDays(-3).ToString("dd");
                    mon.Text = dt.AddDays(-2).ToString("dd");
                    tue.Text = dt.AddDays(-1).ToString("dd");
                    wed.Text = dt.AddDays(0).ToString("dd");
                    thu.Text = dt.AddDays(1).ToString("dd");
                    fri.Text = dt.AddDays(2).ToString("dd");
                    sat.Text = dt.AddDays(3).ToString("dd");

                    wed.BackgroundColor = Color.FromHex("#5C76B1");
                    wed.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期四":
                    sun.Text = dt.AddDays(-4).ToString("dd");
                    mon.Text = dt.AddDays(-3).ToString("dd");
                    tue.Text = dt.AddDays(-2).ToString("dd");
                    wed.Text = dt.AddDays(-1).ToString("dd");
                    thu.Text = dt.AddDays(0).ToString("dd");
                    fri.Text = dt.AddDays(1).ToString("dd");
                    sat.Text = dt.AddDays(2).ToString("dd");

                    thu.BackgroundColor = Color.FromHex("#5C76B1");
                    thu.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期五":
                    sun.Text = dt.AddDays(-5).ToString("dd");
                    mon.Text = dt.AddDays(-4).ToString("dd");
                    tue.Text = dt.AddDays(-3).ToString("dd");
                    wed.Text = dt.AddDays(-2).ToString("dd");
                    thu.Text = dt.AddDays(-1).ToString("dd");
                    fri.Text = dt.AddDays(0).ToString("dd");
                    sat.Text = dt.AddDays(1).ToString("dd");

                    fri.BackgroundColor = Color.FromHex("#5C76B1");
                    fri.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期六":
                    sun.Text = dt.AddDays(-6).ToString("dd");
                    mon.Text = dt.AddDays(-5).ToString("dd");
                    tue.Text = dt.AddDays(-4).ToString("dd");
                    wed.Text = dt.AddDays(-3).ToString("dd");
                    thu.Text = dt.AddDays(-2).ToString("dd");
                    fri.Text = dt.AddDays(-1).ToString("dd");
                    sat.Text = dt.AddDays(0).ToString("dd");

                    sat.BackgroundColor = Color.FromHex("#5C76B1");
                    sat.TextColor = Color.FromHex("#FFFFFF");

                    break;
            }
        }

       // private void Current_ModalPopping(object sender, ModalPoppingEventArgs e)
     //  {
         //   if (e.Modal == onboarding)
          //  {
             //   FadeBox.FadeTo(0, 1000);
             //   onboarding = null;
            //    App.Current.ModalPopping -= Current_ModalPopping;
          //  }
     //   }

       // private bool ShouldShowOnboarding()
       // {
         //   if (VersionTracking.IsFirstLaunchEver)
        //    {
         //       return true;
          //  }
          //  else
          //  {
          //     return false;
          //  }
      //  }

        public ObservableCollection<Event> MyEvents { get; set; }
        private ObservableCollection<Event> GetEvents()
        {
            return new ObservableCollection<Event>
            {
                new Event { Title = "", Image = "p1", Duration = "", Date = new DateTime(2021, 6, 6), Description = "更多消息"},
                new Event { Title = "", Image = "p1", Duration = "", Date = new DateTime(2021, 6, 7), Description = "更多消息"},
                new Event { Title = "John放假", Image = "p1", Duration = "07:30 am - 09:30 am", Date = new DateTime(2021, 6, 8), Description = "更多消息"},
                new Event { Title = "今天有會議", Image = "p1", Duration = "07:30 am - 09:30 am", Date = new DateTime(2021, 6, 9), Description = "更多消息"},
                new Event { Title = "Marry放假", Image = "p1", Duration = "07:30 am - 09:30 pm", Date = new DateTime(2021, 6, 10), Description = "更多消息"},
                new Event { Title = "", Image = "p1", Duration = "07:30 am - 09:30 pm", Date = new DateTime(2021, 6, 11), Description = "更多消息"},
                new Event { Title = "Amy放假", Image = "p1", Duration = "07:30 am - 09:30 pm", Date = new DateTime(2021, 6, 12), Description = "更多消息"}
            };
        }
        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DetailsView");

            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
                await CloseAnimation(imgView);
            }
        }
        public class Event
        {
            public string Title { get; set; }
            public string Venue { get; set; }
            public string Duration { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }

            public DateTime Date { get; set; }
        }
        public ObservableCollection<Announcement> MyAnnouncements { get; set; }
        private ObservableCollection<Announcement> GetAnnouncements()
        {
            return new ObservableCollection<Announcement>
            {
               
                new Announcement { TitleAnnouncement = "有新同事加入喔!", Publisher = "p1.png", PublisherName = "Marry", Date = "2021-07-25"},
                new Announcement { TitleAnnouncement = "員工旅遊消息", Publisher = "p1.png", PublisherName = "Marry", Date = "2021-07-25"},
                new Announcement { TitleAnnouncement = "聚餐消息", Publisher = "p1.png",  PublisherName = "Marry", Date = "2021-07-25"}
            };
        }




        private async void OnTapped(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new AnnouncementDetail());
                }
            }
            finally
            {
                allowTap = true;
            }

        }
        public class Announcement
        {
            public string TitleAnnouncement { get; set; }
            public string Publisher { get; set; }
            public string PublisherName { get; set; }
            public string Date { get; set; }

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            GPSText.Text = Preferences.Get("gpsText", "定位未開啟");
            //Preferences.Set("statusBack", "#EDEEEF");
            //statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
            //status.Text = Preferences.Get("statusNow", "無狀態");
            workOn.IsEnabled = Preferences.Get("WorkOnButtonStauts", workOn.IsEnabled = true);
            workOff.IsEnabled = Preferences.Get("WorkOffButtonStauts", workOff.IsEnabled = false);
            workOn.Opacity = Preferences.Get("WorkOnButtonView", workOn.Opacity = 1);
            workOff.Opacity = Preferences.Get("WorkOffButtonView", workOff.Opacity = 0.2);
            workOnText.Opacity = Preferences.Get("WorkOnText", workOnText.Opacity = 1);
            workOffText.Opacity = Preferences.Get("WorkOffText", workOffText.Opacity = 0.2);
            username.Text = Preferences.Get("UserName","");
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            await geoLocation.GetLocation("Back");
        }
        protected override void OnDisappearing()
        {
            if (geoLocation.cts != null && !geoLocation.cts.IsCancellationRequested)
                geoLocation.cts.Cancel();
            base.OnDisappearing();
        }
        public void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
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
                        (double x, double y) = await geoLocation.GetLocation("WorkOn");
                        if (geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(1, x, y, true))
                            {
                                await DisplayAlert("", "上班打卡成功", "確定");
                                DateTime thisDay = DateTime.Now;
                                worktimetitle.Text = "上班打卡 at ";
                                worktime.Text = thisDay.ToString("t");
                                await App.DataBase.SaveRecordAsync(new WorkRecordModels
                                {
                                   
                                    status = "上班",
                                    statuscolor = "#5C76B1",
                                    time = DateTime.Now.ToString(),
                                    image = "worker.png"
                                }) ;
                                WorkOnSet();
                            }
                            else
                            {
                                await DisplayAlert("Error", "發生錯誤"  , "確定");
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤", "確定");
                        }
                    }
                    else if (await Work.GetWorkType() == 500)
                    {
                        await DisplayAlert("Error", "錯誤" , "確定");
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
                        (double x, double y) = await geoLocation.GetLocation("WorkOff");
                        if (geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            if (await Work.PostWork(2, x, y, true))
                            {
                                await DisplayAlert("", "下班打卡成功", "確定");
                                DateTime thisDay = DateTime.Now;
                                worktimetitle.Text = "下班打卡 at ";
                                worktime.Text = thisDay.ToString("t");
                                await App.DataBase.SaveRecordAsync(new WorkRecordModels
                                {
                                    status = "下班",
                                    statuscolor = "#CA4848",
                                    time = DateTime.Now.ToString(),
                                    image = "workeroff.png"
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

        public void WorkOffSet()
        {
            //Preferences.Set("statusNow", status.Text = "已下班");
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = false);
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 1);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 0.2);
            Preferences.Set("WorkOnText", workOnText.Opacity = 1);
            Preferences.Set("WorkOffText", workOffText.Opacity = 0.2);
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
            //Preferences.Set("statusBack", "#4AD395");
            //statusBack.BackgroundColor = Color.FromHex(Preferences.Get("statusBack", ""));
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
        private  void GpsButton(object sender, EventArgs e)
        {  
            if(GPSText.Text=="定位未開啟")
                DependencyService.Get<IAppSettingsHelper>().OpenAppSetting();          
        }
        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {


            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.TextColor = Color.FromHex("#555555");
            tue.TextColor = Color.FromHex("#555555");
            wed.TextColor = Color.FromHex("#555555");
            thu.TextColor = Color.FromHex("#555555");
            fri.TextColor = Color.FromHex("#555555");
            sat.TextColor = Color.FromHex("#555555");

            // DisplayAlert("", DatePicker.Date.ToString("yyyy-MM-dd-HH-mm-ss"), "fuck");
           
            DateTime dt = DatePicker.Date;
            switch (dt.ToString("dddd"))
            {
                case "星期日":
                    sun.Text = dt.AddDays(0).ToString("dd");
                    mon.Text = dt.AddDays(1).ToString("dd");
                    tue.Text = dt.AddDays(2).ToString("dd");
                    wed.Text = dt.AddDays(3).ToString("dd");
                    thu.Text = dt.AddDays(4).ToString("dd");
                    fri.Text = dt.AddDays(5).ToString("dd");
                    sat.Text = dt.AddDays(6).ToString("dd");

                    sun.BackgroundColor = Color.FromHex("#5C76B1");
                    sun.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期一":
                    sun.Text = dt.AddDays(-1).ToString("dd");
                    mon.Text = dt.AddDays(0).ToString("dd");
                    tue.Text = dt.AddDays(1).ToString("dd");
                    wed.Text = dt.AddDays(2).ToString("dd");
                    thu.Text = dt.AddDays(3).ToString("dd");
                    fri.Text = dt.AddDays(4).ToString("dd");
                    sat.Text = dt.AddDays(5).ToString("dd");

                    mon.BackgroundColor = Color.FromHex("#5C76B1");
                    mon.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期二":
                    sun.Text = dt.AddDays(-2).ToString("dd");
                    mon.Text = dt.AddDays(-1).ToString("dd");
                    tue.Text = dt.AddDays(0).ToString("dd");
                    wed.Text = dt.AddDays(1).ToString("dd");
                    thu.Text = dt.AddDays(2).ToString("dd");
                    fri.Text = dt.AddDays(3).ToString("dd");
                    sat.Text = dt.AddDays(4).ToString("dd");


                    tue.BackgroundColor = Color.FromHex("#5C76B1");
                    tue.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期三":
                    sun.Text = dt.AddDays(-3).ToString("dd");
                    mon.Text = dt.AddDays(-2).ToString("dd");
                    tue.Text = dt.AddDays(-1).ToString("dd");
                    wed.Text = dt.AddDays(0).ToString("dd");
                    thu.Text = dt.AddDays(1).ToString("dd");
                    fri.Text = dt.AddDays(2).ToString("dd");
                    sat.Text = dt.AddDays(3).ToString("dd");

                    wed.BackgroundColor = Color.FromHex("#5C76B1");
                    wed.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期四":
                    sun.Text = dt.AddDays(-4).ToString("dd");
                    mon.Text = dt.AddDays(-3).ToString("dd");
                    tue.Text = dt.AddDays(-2).ToString("dd");
                    wed.Text = dt.AddDays(-1).ToString("dd");
                    thu.Text = dt.AddDays(0).ToString("dd");
                    fri.Text = dt.AddDays(1).ToString("dd");
                    sat.Text = dt.AddDays(2).ToString("dd");

                    thu.BackgroundColor = Color.FromHex("#5C76B1");
                    thu.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期五":
                    sun.Text = dt.AddDays(-5).ToString("dd");
                    mon.Text = dt.AddDays(-4).ToString("dd");
                    tue.Text = dt.AddDays(-3).ToString("dd");
                    wed.Text = dt.AddDays(-2).ToString("dd");
                    thu.Text = dt.AddDays(-1).ToString("dd");
                    fri.Text = dt.AddDays(0).ToString("dd");
                    sat.Text = dt.AddDays(1).ToString("dd");

                    fri.BackgroundColor = Color.FromHex("#5C76B1");
                    fri.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期六":
                    sun.Text = dt.AddDays(-6).ToString("dd");
                    mon.Text = dt.AddDays(-5).ToString("dd");
                    tue.Text = dt.AddDays(-4).ToString("dd");
                    wed.Text = dt.AddDays(-3).ToString("dd");
                    thu.Text = dt.AddDays(-2).ToString("dd");
                    fri.Text = dt.AddDays(-1).ToString("dd");
                    sat.Text = dt.AddDays(0).ToString("dd");


                    sat.BackgroundColor = Color.FromHex("#5C76B1");
                    sat.TextColor = Color.FromHex("#FFFFFF");

                    break;
            }
        }
        private void SunButton(object sender, EventArgs e)
        {
            sun.BackgroundColor = Color.FromHex("#5C76B1");
            sun.TextColor = Color.FromHex("#FFFFFF");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");



        }
        private void MonButton(object sender, EventArgs e)
        {
            mon.BackgroundColor = Color.FromHex("#5C76B1");
            mon.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");

        }
        private void TueButton(object sender, EventArgs e)
        {
            tue.BackgroundColor = Color.FromHex("#5C76B1");
            tue.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");

        }
        private void WedButton(object sender, EventArgs e)
        {
            wed.BackgroundColor = Color.FromHex("#5C76B1");
            wed.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");

        }
        private void ThuButton(object sender, EventArgs e)
        {
            thu.BackgroundColor = Color.FromHex("#5C76B1");
            thu.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void FriButton(object sender, EventArgs e)
        {
            fri.BackgroundColor = Color.FromHex("#5C76B1");
            fri.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void SatButton(object sender, EventArgs e)
        {
            sat.BackgroundColor = Color.FromHex("#5C76B1");
            sat.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#000000");

        }

    }


}

﻿