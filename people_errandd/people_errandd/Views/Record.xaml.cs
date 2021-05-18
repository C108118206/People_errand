using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Worklist.ItemsSource = await App.DataBase.GetRecordsAsync();
        }
        public Record()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#263959");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        async void choose(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("請選擇:", "Cancel", null, "上下班", "請假", "公出","全選");
            Debug.WriteLine("Action: " + action);
        }

    }
}