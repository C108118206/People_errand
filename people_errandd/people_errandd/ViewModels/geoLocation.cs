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
                    
                    return (location.Latitude, location.Longitude);
                }
                else
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();
                    if (location == null)
                    {
                        var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                        cts = new CancellationTokenSource();
                        location = await Geolocation.GetLocationAsync(request, cts.Token);
                        
                    }
                    return (location.Latitude, location.Longitude);
                }
            }
            catch (Exception)
            {
            }
            return (1,1);
        }
        public bool GetCurrentLocation(double X, double Y)
        {
            try
            {
                Location locationCompany = new Location(Convert.ToDouble(Preferences.Get("companyX","")),Convert.ToDouble(Preferences.Get("companyY","")));
                Location locationNow = new Location(X, Y);
                double distance = Location.CalculateDistance(locationNow, locationCompany, DistanceUnits.Kilometers);
                if (distance < 0.05)
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
