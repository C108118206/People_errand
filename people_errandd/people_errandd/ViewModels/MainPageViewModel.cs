using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using people_errandd.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace people_errandd.ViewModels
{
    class MainPageViewModel : HttpResponse,INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DateTime dateTime;
        string LocationNowText,_GpsText,_GpsTextColor;
        public bool AuditExist { get; set; }
        List<Audit> audits;
        public MainPageViewModel()
        {
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                LocationText = geoLocation.LocationNowText;
                DateTime = DateTime.Now;
                GpsText = Preferences.Get("GpsText", "");
                GpsTextColor = Preferences.Get("GpsButtonColor", "");
                return true;
            });                       
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
        public  string GpsText
        {
            get
            {
                return _GpsText;
            }
            set
            {
                if (_GpsText != value)
                {
                    _GpsText = value;
                    OnPropertyChanged();
                }
            }
        }
            public string GpsTextColor
        {
            get
            {
                return _GpsTextColor;
            }
            set
            {
                if (_GpsTextColor != value)
                {
                    _GpsTextColor = value;
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
        public List<Audit> Audits
        {
            get
            {
                return audits;
            }
            private set
            {
                if(audits != value)
                {
                    audits = value;
                    OnPropertyChanged();
                }
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
        public async Task GetAudit()
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameInformation +Preferences.Get("HashAccount",""));
                var result = await response.Content.ReadAsStringAsync();
                Audits = JsonConvert.DeserializeObject<List<Audit>>(result);
                AuditExist = true;
            }
            catch (Exception)
            {
                AuditExist = false;
            }
        }
    }
}
