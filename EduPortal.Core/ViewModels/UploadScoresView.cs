using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduPortal.Core.Entity;

namespace EduPortal.Core.ViewModels
{
    public class UploadScoresView
    {
        public UploadScoresView()
        {
            AssessmentScores = new List<AssessmentScore>();
            AssessmentComponents = new List<SubjectAssessmentComponent>();

        }

        public IList<SubjectAssessmentComponent> AssessmentComponents { get; set; }
        public IList<AssessmentScore> AssessmentScores { get; set; }
        public long SubjectID { get; set; }

    }
}