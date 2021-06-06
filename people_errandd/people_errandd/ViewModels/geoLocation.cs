﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace people_errandd.ViewModels
{
    class geoLocation
    {
        public  async Task<(double, double)> GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                return (location.Latitude, location.Longitude);
            }
            catch(Exception)
            {

            }
            return (0,0);
        }
        public bool GetCurrentLocation(double X, double Y)
        {
            try
            {
                Location locationCompany = new Location(24.8078583, 121.1843923);
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
