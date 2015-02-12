using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace EduPortal.Core.Entity
{
    public class School : Base
    {
        /// <summary>
        /// Name of The School
        /// </summary>
//        [DataMember]
        public virtual string Name { get; set; }

        [DisplayName("School Admin Email")]
        public virtual string AdminEmail { get; set; }


       // [Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Select a correct license")]
       // [DataMember]
        [DisplayName("Type")]
        public virtual SchoolType SchoolType { get; set; }

        //public virtual string DbConnectionString {
        
    }
}
