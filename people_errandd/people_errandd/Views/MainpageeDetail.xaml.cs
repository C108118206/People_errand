using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainpageeDetail : ContentPage
    {
        public MainpageeDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            await transition.TranslateTo(0, -740, 500, Easing.CubicIn);

        }
        private async void GoToWork(object sender, EventArgs e)
        {
            await DisplayAlert("", "上班打卡成功 ! ", "確定");
        }
        private async void OffWork(object sender, EventArgs e)
        {
            await DisplayAlert("", "下班打卡成功 ! ", "確定");
        }
        private async void GoBackButton(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }

        private async void GoRecordButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Record());
        }
        private async void GoOutButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoOut());
        }
        private async void GoTakeDayOffButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TakeDayOff());
        }
        private async void GoClassScheduleButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassSchedule());
        }


    }
}