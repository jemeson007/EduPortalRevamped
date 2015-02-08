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
    public class SubjectTeacher : Base
    {       
        [SearchableProperty]
        [DataMember]
        public virtual Subject Subject { get; set; }
        [NotMapped]
        public virtual int SubjectId { get; set; }
        [SearchableProperty]
        [DataMember]
        public virtual Teacher Teacher { get; set; }
        [NotMapped]
        public virtual int TeacherId { get; set; }
    }
}
