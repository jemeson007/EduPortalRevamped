using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.DAO;

namespace EduPortal.Systems
{
    public class StudentSubjectSystem : IBaseSystem<StudentSubject>
    {
        //public IList<Subject> GetStudentSubjects(long studentID, string key)
        //{
        //    var searcher = new StudentSubject() { Student = new Student { ID = studentID } };
        //    return Search(searcher, null, null, null,key).Select(x => x.Subject).ToList();
        //}

        //public IList<Student> GetSubjectStudents(long subjectID,string key)
        //{
        //    var searcher = new StudentSubject() { Subject = new Subject { ID = subjectID } };
        //    var results = Search(searcher, null, null, null,key).Select(x => x.Student).ToList();
        //    return results;
        //}
    }
}
