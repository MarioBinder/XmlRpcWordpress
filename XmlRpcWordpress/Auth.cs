using System.Configuration;

namespace XmlRpcWordpress
{
    public class Auth : IAuthentification
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public IAuthentification GetAuthentification()
        {
            return new Auth
            {
                Username = ConfigurationManager.AppSettings.Get("username"),
                Password = ConfigurationManager.AppSettings.Get("password"),
                Url = ConfigurationManager.AppSettings.Get("url"),
            };
        }
    }
}
