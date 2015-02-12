using EduPortal.Client;
using EduPortal.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class LectureController : BaseController
    {
        private string _resourceName = "lecture";
        
        //
        // GET: /Lecture/
        public ActionResult Index()
        {
            if (isAuthenticated())
            {
                var lectures = JsonConvert.DeserializeObject<List<Lecture>>(Client<Lecture>.GetAll(RetrieveKeys(_resourceName)));
                return View(lectures);
            }
            return RedirectToLogin();
        }

        //
        // GET: /Lecture/Details/5
        public ActionResult Details(int id)
        {
            if (isAuthenticated())
            {
                var lecture = JsonConvert.DeserializeObject<Lecture>(Client<Lecture>.Get(id, RetrieveKeys(_resourceName)));
                return View(lecture);
            }
            return RedirectToLogin();
        }

        //
        // GET: /Lecture/Create
        public ActionResult Create()
        {
            if (isAuthenticated())
            {
                ViewBag.Subject = JsonConvert.DeserializeObject<List<Subject>>(Client<Subject>.GetAll(RetrieveKeys("subject")));
                return View();
            }
            return RedirectToLogin();
        }

        //
        // POST: /Lecture/Create
        [HttpPost]
        public ActionResult Create(Lecture lecture)
        {
           if(isAuthenticated())
           {
                if (Client<Lecture>.Create(lecture,RetrieveKeys(_resourceName)))
                {
                    return RedirectToAction("Create", "LectureNote");
                }
               return View();
            }
           return RedirectToLogin();
        }

        //
        // GET: /Lecture/Edit/5
        public ActionResult Edit(int id)
        {
            if (isAuthenticated())
            {
                var lecture = JsonConvert.DeserializeObject<Lecture>(Client<Lecture>.Get(id, RetrieveKeys(_resourceName)));
                return View(lecture);
            }
            return RedirectToLogin();
        }

        //
        // POST: /Lecture/Edit/5
        [HttpPost]
        public ActionResult Edit(Lecture lecture)
        {
            if (isAuthenticated())
            {
                if (Client<Lecture>.Update(lecture, RetrieveKeys(_resourceName)))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            return RedirectToLogin();
        }

        //
        // GET: /Lecture/EnableorDisable/5
        public ActionResult EnableorDisable(int id)
        {
            if (isAuthenticated())
            {
                var lecture = JsonConvert.DeserializeObject<Lecture>(Client<Lecture>.Get(id, RetrieveKeys(_resourceName)));
                lecture.IsActive = !lecture.IsActive;
                if (Client<Lecture>.Update(lecture, RetrieveKeys(_resourceName)))
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
                return View();
            }
            return RedirectToLogin();
        }
    }
}
