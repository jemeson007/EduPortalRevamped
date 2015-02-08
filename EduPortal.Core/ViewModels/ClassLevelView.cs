using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduPortal.API.Models
{
    public class ClassLevelView:ClassLevel
    {
        public virtual string schoolBranchId { get; set; }

        //public ClassLevel ToClassLevel()
        //{
        //    ClassLevel result = (ClassLevel)this;
        //    SchoolBranchClient client = new SchoolBranchClient();
        //    result.SchoolBranch = client.Get(Int32.Parse(schoolBranchId));
        //    return result;
        //}
        //public static ClassLevelView ToClassLevelView(ClassLevel item)
        //{
        //    ClassLevelView result = new ClassLevelView { ID = item.ID,  schoolBranchId = item.SchoolBranch.ID.ToString(), IsActive = item.IsActive, Name = item.Name};
        //    return result;
        //}
    }
}