using EduPortal.Core;
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
    public class SubjectController : ApiController
    {
        // GET api/subject
        SubjectSystem system = new SubjectSystem();
        
        /// <summary>
        /// Retrieves all the subjects
        /// </summary>
        public IEnumerable<Subject> Get(string key)
        {
            var all = system.RetrieveAll(key);
            return all;
        }
        /// <summary>
        /// Retrieves the subject with the relevant id
        /// </summary>
        public Subject Get(string key,long id)
        {
            return system.RetrieveBy(id,key);
        }

        // POST api/<controller>
        /// <summary>
        /// Creates a subject for a class in a school
        /// </summary>
        public void Post(string key,Subject subject)
        {
            system.Save(subject,key);
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Updates a subject on the server
        /// </summary>
        public void Put(string key,Subject subject)
        {
            system.Update(subject,key);
        }

        /// <summary>
        /// Retrieves all the subjects without assessment component specified
        /// </summary>
        [HttpGet]
        [Route("api/Subject/GetForAssessmentDefinition")]
        public IEnumerable<Subject> GetForAssessmentDefinition()
        {
            return null;
            //system.GetWithAssessmentNotSpecified(key);
        }      
    }
}
