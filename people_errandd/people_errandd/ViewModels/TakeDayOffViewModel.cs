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
        public async Task<List<string>> GetEmail()
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameEmployee + "get_employee_manager_email?hash_company=" + Preferences.Get("CompanyHash", "") + "&hash_account=" + Preferences.Get("HashAccount", ""));
                //response = await client.GetAsync("http://163.18.110.100/api/Employees/get_employee_manager_email?company_hash=17C99EADD5A77BD5117719B12478E7&hash_account=1B677A3D9C56372BDAE191EA940440");
                var result = await response.Content.ReadAsStringAsync();
                List<string> Emails = JsonConvert.DeserializeObject<List<string>>(result);
                return Emails;
            }
            catch (Exception)
            {
            }
            return null;
        }
        public async Task<bool> PostDayOff(DateTime _StartTime, DateTime _EndTime, int _leave_type_id, string _reason)
        {
            List<DayOff> dayOffs = new List<DayOff>();
            DayOff dayOff = new DayOff()
            {
                hashAccount = Preferences.Get("HashAccount", ""),
                Leavetypeid = _leave_type_id,
                Reason = _reason,
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
                    try
                    {                       
                        await sendEmail(await GetEmail(), "差勤打卡員工請假申請通知", "<h2>您的員工已進行請假申請，請至APP或後臺上進行確認！</h2>");                       
                    }
                    catch (Exception)
                    {
                    }
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }

}
