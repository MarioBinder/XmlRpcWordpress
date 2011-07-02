using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRpcWordpress
{
    public interface IAuthentification
    {
        string Username { get; set; }
        string Password { get; set; }
        string Url { get; set; }

        IAuthentification GetAuthentification();
    }
}
