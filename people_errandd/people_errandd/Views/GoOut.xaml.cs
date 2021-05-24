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
    public partial class GoOut : ContentPage
    {
        public GoOut()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Xamarin.Forms.Color.FromHex("#D9E1E8");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Xamarin.Forms.Color.Black;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        public class DateTimePicker2 : ContentView, INotifyPropertyChanged
        {
            public Entry _entry { get; private set; } = new Entry();
            public DatePicker _datePicker { get; private set; } = new DatePicker() { IsVisible = false };
            public TimePicker _timePicker { get; private set; } = new TimePicker() { IsVisible = false };
            string _stringFormat { get; set; }
            public string StringFormat { get { return _stringFormat ?? "yyyy-MM-dd (dddd)   tt hh:mm"; } set { _stringFormat = value; } }
            public DateTime DateTime
            {
                get { return (DateTime)GetValue(DateTimeProperty); }
                set { SetValue(DateTimeProperty, value); OnPropertyChanged("DateTime"); }
            }

            private TimeSpan _time
            {
                get
                {
                    return TimeSpan.FromTicks(DateTime.Ticks);
                }
                set
                {
                    DateTime = new DateTime(DateTime.Date.Ticks).AddTicks(value.Ticks);
                }
            }

            private DateTime _date
            {
                get
                {
                    return DateTime.Date;
                }
                set
                {
                    DateTime = new DateTime(DateTime.TimeOfDay.Ticks).AddTicks(value.Ticks);
                }
            }

            BindableProperty DateTimeProperty = BindableProperty.Create("DateTime", typeof(DateTime), typeof(DateTimePicker2), DateTime.Now, BindingMode.TwoWay, propertyChanged: DTPropertyChanged);

            public DateTimePicker2()
            {
                BindingContext = this;

                Content = new StackLayout()
                {
                    Children =
            {
                _datePicker,
                _timePicker,
                _entry
            }
                };

                _datePicker.SetBinding<DateTimePicker2>(DatePicker.DateProperty, p => p._date);
                _timePicker.SetBinding<DateTimePicker2>(TimePicker.TimeProperty, p => p._time);
                _timePicker.Unfocused += (sender, args) => _time = _timePicker.Time;
                _datePicker.Focused += (s, a) => UpdateEntryText();

                GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() => _datePicker.Focus())
                });
                _entry.Focused += (sender, args) =>
                {
                    Device.BeginInvokeOnMainThread(() => _datePicker.Focus());
                };
                _datePicker.Unfocused += (sender, args) =>
                {

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _timePicker.Focus();
                        _date = _datePicker.Date;
                        UpdateEntryText();
                    });
                };
            }

            private void UpdateEntryText()
            {
                _entry.Text = DateTime.ToString(StringFormat);
                _entry.TextColor = Xamarin.Forms.Color.FromHex("#696969");
                _entry.WidthRequest = 280;
                _entry.HorizontalOptions = LayoutOptions.Center;
                _entry.FontAttributes = FontAttributes.Bold;

            }

            static void DTPropertyChanged(BindableObject bindable, object oldValue, object newValue)
            {
                var timePicker = (bindable as DateTimePicker2);
                timePicker.UpdateEntryText();
            }
        }

    }
}