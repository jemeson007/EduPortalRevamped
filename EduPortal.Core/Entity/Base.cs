using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        /// <summary>
        /// Status of the Respective Entity
        /// </summary>
        /// 
        [DisplayName("Is Active")]
        public virtual bool IsActive { get; set; }
    }
}
