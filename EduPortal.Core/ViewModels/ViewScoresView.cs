using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduPortal.Core.Entity;
using EduPortal.Core.FileHelpers;

namespace EduPortal.Core.ViewModels
{
    public class ViewScoresView
    {
        public ViewScoresView()
        {
            TheScores = new List<AssessmentRow>();
            AssessmentComponents = new List<SubjectAssessmentComponent>();
        }

        public IList<AssessmentRow> TheScores { get; set; }

        public IList<SubjectAssessmentComponent> AssessmentComponents { get; set; }

        public int NoOfColumns
        {
            get
            {
                return AssessmentComponents.Count;
            }
        }

        public IList<string> TheComponentNames
        {
            get
            {
                return AssessmentComponents.Select(x => x.Name).ToList();
            }
        }

        public IList<decimal> TheComponentWeights
        {
            get
            {
                return AssessmentComponents.Select(x => x.PercentageWeight).ToList();
            }
        }
    }
}