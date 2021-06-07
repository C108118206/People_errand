using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;

namespace people_errandd.ViewModels
{
    class InformationViewModel:HttpResponse
    {
        public async Task<bool> PostInformationRecord(string _department,string _jobTitle,string _phone,string _email)
        {
            List<information> informations = new List<information>();
            information information = new information()
            {
                department = _department,
                jobtitle = _jobTitle,
                phone=_phone,
                email=_email
            };
            informations.Add(information);
            try
            {
                var WorkRecord = JsonConvert.SerializeObject(informations);
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
