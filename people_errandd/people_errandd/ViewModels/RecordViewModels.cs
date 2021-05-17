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
    class RecordViewModels : INotifyPropertyChanged
    {

        readonly IList<RecordModels> source2;
        public ObservableCollection<RecordModels> worklist { get; private set; }
        readonly IList<RecordModels> source3;
        public ObservableCollection<RecordModels> gooutlist { get; private set; }
        readonly IList<RecordModels> source4;
        public ObservableCollection<RecordModels> dayofflist { get; private set; }
        public RecordViewModels()
        {

            source2 = new List<RecordModels>();
            CreatelistCollection();
            source3 = new List<RecordModels>();
            CreategooutlistCollection();
            source4 = new List<RecordModels>();
            CreatedayofflistCollection();
        }




        void CreatelistCollection()
        {
            source2.Add(new RecordModels
            {
                image = "worker.png",
                time = "09:10",
                status = "遲到",
                workorworkoff = "上班",
                color = "#BA4545"


            });
            source2.Add(new RecordModels
            {
                image = "workeroff.png",
                time = "17:05",
                status = "正常",
                workorworkoff = "下班",
                color = "#000000"
            });


            worklist = new ObservableCollection<RecordModels>(source2);
        }

        void CreategooutlistCollection()
        {
            source3.Add(new RecordModels
            {
                leavegoouttime = "10:10",
                backgoouttime = "11:10",
                location = "nkust",
                messagegoout = "開會",
                statusgoout = "未審核",
                color = "#BA4545"


            });
            



            gooutlist = new ObservableCollection<RecordModels>(source3);
        }
        void CreatedayofflistCollection()
        {
            source4.Add(new RecordModels
            {
                leavedayoff = "2021-05-15",
                backdayoff = "2021-05-16",
                selection = "公假",
                messagedayoff = "開會",
                statusdayoff = "未審核",
                 color = "#BA4545"

            });
            source4.Add(new RecordModels
            {
                leavedayoff = "2021-05-15",
                backdayoff = "2021-05-16",
                selection = "病假",
                messagedayoff = "發燒",
                statusdayoff = "已審核",
                color = "#766C6C"
            });


            dayofflist = new ObservableCollection<RecordModels>(source4);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }





}
