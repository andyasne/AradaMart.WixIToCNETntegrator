namespace AradaMart.WixIToCNETntegrator
{
    public class LoginModel
    {
         
        public LoginModel()
        {
        }

        public string Grant_type { get; internal set; }
        public string Client_secret { get; internal set; }
        public string Client_id { get; internal set; }
        public string Code { get; internal set; }
    }
}