using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using people_errandd.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColleaguePage : ContentPage
    {
        public ColleaguePage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#8CC5D7");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;

        }
        private async void OnCollectionViewSelectionChanged(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChatRoom());
           
        }
    }
}