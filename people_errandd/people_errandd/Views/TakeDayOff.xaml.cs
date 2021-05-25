using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.ViewModels;
using people_errandd.Models;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeDayOff : ContentPage
    {
        private static int typeId;
        TakeDayOffViewModel takeDayOff = new TakeDayOffViewModel();
        
        public TakeDayOff()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#D9E1E8");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;

        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
            
        }

        private async void EnterButton(object sender, EventArgs e)
        {
            try
            {
                switch (leaveType.SelectedItem.ToString())
            {
                case "事假":
                    typeId = 1;
                    break;
                case "病假":
                    typeId = 2;
                    break;
                case "喪假":
                    typeId = 3;
                    break;
                case "生理假":
                    typeId = 4;
                    break;
                case "流產假":
                    typeId = 5;
                    break;
                case "產前假":
                    typeId = 6;
                    break;
                case "陪產假":
                    typeId = 7;
                    break;
                default:
                    typeId = 0;
                    break;
            } 
           
            if(await takeDayOff.PostDayOffRecord(startDatePicker.Date, endDatePicker.Date, typeId, reason.Text))
            {
             await DisplayAlert("", "申請成功", "OK");
            }
            else
            {
                await DisplayAlert("Error", "錯誤", "OK");
            }
           
                await App.DataBase.SaveRecordAsync(new DayOffRecordModels
                {
                    DayOffType = leaveType.SelectedItem.ToString(),
                    StartTime = startDatePicker.Date,
                    EndTime = endDatePicker.Date,
                    Reason = reason.Text,

                });
            }
            catch (Exception)
            {
                await DisplayAlert("", "格式錯誤", "OK");
                throw;
            }
           
        }
    }
}