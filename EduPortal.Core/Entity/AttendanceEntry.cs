using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    [Serializable]
    [DataContract]
    public class AttendanceEntry : Base
    {
        [DataMember]
        public virtual Lecture Lecture { get; set; }

        [DataMember]
        public virtual Student Student { get; set; }

        [DataMember]
        public virtual Teacher AttendanceTaker { get; set; }

        /// <summary>
        /// Would this be better as an enum that has multiple attendance values: E.G. Late, Present, Absent
        /// </summary>
        [DataMember]
        public virtual bool IsPresent { get; set; }
    }
}
