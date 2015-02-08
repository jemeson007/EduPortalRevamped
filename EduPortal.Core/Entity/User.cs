using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Entity
{
    public interface IUser
    {
        string UserName { get; set; }
    }
}
