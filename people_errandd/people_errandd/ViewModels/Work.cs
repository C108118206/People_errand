using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;

namespace people_errandd.ViewModels
{
    class Work : HttpResponse
    {
        public  async Task<int> GetWorkType()
        {
            response = await client.GetAsync(basic_url + ControllerNameWorkRecord + Preferences.Get("HashAccount", ""));
            //Console.WriteLine(response.StatusCode);
            if (response.StatusCode.ToString() == "NoContent")
            {
                return 0;
                
            }
            else if (response.StatusCode.ToString() == "OK")
            {
                GetResponse = await response.Content.ReadAsStringAsync();
                work workStatus = JsonConvert.DeserializeObject<work>(GetResponse);
                return workStatus.workTypeId;
            }
            return 500;
        }
        public async Task<bool> PostWork(int _WorkTypeId, double _coordinateX, double _coordinateY ,bool _enable)
        {
            List<work> works = new List<work>();
            work work = new work()
            {
                workTypeId = _WorkTypeId,
                hashAccount = Preferences.Get("HashAccount", ""),
                coordinateX = _coordinateX,
                coordinateY = _coordinateY,
                enabled = _enable
            };
            works.Add(work);
            var WorkRecord= JsonConvert.SerializeObject(works);
            HttpContent content = new StringContent(WorkRecord);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = await client.PostAsync(basic_url + ControllerNameWorkRecord + "add_workRecord", content);
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
        public bool PostWork(double _coordinateX, double _coordinateY)
        {
            List<work> works = new List<work>();
            work work = new work()
            {
                workTypeId =0,
                hashAccount = Preferences.Get("HashAccount", ""),
                coordinateX = _coordinateX,
                coordinateY = _coordinateY
            };
            works.Add(work);
            var WorkRecord = JsonConvert.SerializeObject(works);
            HttpContent content = new StringContent(WorkRecord);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = client.PostAsync(basic_url + ControllerNameWorkRecord + "add_workRecord", content).Result;
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
