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
    public partial class MainpageeMDetail : ContentPage
    {
        public MainpageeMDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void GoBackButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void GoStaffManagementButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StaffManagement());
        }
        private async void InquireEmployeePunchButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InquireEmployeePunch());
        }
        private async void AuditGoOutButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuditGoOut());
        }
        private async void AuditDayoffButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuditDayOff());
        }
    }
}