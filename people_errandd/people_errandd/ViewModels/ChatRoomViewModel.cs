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
    class ChatRoomViewModel : INotifyPropertyChanged
    {


        readonly IList<ChatRoomModels> source;

        public ObservableCollection<ChatRoomModels> delList { get; private set; }

        List<Data> tempData = new List<Data>() {
            new Data
            {
                Name="John",
                Photo="p1.png",
                Content="今天吃什麼?",
                Time="上午 11:00",
                Date = "今天"
            }
        };


        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }
        public ChatRoomViewModel()
        {

            source = new List<ChatRoomModels>();
            CreateCollection();

        }

        void CreateCollection()
        {
            for (int i = 0; i < tempData.Count; i++)
            {

                source.Add(new ChatRoomModels
                {
                    Name = tempData[i].Name,
                    Photo = tempData[i].Photo,
                    Content = tempData[i].Content,
                    Time = tempData[i].Time,
                    Date = tempData[i].Date
                });

            }
            delList = new ObservableCollection<ChatRoomModels>(source);
        }






        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    public class Data
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }



}
