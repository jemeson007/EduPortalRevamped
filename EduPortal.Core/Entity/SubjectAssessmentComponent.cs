using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Core.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Core.Entity
{
    public class SubjectAssessmentComponent : Base
    {
        [SearchableProperty]
        //[IgnoreDataMember]
        [DataMember]
        public virtual Subject Subject { get; set; }


        [NotMapped]
        public virtual int SubjectId { get; set; }
        //[DataMember]
        //public virtual string SubjectName
        //{
        //    get
        //    {
        //        return Subject != null ? Subject.Name : "";
        //    }
        //}

        [DataMember]
        [Required]
        public virtual string Name { get; set; }

        [DataMember]
        [Required]
        public virtual string Description { get; set; }

        [DataMember]
        [Required]
        public virtual decimal PercentageWeight { get; set; }
    }
}
