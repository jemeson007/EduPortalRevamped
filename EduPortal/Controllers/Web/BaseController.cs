using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class BaseController : Controller
    {
       public bool isAuthenticated()
       {
           if(Session["key"]!=null&& Session["accesskey"]!=null && Session["userName"]!=null)
           {
               return true;
           }
           return false;
       }
        public ActionResult RedirectToLogin()
        {
            return RedirectToAction("Login","Authentication");
        }
        
       public IDictionary<string,string>  RetrieveKeys(string _resource)
       {
           if(isAuthenticated())
           {
               IDictionary<string,string> result= new Dictionary<string,string>();
               result.Add("key",Session["key"].ToString());
               result.Add("accesskey", Session["accesskey"].ToString());
               result.Add("resource",_resource);
               return result;
           }
           return null;
       }
    }
}