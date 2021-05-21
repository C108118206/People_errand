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
                tim="09:00 AM"
            },
            new tempData
            {
                Name="TASK 2",
                Location="開會",
                dateMon="20/18",
                tim="10:00 AM"
            },
            new tempData
            {
                Name="TASK 3",
                Location="開會",
                dateMon="20/18",
                tim="11:00 AM"
            },
            new tempData
            {
                Name="TASK 4",
                Location="開會",
                dateMon="20/18",
                tim="15:00 AM"
            },
            new tempData
            {
                Name="TASK 5",
                Location="開會",
                dateMon="20/18",
                tim="17:00 AM"
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

            Xamarin.Forms.Color frColor = Xamarin.Forms.Color.FromHex("#67AEC6");
            Xamarin.Forms.Color linColor = Xamarin.Forms.Color.FromHex("#67AEC6");

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
                        frColor = Xamarin.Forms.Color.FromHex("#67AEC6");
                        linColor = Xamarin.Forms.Color.FromHex("#67AEC6");
                    }
                    else
                    {
                        frColor = Xamarin.Forms.Color.Transparent;
                        linColor = Xamarin.Forms.Color.FromHex("#DDDDDD");
                    }
                }
                source.Add(new DeliverySteps
                {
                    Name = tempData[i].Name,
                    Location = tempData[i].Location,
                    dateMon = tempData[i].dateMon,
                    tim = tempData[i].tim,
                    colorFrame = frColor,
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
