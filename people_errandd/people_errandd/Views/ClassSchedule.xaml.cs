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
        bool allowTap = true;
        public ClassSchedule()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;


        }
        private  void LessDay(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    DateTime dateTime = SelectDate.Date;
                    SelectDate.Date = dateTime.AddDays(-1);
                }
            }
            finally
            {
                allowTap = true;
            }
           
        }
        private  void AddDay(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    DateTime dateTime = SelectDate.Date;
                    SelectDate.Date = dateTime.AddDays(1);
                }
            }
            finally
            {
                allowTap = true;
            }
            
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    Navigation.PopAsync();
                }
            }
            finally
            {
                allowTap = true;
            }
           
        }
        

    }
}