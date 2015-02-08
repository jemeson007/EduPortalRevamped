using EduPortal.Core.Entity;
using EduPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Client
{
    public class SchoolSystem
    {
        protected ApplicationDbContext _context;

        public SchoolSystem()
        {
            _context = new ApplicationDbContext();
        }
        public School Save(School obj)
        {
            _context.Set<School>().Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public School Update(School obj)
        {
            School existing = _context.Set<School>().Find(obj.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
            return existing;
        }

        public IEnumerable<School> RetrieveAll()
        {
            return _context.Set<School>().ToList();
        }
        public School RetrieveBy(long id)
        {
            return _context.Set<School>().Find(id);
        }
    }

    public class SchoolClient
    {
        
              
        
        static string auth = ConfigurationManager.AppSettings["Authorization"];
        public static string _baseAddress = ConfigurationManager.AppSettings["Api"];
        public static string GetAll(string resourceName)
        {
                    
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",auth);
                client.BaseAddress = new Uri(_baseAddress);
                string result = client.GetStringAsync("api/" + resourceName).Result.ToString();
                return result;
            }
        }
        public static string Get(long id, string resourceName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                client.BaseAddress = new Uri(_baseAddress);
                string result = client.GetStringAsync("api/" + resourceName + "/" + id).Result.ToString();
                return result;
            }
        }
        public static bool Create(School item, string resourceName)
        {
            // TODO: Add insert logic here
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                client.BaseAddress = new Uri(_baseAddress);
                var result = client.PostAsync("api/" + resourceName , item, new JsonMediaTypeFormatter()).Result;
                return result.IsSuccessStatusCode;
            }
        }

        public static bool Update(Base item, string resourceName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                client.BaseAddress = new Uri(_baseAddress);
                var result = client.PutAsync("api/" + resourceName, item, new JsonMediaTypeFormatter()).Result;
                return result.IsSuccessStatusCode;
            }
        }
    }
}
