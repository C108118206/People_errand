using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;
using people_errandd.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace people_errandd.ViewModels
{
    class TakeDayOffViewModel : HttpResponse
    {
        public async Task<bool> PostDayOff(DateTime _StartTime, DateTime _EndTime, int _leave_type_id, string _reason)
        {
            List<DayOff> dayOffs = new List<DayOff>();
            DayOff dayOff = new DayOff()
            {
                hashaccount = Preferences.Get("HashAccount", ""),
                Leavetypeid = _leave_type_id,
                reason = _reason,
                StartDate = _StartTime,
                EndDate = _EndTime,
            };
            dayOffs.Add(dayOff);
            try
            {
                var WorkRecord = JsonConvert.SerializeObject(dayOffs);
                HttpContent content = new StringContent(WorkRecord);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(basic_url + ControllerNameLeaveRecord + "add_leaveRecord", content);
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
