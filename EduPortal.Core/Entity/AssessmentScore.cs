using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    [Serializable]
    [DataContract]
    public class AssessmentScore : Base
    {
        [DataMember]
        public virtual SubjectAssessmentComponent Assessment { get; set; }

        [NotMapped]
        public virtual int SubjectAssessmentComponentId { get; set; }

        [DataMember]
        public virtual Decimal Score { get; set; }

        [NotMapped]
        public virtual int StudentId { get; set; }

        [DataMember]
        public virtual Student Student { get; set; }
    }
}
