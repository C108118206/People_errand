using people_errandd.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
[assembly: Dependency(typeof(AppSettingsInterface))]
namespace people_errandd.iOS
{
    public class AppSettingsInterface : IAppSettingsHelper
    {
        public void OpenAppSetting()
        {
            var url = new NSUrl($"app-settings:root=LOCATION_SERVICES");
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}