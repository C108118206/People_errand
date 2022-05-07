using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using people_errandd.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AdvanceGoOut : Rg.Plugins.Popup.Pages.PopupPage
    {

        public AdvanceGoOut(string _Title)
        {

            InitializeComponent();
            PageTitle.Text = _Title;
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Arrival.IsVisible = await GoOutViewModel.ConfirmArrival();
        }
        private void StartTripTapped(object sender, EventArgs e)
        {

            Start.BackgroundColor = Color.FromHex("#FDF1DD");
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Start.BackgroundColor = Color.FromHex("#FCE7C3");
                return true;
            });
        }

        private void ArrivalTapped(object sender, EventArgs e)
        {
            Arrival.BackgroundColor = Color.FromHex("#F8CACB");
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Arrival.BackgroundColor = Color.FromHex("#F5B3B3");
                return true;
            });
        }
        private void BackTapped(object sender, EventArgs e)
        {

            Back.BackgroundColor = Color.FromHex("#D4DFF8");
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Back.BackgroundColor = Color.FromHex("#C2D2F6");
                return true;
            });
        }

    }
}