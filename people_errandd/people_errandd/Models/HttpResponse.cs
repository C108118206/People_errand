using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using people_errandd.Models;
using System.Text;
using System.Net.Mail;

namespace people_errandd.Models
{

    public class HttpResponse
    {
        //static company c = new company();
        public static HttpClient client = new HttpClient();
        
        public static HttpResponseMessage response = new HttpResponseMessage();
        public static readonly string basic_url = "http://163.18.110.100/api/";//主機ㄉURL  
        public static readonly string ControllerNameCompany = "Companies/";//Company api
        public static readonly string ControllerNameEmployee = "employees/";//Employee api
        public static readonly string ControllerNameWorkRecord = "EmployeeWorkRecords/";//workRecord api
        public static readonly string ControllerNameLeaveRecord = "EmployeeLeaveRecords/";//LeaveRecord api
        public static readonly string ControllerNameTripRecord = "EmployeeTripRecords/";//TripRecord api
        public static readonly string ControllerNameInformation = "EmployeeInformations/";//EmployeeInformations api
        public static readonly string ControllerNameTrip2Record = "EmployeeTrip2Record/";//TripRecord api
        public static readonly string subscriptionKey = "2f553f597a914324882f8f0f3db42a41";//azure translate api key
        public static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";//azure translate url
        public static readonly string LanguageRoute = "/detect?api-version=3.0";//language route             
        public static string GetResponse { get; set; }

        public static void sendEmail(string to_email, string email_subject, string email_body)//寄EMAIL
        {
            try
            {
                MailMessage mail = new MailMessage();
                //前面是發信email後面是顯示的名稱
                mail.From = new MailAddress("C108118242@nkust.edu.tw", "差勤打卡");

                //收信者email
                mail.To.Add(to_email);

                //設定優先權
                mail.Priority = MailPriority.Normal;

                //標題
                mail.Subject = email_subject;

                //內容
                mail.Body = email_body;

                //內容使用html
                mail.IsBodyHtml = true;

                //設定gmail的smtp (這是google的)
                SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

                //您在gmail的帳號密碼
                MySmtp.Credentials = new System.Net.NetworkCredential("like3yy@gmail.com", "nkust.edu.tw");

                //開啟ssl
                MySmtp.EnableSsl = true;

                //發送郵件
                MySmtp.Send(mail);

                //放掉宣告出來的MySmtp
                MySmtp = null;

                //放掉宣告出來的mail
                mail.Dispose();
                Console.WriteLine("成功發送EMAIL通知!");
            }
            catch (Exception)
            {
                Console.WriteLine("發送EMAIL通知失敗!");
            }
        }
    }
}