using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Core.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace EduPortal.Core.Entity
{

    public class Lecture : Base
    {
        [DataMember]
        public virtual string _DisplayName
        {
            get
            {
                return ToString();
            }
        }
        [DataMember]
        [SearchableProperty]
        public virtual Subject Subject { get; set; }
        [NotMapped]
        public virtual int SubjectId { get; set; }
        [DataMember]
        [DisplayName("Week Number")]
        public virtual int WeekNumber { get; set; }
        [DataMember]
        [DisplayName("Lecture Number")]
        public virtual int LectureNumberInWeek { get; set; }
        [DataMember]
        [DisplayName("Date of Lecture")]
        public virtual DateTime? Date { get; set; }

        public virtual string Title { get; set; }

        public virtual string Content { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}
