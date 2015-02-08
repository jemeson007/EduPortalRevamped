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
        public ActionResult Index(string key)
        {
            var lectures = JsonConvert.DeserializeObject<List<Lecture>>(Client<Lecture>.GetAll(RetrieveKeys(_resourceName)));
            return View(lectures);
        }

        //
        // GET: /Lecture/Details/5
        public ActionResult Details(int id,string key)
        {
            var lecture = JsonConvert.DeserializeObject<Lecture>(Client<Lecture>.Get(id, RetrieveKeys(_resourceName)));
            return View(lecture);
        }

        //
        // GET: /Lecture/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lecture/Create
        [HttpPost]
        public ActionResult Create(Lecture lecture)
        {
           
            if (Client<Lecture>.Create(lecture,RetrieveKeys(_resourceName)))
            {
                return RedirectToAction("Create", "LectureNote");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Lecture/Edit/5
        public ActionResult Edit(int id)
        {
            var lecture = JsonConvert.DeserializeObject<Lecture>(Client<Lecture>.Get(id, RetrieveKeys(_resourceName)));
            return View(lecture);
        }

        //
        // POST: /Lecture/Edit/5
        [HttpPost]
        public ActionResult Edit(Lecture lecture)
        {
            if (Client<Lecture>.Update(lecture,RetrieveKeys(_resourceName)))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
            return RedirectToAction("Login","Authenticate");
        }
    }
}
