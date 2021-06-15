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
        }
        public Record()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#B4D3EA");
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