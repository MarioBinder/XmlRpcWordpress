using CookComputing.XmlRpc;

namespace XmlRpcWordpress.Core.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class UserInfo
    {
        public string nickname { get; set; }
        public string userid { get; set; }
        public string url { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
    }
}
