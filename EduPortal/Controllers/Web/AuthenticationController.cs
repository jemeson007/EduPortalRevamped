using EduPortal.Client;
using EduPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EduPortal.Core.ViewModels;

namespace EduPortal.Controllers.Web
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        public ActionResult Register()
        {
            if(isAuthenticated())
            {
                ViewBag.Schools = SchoolClient.GetAll(RetrieveKeys("school"));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterBindingModel item)
        {
            var result=AuthenticationClient.Register(item);
            if(result)
            {
                return RedirectToAction("Index", "School");
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
                return RedirectToAction("Index", "School");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var result=AuthenticationClient.Logout(Session["accesskey"].ToString());
            if(result==true)
            {
                Session.RemoveAll();
                return RedirectToAction("Login");
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}