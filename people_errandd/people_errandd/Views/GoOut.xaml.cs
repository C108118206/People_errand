using System;
using people_errandd.Models;
using people_errandd.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoOut : ContentPage
    {
        GoOutViewModel goOut = new GoOutViewModel();
        private bool allowTap = true;
        public GoOut()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#B4D3EA");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
        }
        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
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

        private async void EnterButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    DateTime StartDateTime = startDatePicker.Date + startTimePicker.Time;
                    DateTime EndDateTime = endDatePicker.Date + endTimePicker.Time;
                    if (await goOut.PostGoOut(StartDateTime, EndDateTime, locationEntry.Text, reasonEntry.Text))
                    {
                        await DisplayAlert("", "申請成功", "OK");
                        await App.DataBase.SaveRecordAsync(new GoOutRecordModels
                        {
                            StartTime = StartDateTime,
                            EndTime = EndDateTime,
                            Location = locationEntry.Text,
                            Reason = reasonEntry.Text,
                            Date = DateTime.Now.ToString("d")
                        }) ;
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "錯誤" + StartDateTime, "OK");
                        allowTap = false;
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("", "格式錯誤,請重新輸入", "OK");
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