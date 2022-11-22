using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace AradaMart.WixIToCNETntegrator
{
    public class Program
    {
        static void Main(string[] args)
        {
             string details = CallRestMethod("http://localhost:13015/getAchaUser/");
            Console.WriteLine(details);
        }

        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.Headers.Add("Username", "xyz");
            webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public class LoginReply
        {
            public LoginReply()
            {
            }

            public LoginReply(string refresh_token, string access_token)
            {
                this.refresh_token = refresh_token;
                this.access_token = access_token;
            }

            public string refresh_token { get; set; }
            public string access_token { get; set; }
        }

    }
}
