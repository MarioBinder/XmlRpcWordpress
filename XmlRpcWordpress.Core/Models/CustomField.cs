using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace XmlRpcWordpress.Core.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CustomField
    {
        public string id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
}
