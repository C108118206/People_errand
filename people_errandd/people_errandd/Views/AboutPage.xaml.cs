using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using people_errandd.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        readonly InformationViewModel informationViewModel = new InformationViewModel();
        bool allowTap = true;
        public AboutPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#8CC5D7");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
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

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(allowTap)
                {
                    allowTap = false;
                    if (await informationViewModel.PostInformationRecord(department.Text,jobTitle.Text,phone.Text,email.Text))
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("", "輸入錯誤,請重新輸入", "確認");
                    }
                }
            }
           finally
            {

                allowTap = true;
            }
        }
    }
}