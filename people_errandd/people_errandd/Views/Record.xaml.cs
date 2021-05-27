using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    { 
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
            Navigation.PopAsync();
        }
        async void RecordChooseButton(object sender, EventArgs e)
        {
            RecordsSelector rs = new RecordsSelector();
            var ActionSheet = await DisplayActionSheet("請選擇:", "Cancel", null, "上下班", "請假", "公出");
            //Debug.WriteLine("Action: " + ActionSheet);
            switch (ActionSheet)
            {
                case "Cancel":
                    break;
                case "上下班":
                    Worklist.ItemsSource = await App.DataBase.GetWorkRecordsAsync();                  
                    break;
                case "請假":
                    Worklist.ItemsSource = await App.DataBase.GetDayOffRecordsAsync();
                    break;
                case "公出":
                    Worklist.ItemsSource = await App.DataBase.GetGoOutRecordsAsync();
                    break;
            }
        }     
    }
    public class RecordsSelector : DataTemplateSelector
    {
        public DataTemplate WorkRecords { get; set; }
        public DataTemplate DayOffRecords { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return WorkRecords;
        }        
    }
}