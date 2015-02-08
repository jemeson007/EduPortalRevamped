using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduPortal.API.Models
{
    public class LectureView:Lecture
    {
        [NotMapped]
        public virtual string SubjectId { get; set; }

        //public Lecture ToLecture()
        //{
        //    Lecture result = (Lecture)this;
        //    SubjectClient client=new SubjectClient();
        //    result.Subject = client.Get(Int16.Parse(SubjectId));
        //    return result;
        //}
        //public static LectureView ToLectureView(Lecture lecture)
        //{
        //    return new LectureView { ID=lecture.ID, Subject=lecture.Subject, SubjectId=lecture.Subject.ID.ToString(),LectureNumberInWeek=lecture.LectureNumberInWeek, WeekNumber=lecture.WeekNumber, Date=lecture.Date, IsActive=lecture.IsActive, Content=lecture.Content, Title=lecture.Title };
        //}
    }
}