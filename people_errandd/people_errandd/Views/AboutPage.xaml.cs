using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using people_errandd.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using people_errandd.Models;
using Xamarin.Essentials;
using System.Text.RegularExpressions;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        readonly InformationViewModel informationViewModel = new InformationViewModel();
        bool allowTap = true;
        Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        
        Regex regexphone = new Regex("^09");
        
        public AboutPage()
        {
            //this.BindingContext = new InformationViewModel();
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#EDEEEF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#555555");
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            name.Text = Preferences.Get("UserName", name.Text);
            phone.Text=Preferences.Get("phone", phone.Text);
            email.Text=Preferences.Get("email", email.Text);
        }
        void RefButtonClicked(object sender, EventArgs e)
        {         
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    Navigation.PopModalAsync(true);
                }
            }
            finally
            {
                allowTap = true;
            }           
        }
        /*
        async void Image_clicked(System.Object sender,System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions{
                Title = "選一張照片吧!"
            });

            var stream = await result.OpenReadAsync();

            resultImage.Source = ImageSource.FromStream(() => stream);
        }
        */
       /*
        async void Image_clicked(Object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("無法使用", "現在無法使用", "OK");
                        return;
                    }

                    var mediaOptions = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Full
                    };
                    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                    if (resultImage == null)
                    {
                        await DisplayAlert("無法使用", "現在無法使用", "OK");
                        return;
                    }
                    resultImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                }
            }
            finally
            {
                allowTap = true;
            }         
        }
        */
        private async void ConfirmButton(object sender, EventArgs e)
        {
            try
            {
                if (allowTap)
                {
                    allowTap = false;
                    //email regular expression
                    Match matchemail = regexemail.Match(email.Text);
                    //phone regular expression
                    Match matchphone = regexphone.Match(phone.Text);
                    if (matchemail.Success && matchphone.Success)
                    {
                        if (await informationViewModel.UpdateInformationRecord(name.Text, phone.Text, email.Text))
                        {
                            Preferences.Set("phone", phone.Text);
                            Preferences.Set("email", email.Text);
                            await DisplayAlert("", "修改完成", "確認");
                            await Navigation.PopAsync();
                        }                        
                    }                
                    else
                    {
                        await DisplayAlert("", "格式錯誤", "確認");                    
                    }
                }
            }
            finally
            {
                allowTap = true;
            }
        }

        private void email_Unfocused(object sender, FocusEventArgs e)
        {
            Match matchemail = regexemail.Match(email.Text);
            if (!matchemail.Success)
            {
                emailValidator.Text = "格式錯誤";
            }
            else
            {
                emailValidator.Text = "";

            }
        }

        private void phone_Unfocused(object sender, FocusEventArgs e)
        {
            Match matchphone = regexphone.Match(phone.Text);
            if (!matchphone.Success)
            {
                phoneValidator.Text = "格式錯誤";
            }
            else
            {
                phoneValidator.Text = "";
            }
        }
    }
}