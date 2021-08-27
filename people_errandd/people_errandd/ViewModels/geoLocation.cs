using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace people_errandd.ViewModels
{
    class geoLocation
    {
        public CancellationTokenSource cts;
        Geocoder geoCoder = new Geocoder();
        public static string LocationNowText { get; set; }
        public async Task<(double, double)> GetLocation(string status)
        {
            try
            { 
                if (status != "Back")
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();
                    return (location.Latitude, location.Longitude);
                }
                else
                {

                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                    await GetLocationText(location.Latitude, location.Longitude);
                    return (location.Latitude, location.Longitude);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Preferences.Set("gpsText", "定位未開啟");
                Preferences.Set("GpsButtonColor", "#CA4848");
            }
            return (0, 0);
        }
        public bool GetCurrentLocation(double X, double Y)
        {
            try
            {
                Location locationCompany = new Location(Convert.ToDouble(Preferences.Get("companyX", "")), Convert.ToDouble(Preferences.Get("companyY", "")));
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
        public async Task GetLocationText(double X , double Y)
        {            
            Position position = new Position(X,Y);
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            LocationNowText=possibleAddresses.FirstOrDefault().Substring(5);          
            //Preferences.Set("LocationNowText", possibleAddresses.FirstOrDefault());
        }
    }
}
