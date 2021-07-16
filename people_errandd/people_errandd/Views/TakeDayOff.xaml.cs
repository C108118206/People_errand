﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.ViewModels;
using people_errandd.Models;
using System.Collections.Generic;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeDayOff : ContentPage
    {
        private bool allowTap = true;
        //private static int typeId;
        readonly TakeDayOffViewModel takeDayOff = new TakeDayOffViewModel();
        public TakeDayOff()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
            //var dayoffList = new List<string>();
            //dayoffList.Add("事假");
            //dayoffList.Add("病假");
            //dayoffList.Add("喪假");
            //dayoffList.Add("產假");
            //dayoffList.Add("生理假");
            //dayoffList.Add("流產假");
            //dayoffList.Add("產前假");
            //dayoffList.Add("陪產假");

            //var picker = new Picker { Title = "請選擇:", TitleColor = Color.FromHex("#696969") };
            //leaveType.ItemsSource = dayoffList;
            startTimePicker.IsVisible =true? !AlldaySwitch.IsToggled : AlldaySwitch.IsToggled;
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    Navigation.PopAsync();
                }
            }
            finally
            {
                allowTap = true;
            }
        }


        private void AlldaySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (AlldaySwitch.IsToggled == true)
            {
                startTimePicker.IsVisible = false;
                endTimePicker.IsVisible = false;
            }
            else
            {
                startTimePicker.IsVisible = true;
                endTimePicker.IsVisible = true;              
            }
        }

       private void Personal(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "事假";
        }
        private void Sick(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "病假";
        }
        private void Bereavement(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "喪假";
        }
        private void Maternity(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "產假";
        }
        private void Physiological(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "生理假";
        }
        private void Abortion(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "流產假";
        }
        private void Prenatal(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "產前假";
        }
        private void Paternity(object sender, CheckedChangedEventArgs e)
        {
            leavetype.Text = "陪產假";
        }

    }

}