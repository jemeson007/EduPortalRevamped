using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public class Teacher : Base, IUser 
    {
        [DataMember]
        public virtual string UserName { get; set; }

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }
    }
}
