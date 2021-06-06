using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
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
    }
}