using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace people_errandd.ViewModels
{
    public class DateWeek : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        double number = 1;
        string backgroundcolor;
        string textcolor;
        public DateWeek()
        {
            SunButton = new Command(() => ColorChange *= 2);
            MonButton = new Command(() => ColorChange /= 2);
            TueButton = new Command(() => ColorChange /= 2);
            WedButton = new Command(() => ColorChange /= 2);
            ThuButton = new Command(() => ColorChange /= 2);
            FriButton = new Command(() => ColorChange /= 2);
            SatButton = new Command(() => ColorChange /= 2);
        }
        public double ColorChange
        {
            set
            {
               
            }
            get
            {
                return number;
            }
        }
        public ICommand SunButton { private set; get; }

        public ICommand MonButton { private set; get; }
        public ICommand TueButton { private set; get; }

        public ICommand WedButton { private set; get; }
        public ICommand ThuButton { private set; get; }

        public ICommand FriButton { private set; get; }
        public ICommand SatButton { private set; get; }

    }
}
