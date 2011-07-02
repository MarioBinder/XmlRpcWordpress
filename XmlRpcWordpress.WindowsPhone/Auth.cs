using XmlRpcWordpress.WindowsPhone.Helper;

namespace XmlRpcWordpress.WindowsPhone
{
    public  class Auth : IAuthentification
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }

        public IAuthentification GetAuthentification()
        {
            return new Auth
            {
                Username = ConfigurationManager.AppSettings["username"],
                Password = ConfigurationManager.AppSettings["password"],
                Url = ConfigurationManager.AppSettings["url"]
            };
        }
    }
}
