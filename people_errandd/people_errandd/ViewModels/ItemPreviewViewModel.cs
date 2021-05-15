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

        readonly IList<Category> source2;
        readonly IList<DeliverySteps> source;
        public ObservableCollection<Category> categories { get; private set; }
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
           
            source2 = new List<Category>();
           
            CreateCategoriesCollection();

            source = new List<DeliverySteps>();
            CreateCollection();

        }

        void CreateCollection()
        {

            Xamarin.Forms.Color frColor = Xamarin.Forms.Color.FromHex("#CADBE9");
            Xamarin.Forms.Color linColor = Xamarin.Forms.Color.FromHex("#CADBE9");

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
                        frColor = Xamarin.Forms.Color.FromHex("#CADBE9");
                        linColor = Xamarin.Forms.Color.FromHex("#CADBE9");
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


        void CreateCategoriesCollection()
        {
            source2.Add(new Category
            {
                image = "mon.png",
                title = "04/05",
                link = "5693 Products"
            });
            source2.Add(new Category
            {
                image = "tue.png",
                title = "04/06",
                link = "1124 Products"
            });
            source2.Add(new Category
            {
                image = "wed.png",
                title = "04/07",
                link = "5693 Products"
            });

            source2.Add(new Category
            {
                image = "thu.png",
                title = "04/08",
                link = "5693 Products"
            });

            source2.Add(new Category
            {
                image = "fri.png",
                title = "04/09",
                link = "5693 Products"
            });
            source2.Add(new Category
            {
                image = "sat.png",
                title = "04/10",
                link = "5693 Products"
            });
            source2.Add(new Category
            {
                image = "sun.png",
                title = "04/11",
                link = "5693 Products"
            });

            categories = new ObservableCollection<Category>(source2);
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
