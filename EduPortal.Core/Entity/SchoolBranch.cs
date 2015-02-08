using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EduPortal.Core.Entity
{
    public class SchoolBranch : Base
    {
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Address { get; set; }
        [DataMember]
        public virtual string PhoneNumbers { get; set; }
    }
}
