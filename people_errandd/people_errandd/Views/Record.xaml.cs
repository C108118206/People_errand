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

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        private bool allowTap = true;
        public static int RecordTypeId;
        public static DateTime Date = DateTime.Today;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();
            //Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();
            //Preferences.Get("Record", "await App.DataBase.GetWorkRecordsAsync()");
            // Worklist.ItemsSource =(Preferences.Get("Record", "await App.DataBase.GetWorkRecordsAsync()"));
            DateTime dt = DatePicker.Date;
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

                    sun.BackgroundColor = Color.FromHex("#7CBFE7");
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

                    mon.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                    tue.BackgroundColor = Color.FromHex("#7CBFE7");
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
                   
                    wed.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                        thu.BackgroundColor = Color.FromHex("#7CBFE7");
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
                   
                    fri.BackgroundColor = Color.FromHex("#7CBFE7");
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
                   
                    sat.BackgroundColor = Color.FromHex("#7CBFE7");
                    sat.TextColor = Color.FromHex("#FFFFFF");
                    
                    break;
            }
        }
        public Record()
        {
            
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
           
           
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
                            Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();
                            RecordTypeId = 1;
                            RecordTitle.Text = "打卡紀錄";
                            break;
                        case "請假":
                            Worklist.ItemsSource = await App.DataBase.GetDayOffRecordsAsync();
                            Preferences.Set("RecordSelector", 2);
                            RecordTypeId = 2;
                            RecordTitle.Text = "請假紀錄";
                            break;
                        case "公出":
                            Worklist.ItemsSource = await App.DataBase.GetGoOutRecordsAsync();
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

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.TextColor = Color.FromHex("#000000");
            tue.TextColor = Color.FromHex("#000000");
            wed.TextColor = Color.FromHex("#000000");
            thu.TextColor = Color.FromHex("#000000");
            fri.TextColor = Color.FromHex("#000000");
            sat.TextColor = Color.FromHex("#000000");

            // DisplayAlert("", DatePicker.Date.ToString("yyyy-MM-dd-HH-mm-ss"), "fuck");
            Date = DatePicker.Date;
            switch (RecordTypeId)
            {
                case 0:
                case 1:
                    Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();
                    break;
                case 2:
                    Worklist.ItemsSource = await App.DataBase.GetDayOffRecordsAsync();
                    break;
                case 3:
                    Worklist.ItemsSource = await App.DataBase.GetGoOutRecordsAsync();
                    break;
            }
            DateTime dt = DatePicker.Date;
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
                   
                     sun.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                     mon.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                    
                     tue.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                    wed.BackgroundColor = Color.FromHex("#7CBFE7");
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
                    
                     thu.BackgroundColor = Color.FromHex("#7CBFE7");
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
                   
                    fri.BackgroundColor = Color.FromHex("#7CBFE7");
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
                   
                   
                    sat.BackgroundColor = Color.FromHex("#7CBFE7");
                    sat.TextColor = Color.FromHex("#FFFFFF");
                    
                    break;
            }
            }
        private void SunButton(object sender, EventArgs e)
        {
            sun.BackgroundColor = Color.FromHex("#7CBFE7");
            sun.TextColor = Color.FromHex("#FFFFFF");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");



        }
        private void MonButton(object sender, EventArgs e)
        {
            mon.BackgroundColor = Color.FromHex("#7CBFE7");
            mon.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void TueButton(object sender, EventArgs e)
        {
            tue.BackgroundColor = Color.FromHex("#7CBFE7");
            tue.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void WedButton(object sender, EventArgs e)
        {
            wed.BackgroundColor = Color.FromHex("#7CBFE7");
            wed.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void ThuButton(object sender, EventArgs e)
        {
            thu.BackgroundColor = Color.FromHex("#7CBFE7");
            thu.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void FriButton(object sender, EventArgs e)
        {
            fri.BackgroundColor = Color.FromHex("#7CBFE7");
            fri.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            sat.BackgroundColor = Color.FromHex("#EDEEEF");
            sat.TextColor = Color.FromHex("#000000");

        }
        private void SatButton(object sender, EventArgs e)
        {
            sat.BackgroundColor = Color.FromHex("#7CBFE7");
            sat.TextColor = Color.FromHex("#FFFFFF");
            sun.BackgroundColor = Color.FromHex("#EDEEEF");
            sun.TextColor = Color.FromHex("#000000");
            mon.BackgroundColor = Color.FromHex("#EDEEEF");
            mon.TextColor = Color.FromHex("#000000");
            tue.BackgroundColor = Color.FromHex("#EDEEEF");
            tue.TextColor = Color.FromHex("#000000");
            wed.BackgroundColor = Color.FromHex("#EDEEEF");
            wed.TextColor = Color.FromHex("#000000");
            thu.BackgroundColor = Color.FromHex("#EDEEEF");
            thu.TextColor = Color.FromHex("#000000");
            fri.BackgroundColor = Color.FromHex("#EDEEEF");
            fri.TextColor = Color.FromHex("#000000");

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
                    return  DayOffRecords;
                case 3:
                    return GoOutRecords;
                default:
                    return WorkRecords;
            } 
        } 
    }

    
}