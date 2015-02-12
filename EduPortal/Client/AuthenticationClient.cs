using EduPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using EduPortal.Core.ViewModels;

namespace EduPortal.Client
{
    public class AuthenticationClient
    {
        public static string _baseAddress = ConfigurationManager.AppSettings.GetValues("WebsiteURL")[0];
        //static string auth = ConfigurationManager.AppSettings["Authorization"];
        public static bool Register(RegisterBindingModel item)
        {
            // TODO: Add insert logic here
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var result = client.PostAsync("api/Account/Register", item, new JsonMediaTypeFormatter()).Result;
                return result.IsSuccessStatusCode;
            }
        }

        public static IDictionary<String,String> Login(LoginViewModel item)
        {
            IDictionary<String,String> stuff= new Dictionary<String,String>();
            // TODO: Add insert logic here
            using (var client = new HttpClient())        
            {
                client.BaseAddress = new Uri(_baseAddress);
                //client.DefaultRequestHeaders.Add("Content-Type", new ();
                var result = client.PostAsync("Token", new StringContent(item.ToString())).Result;
                var keys =  result.Content.ReadAsAsync<IDictionary<String,String>>().Result;
                //Session
                return keys;
            }
        }
        public static bool Logout(string auth_key)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",auth_key);
                var result = client.PostAsync("api/Account/logout",null).Result;
                return result.IsSuccessStatusCode;
            }
        }
    }
}