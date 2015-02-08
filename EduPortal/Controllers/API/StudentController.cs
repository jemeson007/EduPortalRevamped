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
    public class StudentController : ApiController
    {
        // GET api/student
        StudentSystem system = new StudentSystem();
        
        /// <summary>
        /// Retrieves all the students
        /// </summary>
        public IEnumerable<Student> Get(string key)
        {
            var all = system.RetrieveAll(key);
            return all;
        }
        /// <summary>
        /// Retrieves the student with the relevant id
        /// </summary>
        public Student Get(string key,long id)
        {
            return system.RetrieveBy(id,key);
        }

        // POST api/<controller>
        /// <summary>
        /// Creates a student for a class in a school
        /// </summary>
        public void Post(string key,Student student)
        {
            system.Save(student,key);
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Updates a student on the server
        /// </summary>
        public void Put(string key,Student student)
        {
            system.Update(student,key);
        }

        //[HttpGet]
        //public IList<Student> GetSubjectStudents(string key,long subjectID)
        //{
        //    return new StudentSubjectSystem().GetSubjectStudents(subjectID,key);
        //}
    }
}
