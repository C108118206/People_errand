using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using people_errandd.Models;
using System.Collections.ObjectModel;
using people_errandd.ViewModels;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        private bool allowTap = true;
        public static int RecordTypeId = 1;
        public static DateTime dt;
        Records Records = new Records();
        private int Date;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Worklist.ItemsSource = await Records.GetWorkRecord();
            RecordTypeId = 1;
            //Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();
            //Preferences.Get("Record", "await App.DataBase.GetWorkRecordsAsync()");
            // Worklist.ItemsSource =(Preferences.Get("Record", "await App.DataBase.GetWorkRecordsAsync()"));
            dt = DatePicker.Date;
            switch (dt.ToString("dddd"))
            {
                case "星期日":
                    sun.Text = dt.AddDays(0).ToString("dd");
                    mon.Text = dt.AddDays(1).ToString("dd");
                    tue.Text = dt.AddDays(2).ToString("dd");
                    wed.Text = dt.AddDays(3).ToString("dd");
                    thu.Text = dt.AddDays(4).ToString("dd");
                    fri.Text = dt.AddDays(5).ToString("dd");
                    sat.Text = dt.AddDays(6).ToString("dd");
                    Date = 0;
                    sun.BackgroundColor = Color.FromHex("#5C76B1");
                    sun.TextColor = Color.FromHex("#FFFFFF");
                    break;
                case "星期一":
                    sun.Text = dt.AddDays(-1).ToString("dd");
                    mon.Text = dt.AddDays(0).ToString("dd");
                    tue.Text = dt.AddDays(1).ToString("dd");
                    wed.Text = dt.AddDays(2).ToString("dd");
                    thu.Text = dt.AddDays(3).ToString("dd");
                    fri.Text = dt.AddDays(4).ToString("dd");
                    sat.Text = dt.AddDays(5).ToString("dd");
                    Date = 1;
                    mon.BackgroundColor = Color.FromHex("#5C76B1");
                    mon.TextColor = Color.FromHex("#FFFFFF");
                    break;
                case "星期二":
                    sun.Text = dt.AddDays(-2).ToString("dd");
                    mon.Text = dt.AddDays(-1).ToString("dd");
                    tue.Text = dt.AddDays(0).ToString("dd");
                    wed.Text = dt.AddDays(1).ToString("dd");
                    thu.Text = dt.AddDays(2).ToString("dd");
                    fri.Text = dt.AddDays(3).ToString("dd");
                    sat.Text = dt.AddDays(4).ToString("dd");
                    Date = 2;
                    tue.BackgroundColor = Color.FromHex("#5C76B1");
                    tue.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期三":
                    sun.Text = dt.AddDays(-3).ToString("dd");
                    mon.Text = dt.AddDays(-2).ToString("dd");
                    tue.Text = dt.AddDays(-1).ToString("dd");
                    wed.Text = dt.AddDays(0).ToString("dd");
                    thu.Text = dt.AddDays(1).ToString("dd");
                    fri.Text = dt.AddDays(2).ToString("dd");
                    sat.Text = dt.AddDays(3).ToString("dd");
                    Date = 3;
                    wed.BackgroundColor = Color.FromHex("#5C76B1");
                    wed.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期四":
                    sun.Text = dt.AddDays(-4).ToString("dd");
                    mon.Text = dt.AddDays(-3).ToString("dd");
                    tue.Text = dt.AddDays(-2).ToString("dd");
                    wed.Text = dt.AddDays(-1).ToString("dd");
                    thu.Text = dt.AddDays(0).ToString("dd");
                    fri.Text = dt.AddDays(1).ToString("dd");
                    sat.Text = dt.AddDays(2).ToString("dd");
                    Date = 4;
                    thu.BackgroundColor = Color.FromHex("#5C76B1");
                    thu.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期五":
                    sun.Text = dt.AddDays(-5).ToString("dd");
                    mon.Text = dt.AddDays(-4).ToString("dd");
                    tue.Text = dt.AddDays(-3).ToString("dd");
                    wed.Text = dt.AddDays(-2).ToString("dd");
                    thu.Text = dt.AddDays(-1).ToString("dd");
                    fri.Text = dt.AddDays(0).ToString("dd");
                    sat.Text = dt.AddDays(1).ToString("dd");
                    Date = 5;
                    fri.BackgroundColor = Color.FromHex("#5C76B1");
                    fri.TextColor = Color.FromHex("#FFFFFF");

                    break;
                case "星期六":
                    sun.Text = dt.AddDays(-6).ToString("dd");
                    mon.Text = dt.AddDays(-5).ToString("dd");
                    tue.Text = dt.AddDays(-4).ToString("dd");
                    wed.Text = dt.AddDays(-3).ToString("dd");
                    thu.Text = dt.AddDays(-2).ToString("dd");
                    fri.Text = dt.AddDays(-1).ToString("dd");
                    sat.Text = dt.AddDays(0).ToString("dd");
                    Date = 6;
                    sat.BackgroundColor = Color.FromHex("#5C76B1");
                    sat.TextColor = Color.FromHex("#FFFFFF");
                    break;
            }

        }
        public Record()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#555555");
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    Navigation.PopAsync();
                    RecordTypeId = 0;
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        async void RecordChooseButton(object sender, EventArgs e)
        {

            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    var ActionSheet = await DisplayActionSheet("請選擇:", "Cancel", null, "上下班", "請假", "公出");
                    switch (ActionSheet)
                    {
                        case "Cancel":
                            break;
                        case "上下班":
                            Worklist.ItemsSource = await Records.GetWorkRecord();
                            RecordTypeId = 1;
                            RecordTitle.Text = "打卡紀錄";
                            break;
                        case "請假":
                            Worklist.ItemsSource = await Records.GetLeaveRecord();
                            RecordTypeId = 2;
                            RecordTitle.Text = "請假紀錄";
                            break;
                        case "公出":
                            Worklist.ItemsSource = await Records.GetGoOutsRecord();
                            RecordTitle.Text = "公出紀錄";
                            RecordTypeId = 3;
                            break;
                    }
                }
            }
            finally
            {
                allowTap = true;
            }
        }

        public async Task Switch()
        {
            switch (RecordTypeId)
            {
                case 0:
                case 1:
                    Worklist.ItemsSource = await Records.GetWorkRecord();
                    break;
                case 2:
                    Worklist.ItemsSource = await Records.GetLeaveRecord();
                    break;
                case 3:
                    Worklist.ItemsSource = await Records.GetGoOutsRecord();
                    break;
            }
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.TextColor = Color.FromHex("#555555");
            tue.TextColor = Color.FromHex("#555555");
            wed.TextColor = Color.FromHex("#555555");
            thu.TextColor = Color.FromHex("#555555");
            fri.TextColor = Color.FromHex("#555555");
            sat.TextColor = Color.FromHex("#555555");
            // DisplayAlert("", DatePicker.Date.ToString("yyyy-MM-dd-HH-mm-ss"), "fuck");
            dt = DatePicker.Date;
            await Switch();

            switch (dt.ToString("dddd"))
            {
                case "星期日":
                    sun.Text = dt.AddDays(0).ToString("dd");
                    mon.Text = dt.AddDays(1).ToString("dd");
                    tue.Text = dt.AddDays(2).ToString("dd");
                    wed.Text = dt.AddDays(3).ToString("dd");
                    thu.Text = dt.AddDays(4).ToString("dd");
                    fri.Text = dt.AddDays(5).ToString("dd");
                    sat.Text = dt.AddDays(6).ToString("dd");
                    sun.BackgroundColor = Color.FromHex("#5C76B1");
                    sun.TextColor = Color.FromHex("#FFFFFF");
                    Date = 0;
                    break;
                case "星期一":
                    sun.Text = dt.AddDays(-1).ToString("dd");
                    mon.Text = dt.AddDays(0).ToString("dd");
                    tue.Text = dt.AddDays(1).ToString("dd");
                    wed.Text = dt.AddDays(2).ToString("dd");
                    thu.Text = dt.AddDays(3).ToString("dd");
                    fri.Text = dt.AddDays(4).ToString("dd");
                    sat.Text = dt.AddDays(5).ToString("dd");
                    mon.BackgroundColor = Color.FromHex("#5C76B1");
                    mon.TextColor = Color.FromHex("#FFFFFF");
                    Date = 1;
                    break;
                case "星期二":
                    sun.Text = dt.AddDays(-2).ToString("dd");
                    mon.Text = dt.AddDays(-1).ToString("dd");
                    tue.Text = dt.AddDays(0).ToString("dd");
                    wed.Text = dt.AddDays(1).ToString("dd");
                    thu.Text = dt.AddDays(2).ToString("dd");
                    fri.Text = dt.AddDays(3).ToString("dd");
                    sat.Text = dt.AddDays(4).ToString("dd");
                    tue.BackgroundColor = Color.FromHex("#5C76B1");
                    tue.TextColor = Color.FromHex("#FFFFFF");
                    Date = 2;
                    break;
                case "星期三":
                    sun.Text = dt.AddDays(-3).ToString("dd");
                    mon.Text = dt.AddDays(-2).ToString("dd");
                    tue.Text = dt.AddDays(-1).ToString("dd");
                    wed.Text = dt.AddDays(0).ToString("dd");
                    thu.Text = dt.AddDays(1).ToString("dd");
                    fri.Text = dt.AddDays(2).ToString("dd");
                    sat.Text = dt.AddDays(3).ToString("dd");
                    wed.BackgroundColor = Color.FromHex("#5C76B1");
                    wed.TextColor = Color.FromHex("#FFFFFF");
                    Date = 3;
                    break;
                case "星期四":
                    sun.Text = dt.AddDays(-4).ToString("dd");
                    mon.Text = dt.AddDays(-3).ToString("dd");
                    tue.Text = dt.AddDays(-2).ToString("dd");
                    wed.Text = dt.AddDays(-1).ToString("dd");
                    thu.Text = dt.AddDays(0).ToString("dd");
                    fri.Text = dt.AddDays(1).ToString("dd");
                    sat.Text = dt.AddDays(2).ToString("dd");
                    thu.BackgroundColor = Color.FromHex("#5C76B1");
                    thu.TextColor = Color.FromHex("#FFFFFF");
                    Date = 4;
                    break;
                case "星期五":
                    sun.Text = dt.AddDays(-5).ToString("dd");
                    mon.Text = dt.AddDays(-4).ToString("dd");
                    tue.Text = dt.AddDays(-3).ToString("dd");
                    wed.Text = dt.AddDays(-2).ToString("dd");
                    thu.Text = dt.AddDays(-1).ToString("dd");
                    fri.Text = dt.AddDays(0).ToString("dd");
                    sat.Text = dt.AddDays(1).ToString("dd");
                    fri.BackgroundColor = Color.FromHex("#5C76B1");
                    fri.TextColor = Color.FromHex("#FFFFFF");
                    Date = 5;
                    break;
                case "星期六":
                    sun.Text = dt.AddDays(-6).ToString("dd");
                    mon.Text = dt.AddDays(-5).ToString("dd");
                    tue.Text = dt.AddDays(-4).ToString("dd");
                    wed.Text = dt.AddDays(-3).ToString("dd");
                    thu.Text = dt.AddDays(-2).ToString("dd");
                    fri.Text = dt.AddDays(-1).ToString("dd");
                    sat.Text = dt.AddDays(0).ToString("dd");
                    sat.BackgroundColor = Color.FromHex("#5C76B1");
                    sat.TextColor = Color.FromHex("#FFFFFF");
                    Date = 6;
                    break;

            }
        }
        private async void SunButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            sun.BackgroundColor = Color.FromHex("#5C76B1");
            sun.TextColor = Color.FromHex("#FFFFFF");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");
            await Switch();
        }
        private async void MonButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(1);
            mon.BackgroundColor = Color.FromHex("#5C76B1");
            mon.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");
            await Switch();
        }
        private async void TueButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(2);
            tue.BackgroundColor = Color.FromHex("#5C76B1");
            tue.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");
            await Switch();
        }
        private async void WedButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(3);
            wed.BackgroundColor = Color.FromHex("#5C76B1");
            wed.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#555555");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#555555");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#555555");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#555555");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#555555");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#555555");
            await Switch();
        }
        private async void ThuButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(4);
            thu.BackgroundColor = Color.FromHex("#5C76B1");
            thu.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#000000");
            await Switch();
        }
        private async void FriButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(5);
            Console.WriteLine(dt + "fuck");
            fri.BackgroundColor = Color.FromHex("#5C76B1");
            fri.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#FFFFFF");
            sat.TextColor = Color.FromHex("#000000");
            await Switch();
        }
        private async void SatButton(object sender, EventArgs e)
        {
            dt = DateTime.Parse(DatePicker.Date.ToString("yyyy-MM-dd"));
            dt = dt.AddDays(-Date);
            dt = dt.AddDays(6);
            sat.BackgroundColor = Color.FromHex("#5C76B1");
            sat.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#FFFFFF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#FFFFFF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#FFFFFF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#FFFFFF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#FFFFFF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#FFFFFF");
            fri.TextColor = Color.FromHex("#000000");
            await Switch();
        }
    }
    public class RecordsSelector : DataTemplateSelector
    {
        public DataTemplate WorkRecords { get; set; }
        public DataTemplate DayOffRecords { get; set; }
        public DataTemplate GoOutRecords { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (Record.RecordTypeId)
            {
                case 2:
                    return DayOffRecords;
                case 3:
                    return GoOutRecords;
                default:
                    return WorkRecords;
            }
        }
    }


}