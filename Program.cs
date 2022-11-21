using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
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
        //private RestClientOptions BaseUrl = new RestClientOptions("https://www.wixapis.com/oauth/access")
        private RestClientOptions BaseUrl = new RestClientOptions("https://testandy.free.beeceptor.com")
            {
                 ThrowOnAnyError = true,
                Timeout = 1000
            };
        private CancellationToken cancellationToken= new CancellationToken(false);

        static   void Main(string[] args)
        {
            Program program = new Program();
            //      program.PostData().Wait();
            //      Task.Run(async () => await program.PostData());
            program. GetDataAsync().Wait();
            //            Console.WriteLine(r.Result.ToString());

        }

        public     async void   ConnectAsync()
        {
            try
            {

                LoginModel loginModel = new LoginModel
                {
                    Grant_type = "authorization_code",
                    Client_id = "0310e975-e3ea-4416-b6d9-cc4659079746",
                    Client_secret = "de86e9f3-47b7-43f3-9e8f-6b072d0ff009",
                    Code = "OAUTH2.eyJraWQiOiJWUTQwMVRlWiIsImFsZyI6IkhTMjU2In0.eyJkYXRhIjoie1wiYXBwSWRcIjpcIjAzMTBlOTc1LWUzZWEtNDQxNi1iNmQ5LWNjNDY1OTA3OTc0NlwiLFwiaW5zdGFuY2VJZFwiOlwiNjIzN2M2MzUtOTEwMC00NjZkLTk3ZTQtMDQ2NzI4N2E1NWY2XCIsXCJzY29wZVwiOltcIlNDT1BFLkRDLVNUT1JFUy1NRUdBLk1BTkFHRS1TVE9SRVNcIixcIlNDT1BFLkRDLk1BTkFHRS1ZT1VSLUFQUFwiLFwiU0NPUEUuREMtU1RPUkVTLk1BTkFHRS1QUk9EVUNUU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtT1JERVJTXCIsXCJTQ09QRS5EQy1TVE9SRVMtTUVHQS5SRUFELVNUT1JFU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtUFJPRFVDVFNcIixcIlNDT1BFLkRDLVNUT1JFUy5NQU5BR0UtT1JERVJTXCJdfSIsImlhdCI6MTY2ODkzNTU5MywiZXhwIjoxNjY4OTM2MTkzfQ.MMVC81FZgyYSzsg08aTb3TsWeqsfq0ckzL7Emarie7g"
                };

                var request = new RestRequest()
                //.AddQueryParameter("foo", "bar")
                .AddJsonBody(loginModel);
                request.AddHeader("Content-Type", "application/json");

                var client = new RestClient(BaseUrl);
                 
               var result=       client.PostAsync<LoginReply>(request, cancellationToken);

            var k=    result.GetAwaiter().GetResult().refresh_token;

                if (result!=null)
                {
                 //     Console.WriteLine(result.access_token);
                   // throw new HttpException($"Item not found: {result.ErrorMessage}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }

        //private static string APIUrl = "http://localhost:7005/orderapi/";
        //public static void GetDataWithoutAuthentication()
        //{
        //    using (var client = new WebClient())
        //    {
        //        client.Headers.Add("Content-Type:application/json");
        //        client.Headers.Add("Accept:application/json");

        //        var result = client.DownloadString(APIUrl);
        //        Console.WriteLine(Environment.NewLine + result);
        //    }
        //}

        private static string APIUrl = "https://www.wixapis.com/oauth/access";
        public static async void GetDataWithoutAuthentication()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(APIUrl);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse);
                }
                Console.WriteLine("Complete");
            }
        }
        public   async Task GetDataAsync() //method added by me.
        {
            Uri x = await PostData();
        }
        public   async Task<Uri> PostData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                LoginModel loginModel = new LoginModel
                {
                    Grant_type = "authorization_code",
                    Client_id = "0310e975-e3ea-4416-b6d9-cc4659079746",
                    Client_secret = "de86e9f3-47b7-43f3-9e8f-6b072d0ff009",
                    Code = "OAUTH2.eyJraWQiOiJWUTQwMVRlWiIsImFsZyI6IkhTMjU2In0.eyJkYXRhIjoie1wiYXBwSWRcIjpcIjAzMTBlOTc1LWUzZWEtNDQxNi1iNmQ5LWNjNDY1OTA3OTc0NlwiLFwiaW5zdGFuY2VJZFwiOlwiNjIzN2M2MzUtOTEwMC00NjZkLTk3ZTQtMDQ2NzI4N2E1NWY2XCIsXCJzY29wZVwiOltcIlNDT1BFLkRDLVNUT1JFUy1NRUdBLk1BTkFHRS1TVE9SRVNcIixcIlNDT1BFLkRDLk1BTkFHRS1ZT1VSLUFQUFwiLFwiU0NPUEUuREMtU1RPUkVTLk1BTkFHRS1QUk9EVUNUU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtT1JERVJTXCIsXCJTQ09QRS5EQy1TVE9SRVMtTUVHQS5SRUFELVNUT1JFU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtUFJPRFVDVFNcIixcIlNDT1BFLkRDLVNUT1JFUy5NQU5BR0UtT1JERVJTXCJdfSIsImlhdCI6MTY2ODkzNTU5MywiZXhwIjoxNjY4OTM2MTkzfQ.MMVC81FZgyYSzsg08aTb3TsWeqsfq0ckzL7Emarie7g"
                };

                var dataAsString = JsonConvert.SerializeObject(loginModel);
                var dataContent = new StringContent(dataAsString);
                HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "CreateOrder", dataContent);
                Uri ncrUrl= null;
                if (response.IsSuccessStatusCode)
                {
                      ncrUrl = response.Headers.Location;
                    Console.WriteLine("Posting Complete");
                }
                return ncrUrl;
                Console.WriteLine("Complete");
            }
        }

        public bool GetWixSales()
        {
            //check communication 

            //fetch  sales

            //get cnet article id

            //adjust cnet stock table

            return true; 
        }

        public bool UpdateWixItemInfo()
        {
            //initiate communication

            //fetch all modified articles

            //go through all fetched items and updte stockk amount, price and description

            //

            return false;
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
