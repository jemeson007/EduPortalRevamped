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
    public class BranchController : BaseController
    {
        private string _resourceName = "schoolbranch";

        // GET: Branch
        public ActionResult Index()
        {
            if(isAuthenticated())
            {
                List<SchoolBranch> branches=JsonConvert.DeserializeObject<List<SchoolBranch>>(Client<SchoolBranch>.GetAll(RetrieveKeys(_resourceName)));
                return View(branches);
            }
            return RedirectToAction("Login","Authentication");
        }

        // GET: Branch/Details/5
        public ActionResult Details(int id)
        {
           if(isAuthenticated())
           {
                SchoolBranch branch = JsonConvert.DeserializeObject<SchoolBranch>(Client<SchoolBranch>.Get(id,RetrieveKeys(_resourceName)));
                return View(branch);
           }
           return RedirectToLogin();
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public ActionResult Create(SchoolBranch branch)
        {
            if(isAuthenticated())
            {
                var result = Client<SchoolBranch>.Create(branch,RetrieveKeys(_resourceName));
                if (result)
                {
                    return RedirectToAction("Index");
                } 
            }
            return View(branch);            
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int id)
        {
            if(isAuthenticated())
            {
                var branch = JsonConvert.DeserializeObject<SchoolBranch>(Client<SchoolBranch>.Get(id, RetrieveKeys(_resourceName)));
                return View(branch);
            }
            return RedirectToLogin();
           
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(SchoolBranch branch)
        {
            if(isAuthenticated())
            {
                var result=Client<SchoolBranch>.Update(branch,RetrieveKeys(_resourceName));
                if(result)
                {
                    RedirectToAction("Index");
                }
            }  
            return View();
            
        }
        public ActionResult EnableorDisable(int id)
        {
            if(isAuthenticated())
            {
                SchoolBranch result = JsonConvert.DeserializeObject<SchoolBranch>(Client<SchoolBranch>.Get(id,RetrieveKeys(_resourceName)));
                result.IsActive = !result.IsActive;
                Client<SchoolBranch>.Update(result, RetrieveKeys(_resourceName));
                return Redirect(Request.UrlReferrer.ToString());
            }
            return RedirectToAction("Login","Authentication");
        }
        
    }
}
