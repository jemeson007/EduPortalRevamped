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
    public class LectureController : ApiController
    {
        LectureSystem system = new LectureSystem();
        // GET api/<controller>
        
        public IEnumerable<Lecture> Get(string key)
        {
            return system.RetrieveAll(key);
        }

        // GET api/<controller>/5
        public Lecture Get(string key,int id)
        {
            return system.RetrieveBy(id,key);
        }

        public void Post(string key,Lecture lecture)
        {
            system.Save(lecture,key);
        }

        // PUT api/<controller>/5
        public void Put(string key,Lecture lecture)
        {
            system.Update(lecture,key);
        }
    }
}
