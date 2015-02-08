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
    public class ClassLevelController : ApiController
    {
        ClassLevelSystem system = new ClassLevelSystem();
        
        // GET api/classlevel
        public IEnumerable<ClassLevel> Get(string key)
        {
            return system.RetrieveAll(key);
        }

        // GET api/classlevel/5
        public ClassLevel Get(string key,int id)
        {
            return system.RetrieveBy(id,key);
        }

        // POST api/<controller>
        public void Post(string key,ClassLevel classLevel)
        {
            system.Save(classLevel,key);
        }

        // PUT api/<controller>/5
        public void Put(string key,ClassLevel classLevel)
        {
            system.Update(classLevel,key);
        }

    }
}
