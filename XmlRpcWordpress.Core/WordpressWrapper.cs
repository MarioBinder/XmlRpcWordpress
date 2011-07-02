using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CookComputing.XmlRpc;
using XmlRpcWordpress.Core.Models;

namespace XmlRpcWordpress
{
    public class WordpressWrapper : XmlRpcClientProtocol
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int BlogId { get; set; }

        public WordpressWrapper() { }
        public WordpressWrapper(IAuthentification auth) 
        {
            SetAuth(auth.Username, auth.Password, auth.Url); 
        }
        public WordpressWrapper(string username, string password, string url)
        { 
            SetAuth(username, password, url);
        }

        public void SetAuth(string username, string password, string url)
        {
            BlogId = BlogId <= 0 ? 1 : BlogId;
            Username = username;
            Password = password;

            url += !url.EndsWith("\x002F") ? "\x002F" : "";
            this.Url = url + @"xmlrpc.php";
        }

        public IAsyncResult BeginGetUserInfo(AsyncCallback acb)
        {
            return BeginGetUserInfo("", Username, Password, acb);
        }
        [XmlRpcBegin("blogger.getUserInfo")]
        private IAsyncResult BeginGetUserInfo(string key, string username, string password, AsyncCallback acb)
        {
            return this.BeginInvoke(MethodBase.GetCurrentMethod(), new object[] { key, username, password }, acb, null);
        }
        [XmlRpcEnd]
        public UserInfo EndGetUserInfo(IAsyncResult iasr)
        {
            var res = (XmlRpcStruct)this.EndInvoke(iasr);
            return XmlRpcStructToEntity<UserInfo, object>(res);
        }

        #region blogposts
        //recentposts ----------------------------------------------------------------------------------------------------------
        public IAsyncResult BeginGetRecentPost(AsyncCallback acb)
        {
            return BeginGetRecentPost(string.Empty, Username, Password, acb);
        }
        [XmlRpcBegin("metaWeblog.getRecentPosts")]
        private IAsyncResult BeginGetRecentPost(string key, string username, string password, AsyncCallback acb)
        {
            return this.BeginInvoke(MethodBase.GetCurrentMethod(), new object[] { key, username, password }, acb, null);
        }
        [XmlRpcEnd]
        public List<BlogPost> EndGetRecentPost(IAsyncResult iasr)
        {
            var res = (XmlRpcStruct[])this.EndInvoke(iasr);
            return XmlRpcStructToEntity<BlogPost, CustomField>(res);
        }


        //post ------------------------------------------------------------------------------------------------------------------
        public IAsyncResult BeginGetPost(int postid, AsyncCallback acb)
        {
            return BeginGetPost(postid, Username, Password, acb);
        }
        [XmlRpcBegin("metaWeblog.getPost")]
        private IAsyncResult BeginGetPost(int postId, string username, string password, AsyncCallback acb)
        {
            return this.BeginInvoke(MethodBase.GetCurrentMethod(), new object[] { postId, username, password }, acb, null);
        }
        [XmlRpcEnd]
        public BlogPost EndGetPost(IAsyncResult iasr)
        {
            var res = (XmlRpcStruct)this.EndInvoke(iasr);
            return XmlRpcStructToEntity<BlogPost, CustomField>(res);
        }
        #endregion




        //helper ----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// cast a XmlRpcStruct Array into a List of T 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2">for another type inside T</typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        private List<T1> XmlRpcStructToEntity<T1, T2>(XmlRpcStruct[] values)
        {
            var liste = values.Select(item => XmlRpcStructToEntity<T1, T2>(item)).ToList();
            return liste;
        }
        private T1 XmlRpcStructToEntity<T1, T2>(XmlRpcStruct value)
        {
            T1 t = (T1)Activator.CreateInstance(typeof(T1));

            foreach (DictionaryEntry i in value)
            {
                PropertyInfo property = typeof(T1).GetProperty(i.Key.ToString());
                if (property == null) continue;

                if (property.PropertyType == typeof(List<T2>))
                {
                    List<T2> t2 = (List<T2>)Activator.CreateInstance(typeof(List<T2>));
                    t2 = XmlRpcStructToEntity<T2, object>(i.Value as XmlRpcStruct[]);
                    SetProperty(t, property.Name, t2);
                }
                else
                    SetProperty(t, property.Name, i.Value);
            }
            return t;
        }
        private void SetProperty(object cObject, string propertyName, object newValue)
        {
            cObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, cObject, new object[] { newValue });
        }



    }
}
