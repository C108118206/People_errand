using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace people_errandd.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DateTime dateTime;
        string LocationNowText;        

        public MainPageViewModel()
        {
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                LocationText = geoLocation.LocationNowText;
                DateTime = DateTime.Now;
                return true;
            });            
            Console.WriteLine(LocationText);           
        }        
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;                   
                        OnPropertyChanged();                 
                }
            }
        }
        public string LocationText
        {
            private set
            {
                if(LocationNowText != value)
                {
                    LocationNowText = value;


                    OnPropertyChanged();
                }

            }
            get
            {
                return LocationNowText;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
