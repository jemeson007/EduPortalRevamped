using EduPortal.Client;
using EduPortal.Core.EF;
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
    public class SchoolController : ApiController
    {
        // GET api/<controller>
        SchoolSystem system = new SchoolSystem();
        public IEnumerable<School> Get()
        {
            return system.RetrieveAll();
        }

        // GET api/<controller>/5
        public School Get(int id)
        {
            return system.RetrieveBy(id);
        }

        // POST api/<controller>
        public void Post(School value)
        {
            ApplicationDbContext schoolDB = new ApplicationDbContext(value.Name);
            system.Save(value);
        }

        // PUT api/<controller>/5
        public void Put(School value)
        {
            system.Update(value);
        }

    }
}