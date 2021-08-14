using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportantAudit : ContentPage
    {
        public ImportantAudit()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#555555");
            MyAnnouncements = GetAnnouncements();
            this.BindingContext = this;

        }
          public class Announcement
        {
            public string GoOutimage { get; set; }
            public string StartTime { get; set; }
            public string Applicant { get; set; }
            public string EndTime { get; set; }
            public string Location { get; set; }
            public string Reason { get; set; }

        }


        public ObservableCollection<Announcement> MyAnnouncements { get; set; }
        private ObservableCollection<Announcement> GetAnnouncements()
        {
            return new ObservableCollection<Announcement>
            {

                new Announcement { GoOutimage="goout2.png",StartTime="2021/05/18 上午09:10",Applicant="SDD", EndTime = "2021/05/18 上午09:10", Location = "school",  Reason = "busy"},
                new Announcement { GoOutimage="goout2.png",StartTime="2021/05/18 上午09:10",Applicant="SDD", EndTime = "2021/05/18 上午09:10", Location = "school",  Reason = "busy"},
                new Announcement { GoOutimage="goout2.png",StartTime="2021/05/18 上午09:10",Applicant="SDD", EndTime = "2021/05/18 上午09:10", Location = "school",  Reason = "busy"},
                new Announcement { GoOutimage="goout2.png",StartTime="2021/05/18 上午09:10",Applicant="SDD", EndTime = "2021/05/18 上午09:10", Location = "school",  Reason = "busy" }
            };
        }
        


    }
}