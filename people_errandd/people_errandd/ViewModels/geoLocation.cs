using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace people_errandd.ViewModels
{
    class geoLocation
    {
        public CancellationTokenSource cts;
        public  async Task<(double, double)> GetLocation(string status)
        {
            try
            {
                if(status== "Back")
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    var location = await Geolocation.GetLocationAsync(request, cts.Token);
                    Console.WriteLine("getLocation");
                    return (location.Latitude, location.Longitude);
                }
                else
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();                   
                    return (location.Latitude, location.Longitude);
                }
                
            }
            catch (Exception)
            {
                Preferences.Set("gpsText", "定位未開啟");
                Preferences.Set("GpsButtonColor", "#E56262");
                Console.WriteLine("ERROR");
            }
            return (0,0);
        }
        public bool GetCurrentLocation(double X, double Y)
        {
            try
            {
                Location locationCompany = new Location(Convert.ToDouble(Preferences.Get("companyX","")),Convert.ToDouble(Preferences.Get("companyY","")));
                Location locationNow = new Location(X, Y);
                double distance = Location.CalculateDistance(locationNow, locationCompany, DistanceUnits.Kilometers);
                if (distance < 0.2)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {          
            }         
            return false;
        }
    }
}
