using EduPortal.Client;
using EduPortal.Core.Entity;
using EduPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class SchoolController : BaseController
    {
        private string _resourceName = "school";
        // GET: School
        public ActionResult Index()
        {
            if(isAuthenticated())
            {
                List<School> branches = JsonConvert.DeserializeObject<List<School>>(SchoolClient.GetAll(RetrieveKeys(_resourceName)));
                return View(branches);
            }
            return RedirectToLogin();
        }

        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            if (isAuthenticated())
            {
                var school = JsonConvert.DeserializeObject<School>(SchoolClient.Get(id, RetrieveKeys(_resourceName)));
                return View(school);
            }
            return RedirectToLogin();
        }

        // GET: School/Create
        public ActionResult Create()
        {
            if (isAuthenticated())
            {
                return View();
                
            }
            return RedirectToLogin(); 
        }

        // POST: School/Create
        [HttpPost]
        public ActionResult Create(School school)
        {
            if (isAuthenticated())
            {
                string pword = "P@ssw0rd";
                RegisterBindingModel user = new RegisterBindingModel() { School = school.Name, Email = school.AdminEmail, Password = pword, ConfirmPassword = pword };
                var userResult = AuthenticationClient.Register(user);
                if (userResult)
                {
                    return RedirectToAction("Index");
                }
                return View(school);
            }
            return RedirectToLogin();
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            if (isAuthenticated())
            {
                var school = JsonConvert.DeserializeObject<School>(SchoolClient.Get(id, RetrieveKeys(_resourceName)));
                return View(school);
            }
            return RedirectToLogin();
        }

        // POST: School/Edit/5
        [HttpPost]
        public ActionResult Edit(School school)
        {
            if (isAuthenticated())
            {
                var result = SchoolClient.Update(school, RetrieveKeys(_resourceName));
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return View(school);
            }
            return RedirectToLogin();
            
        }
        public ActionResult EnableorDisable(int id)
        {
            if (isAuthenticated())
            {
                School result = JsonConvert.DeserializeObject<School>(SchoolClient.Get(id, RetrieveKeys(_resourceName)));
                result.IsActive = !result.IsActive;
                SchoolClient.Update(result, RetrieveKeys(_resourceName));
                return Redirect(Request.UrlReferrer.ToString());
            }
            return RedirectToLogin();
        }
       
    }
}
