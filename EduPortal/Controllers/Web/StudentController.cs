using EduPortal.Client;
using EduPortal.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class StudentController : BaseController
    {
        private string _resourceName = "student";
        //
        // GET: /Student/
        public ActionResult Index()
        {
            if(isAuthenticated())
            {
                var students=JsonConvert.DeserializeObject<List<Student>>(Client<Student>.GetAll(RetrieveKeys(_resourceName)));
                return View(students);
            }
            return RedirectToLogin();            
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            if (isAuthenticated())
            {
                var student = Client<Student>.Get(id, RetrieveKeys(_resourceName));
                return View(student);
            }
            return RedirectToLogin();
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            if(isAuthenticated())
            {
                return View();
            }
            return RedirectToLogin();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if(Client<Student>.Create(student,RetrieveKeys(_resourceName)))
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = JsonConvert.DeserializeObject<Student>(Client<Student>.Get(id, RetrieveKeys(_resourceName)));
           
            return View(student);            
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
           if(Client<Student>.Update(student,RetrieveKeys(_resourceName)))
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            return View();
           
        }

        //
        // GET: /Student/Delete/5
        public ActionResult EnableorDisable(int id)
        {
            var student = JsonConvert.DeserializeObject<Student>(Client<Student>.Get(id, RetrieveKeys(_resourceName)));
            student.IsActive = !student.IsActive;
            if (Client<Student>.Update(student,RetrieveKeys(_resourceName)))
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
            return View();
        }

    }
}
