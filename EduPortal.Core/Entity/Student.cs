using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public class Student : Base
    {
        [DataMember]
        public virtual string Lastname { get; set; }

        [DataMember]
        public virtual string OtherNames { get; set; }

        [DataMember]
        public virtual Sex Sex { get; set; }

        [DataMember]
        public virtual DateTime DateOfBirth { get; set; }

        [DataMember]
        public virtual DateTime AdmissionDate { get; set; }

        [DataMember]
        public virtual string ImagePath { get; set; }

        [DataMember]
        public virtual AcademicSession SessionAdmitted { get; set; }

        [NotMapped]
        public virtual int SessionAdmittedId { get; set; }

        [DataMember]
        public virtual SchoolBranch SchoolBranch { get; set; }

        [NotMapped]
        public virtual int BranchId { get; set; }
        /// <summary>
        /// <para>Unique Identifier for Student</para>
        ///<para>Obviously, this should be auto-generated</para>
        /// </summary>
        [DataMember]
        public virtual string AdmissionNumber { get; set; }
    }
}
