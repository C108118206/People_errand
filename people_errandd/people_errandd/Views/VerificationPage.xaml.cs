using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using people_errandd.ViewModels;
using Rg.Plugins.Popup.Extensions;
using people_errandd.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly Login Login = new Login();
        private readonly InformationViewModel information = new InformationViewModel();
        Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public VerificationPage(string _Title)
        {
            InitializeComponent();
            PageTitle.Text = _Title;
        }

        private async void LoginButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameResult.Text) && string.IsNullOrEmpty(UserEmailResult.Text))
            {
                await DisplayAlert("錯誤", "請勿輸入空白", "確認");
            }
            else
            {
                Match matchemail = regexemail.Match(UserEmailResult.Text);
                if (matchemail.Success)
                {
                    if (!await information.ConfirmEmail(UserEmailResult.Text))
                    {
                        if (await Login.SetUUID() && await Login.SetInformation(UserNameResult.Text, UserEmailResult.Text))
                        {
                            await DisplayAlert("已送出成功", "待管理者審核成功後，將發送通知信至郵件即可進行登入", "確認");
                            await Navigation.PopPopupAsync();
                            Preferences.Set("審核中", "");
                        }
                        else
                        {
                            await DisplayAlert("網路錯誤", "請檢查網路", "確認");
                        }
                    }
                    else
                    {
                        await DisplayAlert("錯誤", "信箱已存在", "確認");
                    }                                       
                }
                else
                {
                    await DisplayAlert("格式錯誤", "電子郵件格式錯誤", "確認");
                }
            }
        }
    }
}