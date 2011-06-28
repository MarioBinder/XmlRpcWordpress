using System;
using System.Collections.Generic;
using System.Windows;
using XmlRpcWordpress.Core.Models;
using System.Configuration;

namespace XmlRpcWordpress
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();

            var username = ConfigurationManager.AppSettings.Get("username");
            var password = ConfigurationManager.AppSettings.Get("password");
            var url = ConfigurationManager.AppSettings.Get("url");
            wp = new WordpressWrapper(username, password, url);
            
            wp.BeginGetUserInfo(GetUserInfoCallback);
            wp.BeginGetRecentPost(GetBlogPostCallback);


            //wp.BeginGetUserInfo(asr => Dispatcher.Invoke(
            //    () => UserInfo = wp.EndGetUserInfo(asr)));


            //wp.BeginGetRecentPost(asr => Dispatcher.BeginInvoke(
            //    () => BlogPosts = wp.EndGetRecentPost(asr)));



            //UserInfo ermitteln
            //var userInfo = wp.GetUserInfo();

            
            ////Ermitteln der verfügbaren Blogs
            //var blogs = wp.GetUserBlogs();


            ////Ermitteln der KommentarStatus
            //var commentStatusList = wp.GetCommentStatusList();

            ////Ermitteln der Kommentareanzahl
            //var commentCount = wp.GetCommentCount("6500");


            ////Ermitteln der Kategorien
            //var categories = wp.GetCategories();



            ////Ermitteln der Spam Kommentare
            //CommentFilter filter = new CommentFilter { post_Id = 6500, status = "spam", offset = 0, number = 200};
            //Comment[] comments = wp.GetComments(filter);

            ////Filtern der Spamkommentare
            //var res = (from c in comments
            //           where c.content.Contains("appreciate")
            //          select c).ToList();

            ////Loeschen der Spamkommentare
            //foreach (var comment in res)
            //{
            //    wp.DeleteComment(Convert.ToInt32(comment.comment_id));
            //}



            //Speichern eines MediaObjektes
            //var url = wp.SaveMedia(@"C:\Users\sx\Pictures\Von WindowsPhone\Gespeicherte Bilder\userupload.jpg", false);


            ////Erstellen eines Blogartikels
            //var content = new Content()
            //{
            //    title = "Test from XML-RPC",
            //    description = "This is a Text from my Desktop Client",
            //    dateCreated = DateTime.UtcNow,
            //    categories = new string[] { "Test" }
            //};
            //var result = wp.CreatePost(content, false);




            ////Editieren eines Blogartikels
            //content = new Content()
            //{
            //    title = "Test from XML-RPC 23",
            //    description = "This is a Text from my Desktop Client 23",
            //    dateCreated = DateTime.UtcNow,
            //    categories = new string[] { "Test" }
            //};
            //var editResult = wp.EditPost(result, content, false);

            ////Löschen eines Blogartikel
            //var deleteResult = wp.DeletePost(result);



            ////Ermitteln der letzten n Posts
            //var result = wp.GetRecentPosts(20);

            ////Ermitteln eines BlogPosts
            //var blogPost = wp.GetPost(6500);



            ////Ermitteln der verfuegbaren Tags
            //var tags = wp.GetTags();

            ////Optionen ermitteln
            //var options = wp.GetOptions();
            //var options2 = wp.GetOptions(new string[] { "time_zone" });





            //var supportedMethods = wp.GetSupportedMethods();




        }


    }



}
