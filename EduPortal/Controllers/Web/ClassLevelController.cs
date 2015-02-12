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
    public class ClassLevelController : BaseController
    {
        private string _resourceName = "classlevel";
                //
        // GET: /ClassLevel/
        public ActionResult Index()
        {
            if(isAuthenticated())
            {
                var classlevels = JsonConvert.DeserializeObject<List<ClassLevel>>(Client<ClassLevel>.GetAll(RetrieveKeys(_resourceName)));
                return View(classlevels);
            }
            return RedirectToLogin();
        }

        //
        // GET: /ClassLevel/Details/5
        public ActionResult Details(int id)
        {
            if(isAuthenticated())
            {
                var classlevel= JsonConvert.DeserializeObject<ClassLevel>(Client<ClassLevel>.Get(id,RetrieveKeys(_resourceName)));
                return View(classlevel);
            }
            return RedirectToLogin();
        }

        //
        // GET: /ClassLevel/Create
        public ActionResult Create()
        {
            if(isAuthenticated())
            {
                ViewBag.Branch = JsonConvert.DeserializeObject<List<SchoolBranch>>(Client<SchoolBranch>.GetAll(RetrieveKeys("schoolbranch")));
                return View();
            }

            return RedirectToLogin();
        }

        //
        // POST: /ClassLevel/Create
        [HttpPost]
        public ActionResult Create(ClassLevel classlevel)
        {
            if (isAuthenticated())
            {
                classlevel.SchoolBranch = JsonConvert.DeserializeObject<SchoolBranch>(Client<SchoolBranch>.Get(classlevel.BranchId, RetrieveKeys("schoolbranch")));
                if (Client<ClassLevel>.Create(classlevel, RetrieveKeys(_resourceName)))
                {
                    return RedirectToAction("Index");
                }
                
                return View(classlevel);
            }
            
            return RedirectToAction("Login","Authenticate");
        }

        //
        // GET: /ClassLevel/Edit/5
        public ActionResult Edit(int id)
        {
            if (isAuthenticated())
            {
                ClassLevel result = JsonConvert.DeserializeObject<ClassLevel>(Client<ClassLevel>.Get(id, RetrieveKeys(_resourceName)));
                ViewBag.Branch = JsonConvert.DeserializeObject<List<SchoolBranch>>(Client<SchoolBranch>.GetAll(RetrieveKeys("schoolbranch")));
                return View(result);
            }
            return RedirectToLogin();
        }

        //
        // POST: /ClassLevel/Edit/5
        [HttpPost]
        public ActionResult Edit(ClassLevel classlevel)
        {
            if (isAuthenticated())
            {
                if (Client<ClassLevel>.Update(classlevel, RetrieveKeys(_resourceName)))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(classlevel);
        }

        //
        // GET: /School/EnableorDisable/5
        public ActionResult EnableorDisable(int id)
        {
            if (isAuthenticated())
            {
                var subject = JsonConvert.DeserializeObject<ClassLevel>(Client<ClassLevel>.Get(id, RetrieveKeys(_resourceName)));
                subject.IsActive = !subject.IsActive;
                if (Client<ClassLevel>.Update(subject, RetrieveKeys(_resourceName)))
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            return View();
        }

    }
}
