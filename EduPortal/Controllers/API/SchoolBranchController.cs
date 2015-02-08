using EduPortal.Core.Entity;
using EduPortal.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduPortal.Controllers.API
{
    
    public class SchoolBranchController : ApiController
    {

        SchoolBranchSystem system = new SchoolBranchSystem();
        // GET: api/SchoolBranch
        public IEnumerable<SchoolBranch> Get(string key)
        {
            var a= Request.Headers ;
            return system.RetrieveAll(key);
        }

        // GET: api/SchoolBranch/5
        public SchoolBranch Get(string key,long id)
        {
            return system.RetrieveBy(id,key);
        }

        // POST: api/SchoolBranch
        public void Post(string key,SchoolBranch branch)
        {
            system.Save(branch,key);
        }

        // PUT: api/SchoolBranch/5
        public void Put(string key,SchoolBranch branch)
        {
            system.Update(branch,key);
        }

    }
}
