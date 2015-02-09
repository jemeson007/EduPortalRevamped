using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace EduPortal.Client
{
    public class Client<Base>
    {
        public static string _baseAddress = ConfigurationManager.AppSettings["Api"];

        //static string auth = ConfigurationManager.AppSettings["Authorization"];

        public static bool Create(Base item,IDictionary<string,string> input)
        {
            if(isValid(input))
            { // TODO: Add insert logic here
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", input["accesskey"]);
                client.BaseAddress = new Uri(_baseAddress);
                
                var result = client.PostAsync("api/" + input["resource"]+"?key="+input["key"], item, new JsonMediaTypeFormatter()).Result;
                return result.IsSuccessStatusCode;
            }
        }
            throw new Exception("You are not permitted to view this resource");
         }

        public static bool Update(Base item,IDictionary<string,string> input)
        {
            if(isValid(input)){

            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", input["accesskey"]);
                client.BaseAddress = new Uri(_baseAddress);
                var result = client.PutAsync("api/" + input["resource"] + "?key=" + input["key"], item, new JsonMediaTypeFormatter()).Result;
                return result.IsSuccessStatusCode;
            }
        }
            throw new Exception("You are not permitted to view this resource");
        }

        public static string Get(long id, IDictionary<string, string> input)
        {
            if (isValid(input))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", input["accesskey"]);
                    client.BaseAddress = new Uri(_baseAddress);
                    string result = client.GetStringAsync("api/" + input["resource"] + "/" + id + "?key=" + input["key"]).Result.ToString();
                    return result;
                }
            }
            throw new Exception("You are not permitted to view this resource");
        }

        public static string GetAll(IDictionary<string,string> input)
        {
            if(isValid(input))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", input["accesskey"]);
                    client.BaseAddress = new Uri(_baseAddress);
                    string result = client.GetStringAsync("api/" + input["resource"] + "?key=" + input["key"]).Result.ToString();
                    return result;
                }
            }
            throw new Exception("You are not permitted to view this resource");
            
        }
        public static bool isValid(IDictionary<string,string> input)
        {
            return input.ContainsKey("key") && input.ContainsKey("accesskey") && input.ContainsKey("resource");
        }
        
    }
}