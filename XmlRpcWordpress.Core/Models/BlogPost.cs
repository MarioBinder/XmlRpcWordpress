using System;
using System.Collections.Generic;
using CookComputing.XmlRpc;

namespace XmlRpcWordpress.Core.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class BlogPost
    {
        public string wp_post_format { get; set; }
        public string wp_author_id { get; set; }
        public string postid { get; set; }
        public int mt_allow_pings { get; set; }
        public string mt_text_more { get; set; }
        public string userid { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public string wp_author_display_name { get; set; }
        public string post_status { get; set; }
        public string mt_excerpt { get; set; }
        public string title { get; set; }
        public string wp_password { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public string[] categories { get; set; }
        public string link { get; set; }
        public string wp_slug { get; set; }
        public int mt_allow_comments { get; set; }
        public string mt_keywords { get; set; }
        public DateTime date_created_gmt { get; set; }
        public string permaLink { get; set; }
    }
}
