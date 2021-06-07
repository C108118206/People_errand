using Android.Content;
using people_errandd.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;
[assembly: Dependency(typeof(AppSettingsInterface))]
namespace people_errandd.Droid
{
    public class AppSettingsInterface : MainActivity,IAppSettingsHelper
    {
        public void OpenAppSetting()
        {
            var intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            Application.Context.StartActivity(intent);         
        }
    }
}
          
        
    
