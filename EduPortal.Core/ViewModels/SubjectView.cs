using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduPortal.API.Models
{
    public class SubjectView:Subject
    {
        public virtual string ClassLevelId { get; set; }

        //public Subject ToSubject()
        //{
        //    Subject result=new Subject();
        //    result = (Subject)this;
        //    ClassLevelClient client=new ClassLevelClient();
        //    result.ClassLevel = client.Get(Int16.Parse(ClassLevelId));
        //    return result;
        //}
        //public static SubjectView ToSubjectView(Subject subject)
        //{
        //    return new SubjectView { ID=subject.ID, IsActive=subject.IsActive, LecturesPerWeek=subject.LecturesPerWeek, Name=subject.Name, NumberofWeeks=subject.NumberofWeeks, ClassLevel=subject.ClassLevel, ClassLevelId=subject.ClassLevel.ID.ToString() };
        //}
    }
}