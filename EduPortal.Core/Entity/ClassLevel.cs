using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public class ClassLevel : Base
    {
        ///Deleted because SchoolBranch already contains school
        //public virtual School School { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        [DisplayName("Branch")]
        public virtual SchoolBranch SchoolBranch { get; set; }

        [NotMapped]
        public virtual int BranchId { get; set; }

    }
}
