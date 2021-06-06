using people_errandd.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using System.Drawing;
using people_errandd.Models;

namespace people_errandd.ViewModels

{
    class ItemPreviewViewModel : INotifyPropertyChanged
    {


        readonly IList<DeliverySteps> source;

        public ObservableCollection<DeliverySteps> delList { get; private set; }

        int currentFlag = 3; //Starts from 0
        List<tempData> tempData = new List<tempData>() {
            new tempData
            {
                Name="TASK 1",
                Location="開會",
                dateMon="20/18",
                tim="上午 09:00"
            },
            new tempData
            {
                Name="TASK 2",
                Location="開會",
                dateMon="20/18",
                tim="上午 10:00"
            },
            new tempData
            {
                Name="TASK 3",
                Location="開會",
                dateMon="20/18",
                tim="上午 11:00"
            },
            new tempData
            {
                Name="TASK 4",
                Location="開會",
                dateMon="20/18",
                tim="下午 03:00"
            },
            new tempData
            {
                Name="TASK 5",
                Location="開會",
                dateMon="20/18",
                tim="下午 05:00"
            }
        };


        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }
        public ItemPreviewViewModel()
        {

            source = new List<DeliverySteps>();
            CreateCollection();

        }

        void CreateCollection()
        {

            Xamarin.Forms.Color frColor = Xamarin.Forms.Color.FromHex("#6184C6");
            Xamarin.Forms.Color linColor = Xamarin.Forms.Color.FromHex("#6184C6");
            Xamarin.Forms.Color TaskColor = Xamarin.Forms.Color.FromHex("#6184C6");
            Xamarin.Forms.Color textcolorNM = Xamarin.Forms.Color.FromHex("#000000");
            Xamarin.Forms.Color textcolorLo = Xamarin.Forms.Color.FromHex("#353866");

            for (int i = 0; i < tempData.Count; i++)
            {
                if (i == (tempData.Count - 1))
                {
                    linColor = Xamarin.Forms.Color.Transparent;
                }
                else
                {
                    if (i < currentFlag)
                    {
                        frColor = Xamarin.Forms.Color.FromHex("#6184C6");
                        linColor = Xamarin.Forms.Color.FromHex("#6184C6");
                        textcolorNM = Xamarin.Forms.Color.FromHex("#FFFFFF");
                        textcolorLo = Xamarin.Forms.Color.FromHex("#FFFFFF");
                    }
                    else
                    {
                        frColor = Xamarin.Forms.Color.Transparent;
                        TaskColor = Xamarin.Forms.Color.FromHex("#E6E6E6");
                        linColor = Xamarin.Forms.Color.FromHex("#DDDDDD");
                        textcolorNM = Xamarin.Forms.Color.FromHex("#000000");
                        textcolorLo = Xamarin.Forms.Color.FromHex("#353866");
                    }
                }
                source.Add(new DeliverySteps
                {
                    Name = tempData[i].Name,
                    Location = tempData[i].Location,
                    dateMon = tempData[i].dateMon,
                    tim = tempData[i].tim,
                    colorTask = TaskColor,
                    colorFrame = frColor,
                    textcolorName = textcolorNM,
                    textcolorLocation = textcolorLo,
                    colorLine = linColor
                });

            }
            delList = new ObservableCollection<DeliverySteps>(source);
        }






        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    public class tempData
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string dateMon { get; set; }
        public string tim { get; set; }
    }



}
