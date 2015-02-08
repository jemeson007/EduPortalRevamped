using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Systems
{
    public class LectureSystem : IBaseSystem<Lecture>
    {
        public IList<Lecture> GetSubjectLectures(long subjectID,string key)
        {
            //var lectures = new List<Lecture>();

            //var filter = new Lecture()
            //{
            //    Subject = new Subject { ID = subjectID }
            //};

            //lectures = Search(filter, null, null, null,key);

            //return lectures;
            return null;
        }
    }
}
