using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.ViewModels;
using people_errandd.Models;
using System.Collections.Generic;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeDayOff : ContentPage
    {
        private bool allowTap = true;
        private static int typeId;
        readonly TakeDayOffViewModel takeDayOff = new TakeDayOffViewModel();
        public TakeDayOff()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#B4D3EA");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;       
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    Navigation.PopAsync();
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        private async void EnterButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
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
                    DateTime StartDateTime = startDatePicker.Date + startTimePicker.Time;
                    DateTime EndDateTime = endDatePicker.Date + endTimePicker.Time;
                    if (await takeDayOff.PostDayOffRecord(StartDateTime, EndDateTime, typeId, reason.Text))
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
                        StartTime = StartDateTime,
                        EndTime = EndDateTime,
                        Reason = reason.Text,
                    });
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "格式錯誤", "OK");
                throw;
            }
            finally
            {
                allowTap = true;
            }
        }
    }
}