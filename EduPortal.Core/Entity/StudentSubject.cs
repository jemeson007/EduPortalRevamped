using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Core.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Core.Entity
{
    public class StudentSubject : Base
    {
        [DataMember]
        [SearchableProperty]
        public virtual Student Student { get; set; }

        [NotMapped]
        public virtual int StudentId { get; set; }

        [DataMember]
        [SearchableProperty]
        public virtual Subject Subject { get; set; }

        [NotMapped]
        public virtual int SubjectId { get; set; }
    }
}
