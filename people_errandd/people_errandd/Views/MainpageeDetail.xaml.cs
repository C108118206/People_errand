using people_errandd.Models;
using people_errandd.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainpageeDetail : ContentPage
    {
        private readonly geoLocation geoLocation = new geoLocation();
        private readonly Work Work = new Work();
        private bool allowTap = true;
        public MainpageeDetail()
        {   
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await transition.TranslateTo(0, -750, 250, Easing.CubicIn);
            workOn.IsEnabled = Preferences.Get("WorkOnButtonStauts", workOn.IsEnabled = true);
            workOff.IsEnabled = Preferences.Get("WorkOffButtonStauts", workOff.IsEnabled = false);
            workOn.Opacity = Preferences.Get("WorkOnButtonView", workOn.Opacity = 1);
            workOff.Opacity = Preferences.Get("WorkOffButtonView", workOff.Opacity = 0.2);
            workOnText.Opacity = Preferences.Get("WorkOnText", workOnText.Opacity = 1);
            workOffText.Opacity = Preferences.Get("WorkOffText", workOffText.Opacity = 0.2);
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
                                await App.DataBase.SaveRecordAsync(new WorkRecordModels
                                {
                                    status = "上班",
                                    time = DateTime.Now.ToString()
                                });
                                WorkOnSet();
                            }
                            else
                            {
                                await DisplayAlert("Error", "發生錯誤" , "確定");
                            }
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤\n" + x + "\n" + y, "確定");
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
        private async void GoBackButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PopAsync();
                }
            }
            finally
            {
                allowTap = true;
            }


        }

        private async void GoRecordButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new Record());
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
        private async void GoTakeDayOffButton(object sender, EventArgs e)
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
        private async void GoClassScheduleButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await Navigation.PushAsync(new ClassSchedule());
                }
            }
            finally
            {
                allowTap = true;
            }

        }

        public void WorkOffSet()
        {
            Preferences.Set("statusNow", "已下班");
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = false);
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 1);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 0.2);
            Preferences.Set("WorkOnText", workOnText.Opacity = 1);
            Preferences.Set("WorkOffText", workOffText.Opacity = 0.2);
            Preferences.Set("statusBack", "F86954");
        }
        public void WorkOnSet()
        {
            Preferences.Set("statusNow", "上班中");
            Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = false);
            Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = true);
            Preferences.Set("WorkOnButtonView", workOn.Opacity = 0.2);
            Preferences.Set("WorkOffButtonView", workOff.Opacity = 1);
            Preferences.Set("WorkOnText", workOnText.Opacity = 0.2);
            Preferences.Set("WorkOffText", workOffText.Opacity = 1);
            Preferences.Set("statusBack", "98E4AA");
        }
    }
}