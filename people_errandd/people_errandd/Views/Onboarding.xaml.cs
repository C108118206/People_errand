using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Onboarding : ContentPage
    {
        public Onboarding()
        {
            InitializeComponent();
            MyEvents = GetEvents();
            this.BindingContext = this;
        }
        public ObservableCollection<Event> MyEvents { get; set; }
        private ObservableCollection<Event> GetEvents()
        {
            return new ObservableCollection<Event>
            {
                new Event { Title = "使用Punch打卡", Content = "簡單上班", Image="workerob"},
                new Event { Title = "使用Punch打卡", Content = "簡單下班", Image="workeroffob"},
                new Event { Title = "使用punch公出", Content = "快速外出", Image="goout2ob"},
                new Event { Title = "使用punch請假", Content = "輕鬆請假", Image="nerdob"}


            };
        }



        public class Event
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Image { get; set; }

        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
           // MyRadialGradient.RadiusX = width * 6;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await FadeBox.FadeTo(1, 1000);
            await Navigation.PopModalAsync(false);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //MyRadialGradient.RadiusX = this.Width * e.NewValue;
        }
    }
}