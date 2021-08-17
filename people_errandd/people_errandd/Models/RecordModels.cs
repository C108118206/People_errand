using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using people_errandd.Models;
using Xamarin.Essentials;
using System.Linq;


namespace people_errandd.Models
{
    public class Records : HttpResponse
    {
        public async Task<List<work>> GetWorkRecord()
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameWorkRecord + "GetEmployeeAllWorkRecords/" + Preferences.Get("HashAccount", ""));
                Console.WriteLine(basic_url + ControllerNameWorkRecord + "GetEmployeeAllWorkRecords" + Preferences.Get("HashAccount", ""));
                var result = await response.Content.ReadAsStringAsync();
                List<work> workRecords = JsonConvert.DeserializeObject<List<work>>(result);
                int i = 0;
                foreach (var work in workRecords)
                {
                    switch (work.workTypeId)
                    {
                        case 1:
                            workRecords[i].status = "上班";
                            workRecords[i].statuscolor = "#5C76B1";
                            workRecords[i].image = "worker.png";
                            break;
                        case 2:
                            workRecords[i].status = "下班";
                            workRecords[i].statuscolor = "#CA4848";
                            workRecords[i].image = "workeroff.png";
                            break;
                        default:
                            break;
                    }
                    workRecords[i].time = workRecords[i].createdTime.ToString();
                    Console.WriteLine(workRecords[i].status);
                    i++;
                }
                Console.WriteLine("OK");
                //List<work> workRecord;

                return workRecords;
            }
            catch (Exception)
            {
                Console.WriteLine("fail");
                //throw;
            }
            return null;
        }
        public async Task<List<GoOut>> GetGoOutsRecord()
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameTripRecord + Preferences.Get("HashAccount", ""));
                var result = await response.Content.ReadAsStringAsync();
                List<GoOut> GoOutRecord = JsonConvert.DeserializeObject<List<GoOut>>(result);
                Console.WriteLine("OK");
                return GoOutRecord;
            }
            catch (Exception)
            {
                Console.WriteLine("Get GoOut fail");
                //throw;
            }
            return null;
        }
        public async Task<List<DayOff>> GetLeaveRecord()
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameLeaveRecord + "GetEmployeeAllLeaveRecords/" + Preferences.Get("HashAccount", ""));
                var result = await response.Content.ReadAsStringAsync();
                List<DayOff> DayOffRecord = JsonConvert.DeserializeObject<List<DayOff>>(result);
                Console.WriteLine("OK");
                return DayOffRecord;
            }
            catch (Exception)
            {
                Console.WriteLine("Get DayOff fail");
                //throw;
            }
            return null;
        }
    }
}




