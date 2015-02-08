using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduPortal.Controllers.Web
{
    public class AcademicSessionController : BaseController
    {
        //
        // GET: /AcademicSession/
        public ActionResult Index()
        {
            if(isAuthenticated())
            {
                return View();
            }
            return RedirectToAction("Login","Authentication");
        }

        //
        // GET: /AcademicSession/Details/5
        public ActionResult Details(int id)
        {
            if(isAuthenticated())
            {
                return View();
            }
            return RedirectToLogin();
        }

        //
        // GET: /AcademicSession/Create
        public ActionResult Create()
        {
            if (isAuthenticated())
            {
                return View();
            }
            return RedirectToLogin();
        }

        //
        // POST: /AcademicSession/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AcademicSession/Edit/5
        public ActionResult Edit(int id)
        {
            if (isAuthenticated())
            {
                return View();
            }
            return RedirectToLogin();
        }

        //
        // POST: /AcademicSession/Edit/5
        [HttpPost]
        public ActionResult Edit(AcademicSession academicSession)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

      
    }
}
