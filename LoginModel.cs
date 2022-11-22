namespace AradaMart.WixIToCNETntegrator
{
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
}