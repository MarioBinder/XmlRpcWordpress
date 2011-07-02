using System;
using System.Collections.Generic;
using Microsoft.Phone.Controls;
using XmlRpcWordpress.Core.Models;
using XmlRpcWordpress.WindowsPhone.Helper;

namespace XmlRpcWordpress.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        private WordpressWrapper wp;

        public UserInfo UserInfo { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public BlogPost Post { get; set; }

        void GetUserInfoCallback(IAsyncResult result)
        {
            UserInfo = wp.EndGetUserInfo(result);
        }

        void GetBlogPostCallback(IAsyncResult result)
        {
            BlogPosts = new List<BlogPost>();
            BlogPosts = wp.EndGetRecentPost(result);
        }

        void GetPostCallback(IAsyncResult result)
        {
            Post = wp.EndGetPost(result);
        }


        
        public MainPage()
        {
            InitializeComponent();            
            wp = new WordpressWrapper(new Auth().GetAuthentification());

            wp.BeginGetUserInfo(GetUserInfoCallback);
            wp.BeginGetRecentPost(GetBlogPostCallback);
            wp.BeginGetPost(6500, GetPostCallback);

            this.DataContext = this;
        }
    }
}