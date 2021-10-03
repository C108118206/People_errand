﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.ViewModels;
using people_errandd.Models;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private bool allowTap = true;
        private readonly Login Login = new Login();
        public LoginPage()
        {
            InitializeComponent();
            //隱藏navigationpage導航欄。
            NavigationPage.SetHasNavigationBar(this, false);
            Application.Current.UserAppTheme = OSAppTheme.Light;
            Animation ani = new Animation();
            if (string.IsNullOrEmpty(Preferences.Get("uuid", string.Empty)))
            {
                Preferences.Set("uuid", Guid.NewGuid().ToString());
            }
            Console.WriteLine(Preferences.Get("uuid", ""));
        }
        private async void LogInButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                    {
                        await DisplayAlert("Error", "No Intenet", "OK");
                        return;
                    }
                    if (string.IsNullOrEmpty(company.Text.Trim()))
                    {
                        await DisplayAlert("", "請勿輸入空白", "確認");
                    }
                    else if (await Login.ConfirmCompanyHash(company.Text.Trim()))
                    {
                        if (await Login.ConfirmUUID(Preferences.Get("uuid", "")))
                        {

                            if (!await Login.Reviewed())
                            {
                                
                                await DisplayAlert("審核中", "尚未審核完畢,請稍後再試", "確認");
                                return;
                            }
                            if (!await Login.AccountEnabled())
                            {
                                await DisplayAlert("", "帳號已停用", "確認");
                                return;
                            }
                            Navigation.InsertPageBefore(new MainPage(), this);
                            await Navigation.PopAsync();
                            Preferences.Set("HashAccount", await Login.GetHashAccount(Preferences.Get("uuid", "")));
                        }
                        else
                        {
                            await PopupNavigation.Instance.PushAsync(new VerificationPage("首次登入"));
                        }
                    }
                    else
                    {
                        await DisplayAlert("錯誤", "輸入錯誤", "請重新輸入");
                    }
                }
            }
            finally
            {
                allowTap = true;
            }

        }
        private async void QuestionButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    await DisplayAlert("", "有任何問題，請與我們聯繫", "確定");
                }
            }
            finally
            {
                allowTap = true;
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            transition.Opacity = 0;
            await transition.FadeTo(1, 2500);
            await image.ScaleTo(1.5, 1000, Easing.CubicIn);
            await image.ScaleTo(1, 1000, Easing.CubicOut);
        }
        /*
        private async void Test_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new VerificationPage("繼承資料"));
        }
        */
    }
}