using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    [Serializable]
    public class AcademicSession : Base
    {
        DateTime minDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        public AcademicSession()
        {
            StartDate = EndDate = minDate;
        }


        [DataMember]
        public virtual DateTime StartDate { get; set; }

        [DataMember]
        public virtual DateTime EndDate { get; set; }

        [DataMember]
        public virtual string Name
        {
            get
            {
                return string.Format("{0}/{1}", StartDate.Year, EndDate.Year);
            }
        }
    }
}
