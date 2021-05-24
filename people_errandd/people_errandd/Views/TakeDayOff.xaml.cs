using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeDayOff : ContentPage
    {

        public TakeDayOff()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Xamarin.Forms.Color.FromHex("#D9E1E8");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Xamarin.Forms.Color.Black;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
            
        }

    }
   
   
}