//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using EduPortal.BLL.Systems;
//using EduPortal.Core.Entity;

//namespace EduPortal.API.Controllers.API
//{
//    /// <summary>
//    /// Subject Assessment Controller
//    /// </summary>
//    public class SubjectAssessmentController : ApiController
//    {
//        /// <summary>
//        /// Method retrieves the assessment components for the specified subject
//        /// GET api/subjectassessment/getsubjectcomponets/subjectid
//        /// </summary>
//        /// <param name="subjectID"></param>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("api/SubjectAssessment/GetAssessmentComponents/{subjectID}")]
//        public IEnumerable<SubjectAssessmentComponent> Get(long subjectID)
//        {
//            var filter = new SubjectAssessmentComponent { Subject = new Subject { ID = subjectID } };
//            var results = new SubjectAssessmentComponentSystem().Search(filter, null, null, null);
//            return results;
//        }

        
//        // GET api/subjectassessment/5
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="listOfIDs"></param>
//        /// <param name="separator"></param>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("api/SubjectAssessment/GetAssessmentComponents/SearchByIDs/{listOfIDs}/{separator}")]
//        public IEnumerable<SubjectAssessmentComponent> Get(string listOfIDs, char separator)
//        {
//            var ids = listOfIDs.Trim().Trim(separator).Split(separator);
            
//            var dictionary = new Dictionary<string, List<object>>()
//            {
//                {"ID", ids.ToList<object>()}
//            };

//            var results = new SubjectAssessmentComponentSystem().Search(dictionary, null, null, null);
//            return results;
//        }

//        // POST api/subjectassessment
//        public void Post(IList<SubjectAssessmentComponent> components)
//        {
//            foreach (var component in components)
//            {
//                new SubjectAssessmentComponentSystem().Save(component);
//            }
//        }

//        [HttpPost]
//        [Route("api/SubjectAssessment/UploadScores")]
//        public void Post(IList<AssessmentScore> scores)
//        {
//            foreach (var score in scores)
//            {
//                new AssessmentScoreSystem().Save(score);
//            }
//        }

//        [HttpGet]
//        [Route("api/SubjectAssessment/GetScores/{subjectID}")]
//        public IList<AssessmentScore> GetSubjectScores(long subjectID)
//        {
//            var results = new AssessmentScoreSystem().GetSubjectScores(subjectID);
//            return results;
//        }

//        // PUT api/subjectassessment/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/subjectassessment/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
