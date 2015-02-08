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
    public class AssessmentScoreController : ApiController
    {
        AssessmentScoreSystem system = new AssessmentScoreSystem();
        // GET api/assessment
        public IEnumerable<AssessmentScore> Get(string key)
        {
            return system.RetrieveAll(key);
        }

        // GET api/assessment/5
        public AssessmentScore Get(string key,int id)
        {
            return system.RetrieveBy(id,key);
        }

        // POST api/assessment
        public void Post(string key,AssessmentScore assessmentscore)
        {
            system.Save(assessmentscore,key);
        }

        // PUT api/assessment/5
        public void Put(string key,AssessmentScore assessmentscore)
        {
            system.Update(assessmentscore,key);
        }

        // DELETE api/assessment/5
        public void Delete(int id)
        {
        }
    }
}
