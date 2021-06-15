using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;

namespace people_errandd.ViewModels
{
    class GoOutViewModel : HttpResponse
    {
        public async Task<bool> PostGoOut(DateTime _StartTime, DateTime _EndTime, string _location, string _reason)
        {
            List<GoOut> goOuts = new List<GoOut>();
            GoOut goOut= new GoOut()
            {
                hashaccount = Preferences.Get("HashAccount", ""),
                Location=_location,
                reason = _reason,
                StartDate = _StartTime,
                EndDate = _EndTime,
            };
            goOuts.Add(goOut);
            try
            {
                var WorkRecord = JsonConvert.SerializeObject(goOuts);
                HttpContent content = new StringContent(WorkRecord);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(basic_url + ControllerNameTripRecord + "add_TripRecord", content);
                if (response.StatusCode.ToString() == "OK")
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return false;
        }
    }

}
