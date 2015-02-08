using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduPortal.Core.Entity;

namespace EduPortal.Core.ViewModels
{
    public class AssessmentComponentsView
    {
        public IList<SubjectAssessmentComponent> theComponents { get; set; }

        //public AssessmentComponentsView()
        //{
        //    theComponents = new List<SubjectAssessmentComponent>();
        //}

        public int numberOfComponents { get; set; }
        public long subjectID { get; set; }
    }
}