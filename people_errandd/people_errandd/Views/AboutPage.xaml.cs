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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#8CC5D7");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
        }
        void RefButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}