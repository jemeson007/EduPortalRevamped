using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Core.Entity
{
//    [Serializable]  
  //  [DataContract]
    public class Base
    {
       // [DataMember]
        /// <summary>
        /// Database Id of respective Entity. Should not be populated for Items trying to be created
        /// </summary>
        public virtual long ID { get; set; }
       // [DataMember]

        public virtual DateTime? DateOfCreation { get; set; }
        /// <summary>
        /// Status of the Respective Entity
        /// </summary>
        public virtual bool IsActive { get; set; }
    }
}
