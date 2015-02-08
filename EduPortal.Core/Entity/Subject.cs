using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public class Subject : Base
    {
        public Subject()
        {
            AssessmentComponents = new List<SubjectAssessmentComponent>();
        }
        
        [DataMember]
        public virtual String Name { get; set; }

        //Class Level has a relation to School so it shouldnt be repeated here
        //public virtual School School { get; set; }
                [DataMember]

        public virtual ClassLevel ClassLevel { get; set; }

                [NotMapped]
                public virtual int ClassLevelId { get; set; }
                [DataMember]

        public virtual int NumberofWeeks { get; set; }
                [DataMember]

        public virtual int LecturesPerWeek { get; set; }

        [IgnoreDataMember]
        public virtual IList<SubjectAssessmentComponent> AssessmentComponents { get; set; }
    }
}
