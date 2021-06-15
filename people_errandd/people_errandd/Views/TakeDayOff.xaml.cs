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
            //var dayoffList = new List<string>();
            //dayoffList.Add("事假");
            //dayoffList.Add("病假");
            //dayoffList.Add("喪假");
            //dayoffList.Add("產假");
            //dayoffList.Add("生理假");
            //dayoffList.Add("流產假");
            //dayoffList.Add("產前假");
            //dayoffList.Add("陪產假");

            //var picker = new Picker { Title = "請選擇:", TitleColor = Color.FromHex("#696969") };
            //leaveType.ItemsSource = dayoffList;
            startTimePicker.IsVisible =true? !AlldaySwitch.IsToggled : AlldaySwitch.IsToggled;
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
                        Date = DateTime.Now.ToString()
                    }) ;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "格式錯誤", "OK");               
            }
            finally
            {
                allowTap = true;
            }

        }

        private void AlldaySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (AlldaySwitch.IsToggled == true)
            {
                startTimePicker.IsVisible = false;
                endTimePicker.IsVisible = false;
            }
            else
            {
                startTimePicker.IsVisible = true;
                endTimePicker.IsVisible = true;              
            }
        }
    }

}