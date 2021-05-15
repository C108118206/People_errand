using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Essentials;
using System.Threading;

namespace people_errandd.Views
{
    //[QueryProperty(nameof(ItemId),nameof(ItemId))]
    public partial class MainPage : ContentPage
    {
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
        //    catch(Exception)
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
            // var companyitem = new company();
            // username.BindingContext = companyitem;
            // username.SetBinding(Label.TextProperty, "Name");


        }

        private async void GoToWork(object sender, EventArgs e)
        {

            //work item = new work();
            ////item = await App.DataBase.GetNoteAsync();

            //try
            //{
            //    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            //    var location = await Geolocation.GetLocationAsync(request);

            //    geoLocation geoLocation = new geoLocation();
            //    if (await HttpResponse.workGet() == 2)
            //    {
            //        if (await geoLocation.GetCurrentLocation() == true)
            //        {await HttpResponse.workPost(1);
            //            await DisplayAlert("", "上班打卡成功", "確定");
            //        }
            //        else
            //        {
            //            await DisplayAlert("", "位置錯誤 "+location.Latitude.ToString()+" "+location.Longitude.ToString(), "確定");

            //        }
            //    }
            //    else
            //    {
            //        await DisplayAlert("error", "已上班", "確定");
            //    }
            //}
            //catch (Exception)
            //{
            //    await DisplayAlert("", "錯誤", "");
            //    throw;
            //}





        }

        private async void OffWork(object sender, EventArgs e)
        {

            //try
            //{
            //    geoLocation geoLocation = new geoLocation();
            //    if (await HttpResponse.workGet() == 1)
            //    {
            //        if (await geoLocation.GetCurrentLocation() == true)
            //        {//await HttpResponse.workPost(2);
            //            await DisplayAlert("", "下班打卡成功", "確定");
            //        }
            //        else
            //        {
            //            await DisplayAlert("", "位置錯誤", "確定");
            //        }
            //    }
            //    else
            //    {
            //        await DisplayAlert("error", "已下班", "確定");
            //    }
            //}
            //catch (Exception)
            //{
            //    await DisplayAlert("", "錯誤", "");
            //    throw;
            //}




        }

            private async void LogOutButton(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopToRootAsync();

        }
        private async void AboutPageButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
        private async void DetailButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainpageeDetail());
        }
        private async void GoOutButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoOut());

        }
      
    }
}
