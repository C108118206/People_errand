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
    class ColleagueViewModel : INotifyPropertyChanged
    {


        readonly IList<Colleague> source;

        public ObservableCollection<Colleague> delList { get; private set; }

        List<temp> tempData = new List<temp>() {
            new temp
            {
                Name="John",
                Photo="p1.png",
                Content="今天吃什麼?",
                Time="上午 11:00"
            },
            new temp
            {
                Name="Marry",
                Photo="p2.png",
                Content="你在哪?",
                Time="上午 10:00"
            }
        };


        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }

        public ColleagueViewModel()
        {

            source = new List<Colleague>();
            CreateCollection();


        }

        void CreateCollection()
        {
            for (int i = 0; i < tempData.Count; i++)
            {
               
                source.Add(new Colleague
                {
                    Name = tempData[i].Name,
                    Photo = tempData[i].Photo,
                    Content = tempData[i].Content,
                    Time = tempData[i].Time,
                });

            }
            delList = new ObservableCollection<Colleague>(source);
        }






        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    public class temp
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
    }



}
