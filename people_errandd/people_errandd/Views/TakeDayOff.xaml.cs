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
            await takeDayOff.PostDayOffRecord(startDatePicker.Date.ToString(), endDatePicker.Date.ToString(), typeId, reason.Text);
            await App.DataBase.SaveRecordAsync(new DayOffRecordModels
            {
                DayOffType = typeId.ToString(),
                StartTime = startDatePicker.Date,
                EndTime = endDatePicker.Date,
                reason = reason.Text
            }) ;
        }
    }
}