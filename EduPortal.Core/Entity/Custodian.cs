using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public class Custodian : Base
    {
        
        [DataMember]
        public virtual string Lastname { get; set; }
        [DataMember]
        public virtual string Othernames { get; set; }
        [DataMember]
        public virtual Title Title { get; set; }
        [DataMember]
        public virtual string Email { get; set; }
        [DataMember]
        public virtual string PhoneNumber { get; set; }
    }
}
