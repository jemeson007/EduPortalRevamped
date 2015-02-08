using EduPortal.Client;
using EduPortal.Core.ViewModels;
using EduPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class AuthenticationController : BaseController
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterBindingModel item)
        {
            var result=AuthenticationClient.Register(item);
            if(result)
            {
                return RedirectToAction("Index", "Branch");
            }
            return View(item);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel item)
        {
            var result = AuthenticationClient.Login(item);
            
            if (result.ContainsKey("key")&&result.ContainsKey("access_token"))
            {
                Session.Add("key", result["key"]);
                Session.Add("accesskey", result["access_token"]);
                Session.Add("username",result["userName"]);
                return RedirectToAction("Index", "Branch");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var result=AuthenticationClient.Logout();
            if(result==true)
            {
                Session.RemoveAll();
                return RedirectToAction("Login");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}