﻿using System;
using Xamarin.Forms;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class MainPage : ContentPage
    {
        private readonly Work Work = new Work();
        bool allowTap = true;
        private readonly geoLocation geoLocation = new geoLocation();
        //public string ItemId
        //{
        //    set
        //    {
        //        LoadNote(value);
        //    }
        //}
        //async void LoadNote(string itemId)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(itemId);
        //        item item = await App.DataBase.GetNoteAsync(id);
        //        BindingContext = item;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Failed to load item");
        //    }
        //}

        public MainPage()
        {
            InitializeComponent();
            //隱藏navigationpage導航欄
            NavigationPage.SetHasNavigationBar(this, false);
            //BindingContext = new item();
            //var companyitem = new company();
            //username.BindingContext = companyitem;
            //username.SetBinding(Label.TextProperty, "Name");
            var _hashAccount = Preferences.Get("Login","");
            HttpResponse._HashAccount = _hashAccount;
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = Geolocation.GetLocationAsync(request);
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            status.Text = Preferences.Get("statusNow", "");
            Preferences.Get("WorkOnButtonStatus", workOn.IsEnabled = true);
            Preferences.Get("WorkOffButtonStatus", workOff.IsEnabled = false);
        }

        private async void GoToWork(object sender, EventArgs e)
        {

            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    
                    //if (await Work.GetWorkType() == 2 || await Work.GetWorkType() == 0)
                    //{
                        (double x, double y) = await geoLocation.GetLocation();
                        if (geoLocation.GetCurrentLocation(x, y) == true)
                        {
                            //if (await Work.PostWork(1, x, y))
                            //{
                                await DisplayAlert("", "上班打卡成功", "確定");
                                await App.DataBase.SaveRecordAsync(new RecordModels
                                {
                                    status = "上班",
                                    time = DateTime.Now.ToString()
                                });
                                Preferences.Set("statusNow", "上班中");
                                status.Text = Preferences.Get("statusNow", "");
                                Preferences.Set("WorkOnButtonStauts", workOn.IsEnabled = false);
                                Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = true);
                                base.OnAppearing();
                            //}
                            //else
                            //{
                            //    await DisplayAlert("Error", "發生錯誤" + HttpResponse._HashAccount, "確定");
                            //}
                        }
                        else
                        {
                            await DisplayAlert("", "位置錯誤\n" + x + "\n" + y, "確定");
                        }
                    //}
                    //else if (await Work.GetWorkType() == 500)
                    //{
                    //    await DisplayAlert("Error", "錯誤" + HttpResponse._HashAccount, "確定");
                    //}
                    //else
                    //{
                    //    await DisplayAlert("Error", "已上班", "確定");
                    //}
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
                            if (await Work.PostWork(2, x, y))
                            {
                                await App.DataBase.SaveRecordAsync(new RecordModels
                                {
                                    status = "下班",
                                    time = DateTime.Now.ToString()
                                });
                                await DisplayAlert("", "下班打卡成功", "確定");
                                Preferences.Set("statusNow", "已下班");
                                status.Text = Preferences.Get("statusNow", "");
                                Preferences.Set("WorkOffButtonStauts", workOff.IsEnabled = false);
                                Preferences.Set("WorkOnButtonStauts", workOff.IsEnabled = true);
                                OnAppearing();
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

        //private async void LogOutButton(object sender, EventArgs e)
        //{
        //    Navigation.InsertPageBefore(new LoginPage(), this);
        //    await Navigation.PopToRootAsync();
        //    Preferences.Remove("Login");
        //}
     
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
                allowTap = false;
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
                allowTap = false;
            }
        }
        private async void GoOutButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = true;
                    await Navigation.PushAsync(new GoOut());
                }
            }
            finally
            {
                allowTap = true;
            }
        }

    }
}