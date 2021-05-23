using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;

namespace people_errandd.ViewModels
{
    class TakeDayOffViewModel : HttpResponse
    {
        public async Task<bool> PostDayOffRecord(string _StartTime, string _EndTime,int _leave_type_id,string _reason)
        {
            List<DayOff> dayOffs = new List<DayOff>();
            DayOff dayOff = new DayOff()
            {
                hashaccount = _HashAccount,
                Leave_type_id = _leave_type_id,
                reason = _reason,
                StartTime = _StartTime,
                EndTime=_EndTime,
            };
            dayOffs.Add(dayOff);
            var WorkRecord = JsonConvert.SerializeObject(dayOffs);
            HttpContent content = new StringContent(WorkRecord);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(basic_url + ControllerNameLeaveRecord + "add_leaveRecord", content);
            if (response.StatusCode.ToString() == "OK")
            {
                return true;
            }
            //else
            //{
            //    我就去死;
            //}
            return false;
        }
    }
}
