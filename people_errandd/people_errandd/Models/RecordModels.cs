﻿using SQLite;
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
using Xamarin.Forms.Maps;

namespace people_errandd.Models
{
    public class Records : HttpResponse
    {
        public async Task<List<work>> GetWorkRecord(string date )
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameWorkRecord + "GetEmployeeAllWorkRecords/" + Preferences.Get("HashAccount", ""));
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
                    Console.WriteLine(workRecords[i].time);
                    i++;
                }

                workRecords = workRecords.Where(work => work.time.Contains(date)).ToList();
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
        public async Task<List<GoOut>> GetGoOutsRecord(string date )
        {
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameTripRecord + Preferences.Get("HashAccount", ""));                   
                var result = await response.Content.ReadAsStringAsync();
                List<GoOut> GoOutRecords = JsonConvert.DeserializeObject<List<GoOut>>(result);
                GoOutRecords = GoOutRecords.Where(GoOut => GoOut.createdTime.ToString().Contains(date)).ToList();
                return GoOutRecords;
            }
            catch (Exception)
            {
                Console.WriteLine("Get GoOut fail");
                //throw;
            }
            return null;
        }
        public async Task<List<DayOff>> GetLeaveRecord(string date , string employee_HashAccount)
        {
            try
            {

                response = /*string.IsNullOrEmpty(employee_HashAccount) ?*/
                    await client.GetAsync(basic_url + ControllerNameLeaveRecord + "GetEmployeeAllLeaveRecords/" + Preferences.Get("HashAccount", ""));
                  // : await client.GetAsync(basic_url + ControllerNameLeaveRecord + "GetEmployeeAllLeaveRecords/" + employee_HashAccount);
                var result = await response.Content.ReadAsStringAsync();
                List<DayOff> DayOffRecords = JsonConvert.DeserializeObject<List<DayOff>>(result);                
                DayOffRecords = DayOffRecords.Where(DayOff => DayOff.createdTime.ToString().Contains(date)).ToList();
                return DayOffRecords;
            }
            catch (Exception)
            {
                Console.WriteLine("Get DayOff fail");
                //throw;
            }
            return null;
        }
        public async Task<List<GoOut>> GetAdvanceGoOutsRecord(string date)
        {
            Geocoder geoCoder = new Geocoder();
            try
            {
                response = await client.GetAsync(basic_url + ControllerNameTrip2Record + "GetEmployeeTrip2Records/" + Preferences.Get("HashAccount", ""));
                var result = await response.Content.ReadAsStringAsync();
                List<GoOut> GoOutRecords = JsonConvert.DeserializeObject<List<GoOut>>(result);
                int i = 0;
                
                foreach (var goOut in GoOutRecords)
                {
                    Position position = new Position(goOut.coordinateX, goOut.coordinateY);
                    IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                    GoOutRecords[i].Location=possibleAddresses.FirstOrDefault();
                    switch (goOut.trip2TypeId)
                    {
                        case 1:
                            GoOutRecords[i].status = "公出開始";
                            GoOutRecords[i].statuscolor = "#FBB800";
                            GoOutRecords[i].advanceimage = "startgoout.png";
                            break;
                        case 2:
                            GoOutRecords[i].status = "到站";
                            GoOutRecords[i].statuscolor = "#E22E2E";
                            GoOutRecords[i].advanceimage = "stop.png";
                            break;
                        case 3:
                            GoOutRecords[i].status = "公出結束";
                            GoOutRecords[i].statuscolor = "#2E88E2";
                            GoOutRecords[i].advanceimage = "finishgoout.png";
                            break;
                        default:
                            break;
                    }
                    i++;
                    
                }
                GoOutRecords = GoOutRecords.Where(GoOut => GoOut.createdTime.ToString().Contains(date)).ToList();
                return GoOutRecords;

            }
            catch (Exception)
            {
                Console.WriteLine("Get GoOut fail");
                //throw;
            }
            return null;
        }
    }
}




