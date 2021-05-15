using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace people_errandd.ViewModels
{
    class geoLocation
    {
        

        public async Task<bool> GetCurrentLocation()
        {
            
            try
            {

                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                Location locationCompany = new Location(22.7522, 120.3287);
                if (location != null)
                {
                    Location locationNow = new Location(location.Latitude, location.Longitude);                  
                    double distance = Location.CalculateDistance(locationNow, locationCompany, DistanceUnits.Kilometers);
                    if(distance<0.05)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return false;
        }
    }
}
