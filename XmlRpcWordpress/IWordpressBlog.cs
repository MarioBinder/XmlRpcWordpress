using System;
using CookComputing.XmlRpc;

namespace XmlRpcWordpress
{
    /// <summary>
    /// used http://codex.wordpress.org/XML-RPC_wp
    /// </summary>
    public interface IWordpressBlog : IXmlRpcProxy
    {
        #region BlogPost
        [XmlRpcMethod("metaWeblog.newPost")]
        string CreatePost(int blog_id, string username, string password, Content content, bool publish);

        [XmlRpcMethod("metaWeblog.newMediaObject")]
        MediaObjectResult NewMediaObject(int blogId, string username, string password, MediaObject mediaObject);

        [XmlRpcMethod("metaWeblog.editPost ")]
        bool EditPost(string postid, string username, string password, Content content, bool publish);

        [XmlRpcMethod("metaWeblog.deletePost")]
        bool DeletePost(string appKey, string postid, string username, string password, bool publish);

        [XmlRpcMethod("metaWeblog.getPost")]
        BlogPost GetPost(int postid, string username, string password);

        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        BlogPost[] GetRecentPosts(int blogId, string username, string password, int numberOfPosts);
        #endregion

        #region common
        [XmlRpcMethod("mt.supportedMethods")]
        object GetSupportedMethods();

        [XmlRpcMethod("wp.getOptions")]
        object GetOptions(int blogId, string username, string password, string[] options);
        
        [XmlRpcMethod("metaWeblog.getUsersBlogs")]
        object[] GetUserBlogs(string appkey, string username, string password);

        [XmlRpcMethod("blogger.getUserInfo")]
        object GetUserInfo(string appKey, string username, string password);
        #endregion
        
        #region Categories, Keywords
        [XmlRpcMethod("wp.getCategories")]
        Category[] GetCategories(int blogId, string username, string password);

        [XmlRpcMethod("wp.getTags")]
        Tag[] GetTags(int blogId, string username, string password);
        #endregion
        
        #region Comments
        [XmlRpcMethod("wp.getCommentCount")]
        CommentCount GetCommentCount(int blog_id, string username, string password, string postId);

        [XmlRpcMethod("wp.getComments")]
        Comment[] GetComments(int blogId, string username, string password, CommentFilter commentMeta);

        [XmlRpcMethod("wp.deleteComment")]
        bool DeleteComment(int blogId, string username, string password, int commentId);

        [XmlRpcMethod("wp.getCommentStatusList")]
        object GetCommentStatusList(int blogId, string username, string password);

      

        #endregion
    }
    
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaObject
    {
        public byte[] bits;
        public string name;
        public string type;
        public bool overwrite;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaObjectResult
    {
        public string url { get; set; }
        public string file { get; set; }
        public string type { get; set; }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CommentFilter
    {
        public int post_Id;
        public string status;
        public int offset;
        public int number;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Comment
    {
        public DateTime dateCreated;
        public string user_id;
        public string comment_id;
        public string parent;
        public string status;
        public string content;
        public string link;
        public string post_id;
        public string post_title;
        public string author;
        public string author_url;
        public string author_email;
        public string author_ip;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class BlogPost
    {
        public string wp_post_format;
        public string wp_author_id;
        public string postId;
        public int mt_allow_pings;
        public string mt_text_more;
        public string userid;
        public CustomFields[] custom_fields;
        public string wp_author_display_name;
        public string post_status;
        public string mt_excerpt;
        public string title;
        public string wp_Password;
        public string description;
        public DateTime dateCreated;
        public string[] categories;
        public string link;
        public string wp_slug;
        public int mt_allow_comments;
        public string mt_keywords;
        public DateTime date_created_gmt;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CustomFields
    {
        public string id;
        public string key;
        public string value;
    }


    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Option
    {
        public string option;
        public string value;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Content
    {
        public string title;
        public string description;
        public DateTime dateCreated;
        public string[] categories;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CommentCount
    {
        public string approved;
        public int awaiting_moderation;
        public int spam;
        public int total_comments;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Category
    {
        public string categoryName;
        public string parentId;
        public string description;
        public string rssUrl;
        public string categoryDescription;
        public string htmlUrl;
        public string categoryId;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Tag
    {
        public string tag_id;
        public string name;
        public string count;
        public string slug;
        public string html_url;
        public string rss_url;
    }

}
