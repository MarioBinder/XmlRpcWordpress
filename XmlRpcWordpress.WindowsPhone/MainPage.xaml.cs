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

        void GetUserInfoCallback(IAsyncResult result)
        {
            UserInfo = wp.EndGetUserInfo(result);
        }

        void GetBlogPostCallback(IAsyncResult result)
        {
            BlogPosts = new List<BlogPost>();
            BlogPosts = wp.EndGetRecentPost(result);
        }


        // Konstruktor
        public MainPage()
        {
            InitializeComponent();

            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            var url = ConfigurationManager.AppSettings["url"];

            wp = new WordpressWrapper(username, password, url);

            wp.BeginGetUserInfo(GetUserInfoCallback);
            wp.BeginGetRecentPost(GetBlogPostCallback);


            this.DataContext = this;
        }
    }
}