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
using Flurl;
namespace AradaMart.WixIToCNETntegrator
{
    public class Program
    {
        private const string URL_access = "https://www.wixapis.com/oauth/access";
        private const string authCode = "OAUTH2.eyJraWQiOiJWUTQwMVRlWiIsImFsZyI6IkhTMjU2In0.eyJkYXRhIjoie1wiYXBwSWRcIjpcIjAzMTBlOTc1LWUzZWEtNDQxNi1iNmQ5LWNjNDY1OTA3OTc0NlwiLFwiaW5zdGFuY2VJZFwiOlwiNjIzN2M2MzUtOTEwMC00NjZkLTk3ZTQtMDQ2NzI4N2E1NWY2XCIsXCJzY29wZVwiOltcIlNDT1BFLkRDLVNUT1JFUy1NRUdBLk1BTkFHRS1TVE9SRVNcIixcIlNDT1BFLkRDLk1BTkFHRS1ZT1VSLUFQUFwiLFwiU0NPUEUuREMtU1RPUkVTLk1BTkFHRS1QUk9EVUNUU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtT1JERVJTXCIsXCJTQ09QRS5EQy1TVE9SRVMtTUVHQS5SRUFELVNUT1JFU1wiLFwiU0NPUEUuREMtU1RPUkVTLlJFQUQtUFJPRFVDVFNcIixcIlNDT1BFLkRDLVNUT1JFUy5NQU5BR0UtT1JERVJTXCJdfSIsImlhdCI6MTY2OTE0NzE4MywiZXhwIjoxNjY5MTQ3NzgzfQ.70ywfiSsD27ciZXOOMf_tA8CCJkaY8V3ZZzE-RJ1S-M";

        static void Main()
        {
            Program program = new Program();
            program.AuthWix();

        }

        private string  AuthWix()
        {
            LoginModel loginModel = InitializeLoginModel();

            var client = new RestClient();
            var request = new RestRequest(URL_access, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", loginModel, ParameterType.RequestBody);
            var response = client.Execute(request);

            LoginReply loginReply = System.Text.Json.JsonSerializer.Deserialize<LoginReply>(response.Content);

            return response.Content;

        }

        private static LoginModel InitializeLoginModel()
        {
            return new LoginModel
            {
                grant_type = "authorization_code",
                client_id = "0310e975-e3ea-4416-b6d9-cc4659079746",
                client_secret = "de86e9f3-47b7-43f3-9e8f-6b072d0ff009",
                code = authCode
            };
        }

    }

    public class LoginModel
    {

        public LoginModel()
        {
        }

        public string grant_type { get; internal set; }
        public string client_secret { get; internal set; }
        public string client_id { get; internal set; }
        public string code { get; internal set; }
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
