using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Timers;

namespace people_errandd.ViewModels
{
    public class TimeDisplay : INotifyPropertyChanged
    {
       
        public TimeDisplay()
        {
            
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
             {
                
                 this.DateTime = DateTime.Now;
                 return true;
             });
           


                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        DateTime dateTime;
        public DateTime DateTime 
        {
            get
            {
                return dateTime;
            }
            set
            {
                if(dateTime != value)
                {
                    dateTime = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
             }

       




    }
}
