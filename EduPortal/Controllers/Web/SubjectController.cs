using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using EduPortal.Client;
using EduPortal.Core.Entity;
using Newtonsoft.Json;


namespace EduPortal.Controllers.Web
{
    public class SubjectController : BaseController
    {
        private string _resourceName = "subject";
        //
        // GET: /Subject/
        public ActionResult Index()
        {
            if (isAuthenticated())
            {
                var subjects = JsonConvert.DeserializeObject<List<Subject>>(Client<Subject>.GetAll(RetrieveKeys(_resourceName)));
                return View(subjects);
            }
            return RedirectToLogin();
        }

        //
        // GET: /Subject/Details/5
        public ActionResult Details(int id)
        {
            if (isAuthenticated())
            {
                var result = JsonConvert.DeserializeObject<Subject>(Client<Subject>.Get(id, RetrieveKeys(_resourceName)));
                return View(result);
            }
            return RedirectToLogin();
        }

        //
        // GET: /Subject/Create
        public ActionResult Create()
        {
            if(isAuthenticated())
            {
                ViewBag.ClassLevel = JsonConvert.DeserializeObject<List<ClassLevel>>(Client<ClassLevel>.GetAll(RetrieveKeys("classlevel")));
                return View();
            }
            return RedirectToLogin();
        }

        //
        // POST: /Subject/Create
        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            if (Client<Subject>.Create(subject,RetrieveKeys(_resourceName)))
            {
                return RedirectToAction("Index");
            }
                return View(subject);
        }

        //
        // GET: /Subject/Edit/5
        public ActionResult Edit(int id)
        {
            if(isAuthenticated())
            {
                var subject = JsonConvert.DeserializeObject<Subject>(Client<Subject>.Get(id, RetrieveKeys(_resourceName)));
                return View(subject);
            }
            return RedirectToLogin();
        }

        //
        // POST: /Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            if (isAuthenticated())
            {
                if (Client<Subject>.Update(subject, RetrieveKeys(_resourceName)))
                {
                    return RedirectToAction("Index");
                }
                return View(subject);
            }
            return RedirectToLogin();
                  
        }

        //
        // GET: /Subject/Delete/5
        public ActionResult EnableorDisable(int id,string key)
        {
            if (isAuthenticated())
            {
                var subject = JsonConvert.DeserializeObject<Subject>(Client<Subject>.Get(id, RetrieveKeys(_resourceName)));
                subject.IsActive = !subject.IsActive;
                if (Client<Subject>.Update(subject, RetrieveKeys(_resourceName)))
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                return View();
            }
            return RedirectToLogin();
        }
    }
}
