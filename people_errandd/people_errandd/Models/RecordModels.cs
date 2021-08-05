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


namespace people_errandd.Models
{
    public class WorkRecordModels
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string status { get; set; }
        public string statuscolor { get; set; }
        public string time { get; set; }
        public string Workimage { get; set; }
    }
    public class DayOffRecordModels
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string   Reason { get; set; }
        public string DayOffType { get; set; }
        public string DayOffimage { get; set; }
        public string Date { get; set; }
    }
    public class GoOutRecordModels
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public string Location { get; set; }
        public string GoOutimage { get; set; }
        public string Date { get; set; }
    }
    public class Records: HttpResponse
    {
        public async Task<List<work>> GetWorkRecord(string _HashAccount)
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameWorkRecord + "GetEmployeeAllWorkRecords" + _HashAccount);
                var result = await response.Content.ReadAsStringAsync();
                List<work> workRecord = JsonConvert.DeserializeObject<List<work>>(result);
                int i = 0;
                foreach (var work in workRecord)
                {                       
                    switch (work.workTypeId)
                    {
                        case 1:
                            workRecord[i].status = "上班";
                            workRecord[i].statuscolor = "#5C76B1";
                            workRecord[i].image = "worker.png";
                            break;
                        case 2:
                            workRecord[i].status = "下班";
                            workRecord[i].statuscolor = "#CA4848";
                            workRecord[i].image = "workeroff.png";
                            break;
                        default:
                            break;
                    }
                    workRecord[i].time = workRecord[i].createdTime.ToString();
                    Console.WriteLine(workRecord[i].status);
                    i++;
                }              
                return workRecord;
            }
            catch (Exception)
            {
            }
            return null;
        }

    }
    

}
