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
    public partial class MainPageeM : ContentPage
    {
        public MainPageeM()
        {
            InitializeComponent(); 
            NavigationPage.SetHasNavigationBar(this, false);
            //MainPage= new NavigationPage(new MainPage());
        }
        private async void LogOutButton(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopToRootAsync();

        }
            
        private async void DetailButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainpageeMDetail());
        }
        private async void InquireEmployeePunchButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InquireEmployeePunch());
        }
        private async void StaffManagementButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StaffManagement());
        }
    }
}