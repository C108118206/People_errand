using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassSchedule : ContentPage
    {
        public ClassSchedule()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#B4D3EA");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;

        }
        private async void LessDay(object sender, EventArgs e)
        {
            DateTime dateTime = SelectDate.Date;
            SelectDate.Date = dateTime.AddDays(-1);
        }
        private async void AddDay(object sender, EventArgs e)
        {
            DateTime dateTime = SelectDate.Date;
            SelectDate.Date = dateTime.AddDays(1);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        

    }
}