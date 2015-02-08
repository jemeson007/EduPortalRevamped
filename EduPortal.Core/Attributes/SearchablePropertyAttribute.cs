using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.Attributes
{
    [global::System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SearchablePropertyAttribute : Attribute
    {
        public SearchablePropertyAttribute()
        {
        }
    }
}
