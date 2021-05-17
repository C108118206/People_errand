using System;
using Xamarin.Forms;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
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
            var _hashAccount = Preferences.Get("Login","1");
            HttpResponse._HashAccount = _hashAccount;
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = Geolocation.GetLocationAsync(request);

        }

        private async void GoToWork(object sender, EventArgs e)
        {

            try
            {
                geoLocation geoLocation = new geoLocation();
                if (await Work.GetWorkType() == 2 || await Work.GetWorkType() == 0)
                {
                    (double x, double y) = await geoLocation.GetLocation();
                    if (geoLocation.GetCurrentLocation(x, y) == true)
                    {
                        if (await Work.PostWork(1, x, y))
                        {
                            await DisplayAlert("", "上班打卡成功", "確定");
                        }
                        else
                        {
                            await DisplayAlert("Error", "發生錯誤"+HttpResponse._HashAccount, "確定");
                        }
                }                
                    else
                    {
                        await DisplayAlert("", "位置錯誤\n" + x + "\n" + y, "確定");
                    }
                }
                else if (await Work.GetWorkType() == 500)
                {
                    await DisplayAlert("Error", "錯誤", "確定");
                }
                else
                {
                    await DisplayAlert("Error", "已上班", "確定");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "錯誤", "");
                throw;
            }
        }

        private async void OffWork(object sender, EventArgs e)
        {

            try
            {
                geoLocation geoLocation = new geoLocation();
                if (await Work.GetWorkType() == 1 )
                {
                    (double x,double y) = await geoLocation.GetLocation();
                    if (geoLocation.GetCurrentLocation(x,y) == true)
                    {   if (await Work.PostWork(2, x, y))
                        {
                            await DisplayAlert("", "下班打卡成功", "確定");
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
                else if(await Work.GetWorkType() == 500)
                {
                    await DisplayAlert("Error", "錯誤", "確定");
                }
                else
                {
                    await DisplayAlert("Error", "已下班", "確定");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "錯誤", "");
                throw;
            }




        }

        private async void LogOutButton(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopToRootAsync();
            Preferences.Remove("Login");

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