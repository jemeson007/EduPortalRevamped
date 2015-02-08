using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EduPortal.Core.Entity;
using EduPortal.Systems;


namespace EduPortal.Controllers.API
{
    public class AttendanceController : ApiController
    {
        AttendanceEntrySystem system = new AttendanceEntrySystem();
        
        // GET api/attendance
        public IEnumerable<AttendanceEntry> Get(string key)
        {
            return system.RetrieveAll(key);
        }

        // GET api/attendance/5
        public AttendanceEntry Get(string key,int id)

        {
            return system.RetrieveBy(id,key);
        }

        // POST api/attendance
        public void Post(string key,AttendanceEntry entry)
        {
            system.Save(entry,key);
        }

        // PUT api/attendance/5
        public void Put(string key, AttendanceEntry entry)
        {
            system.Update(entry, key);
        }

    }
}
