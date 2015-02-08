using EduPortal.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.API.Models
{
    public class SchoolBranchView:SchoolBranch
    {
        [Required]
        public virtual string BranchId { get; set; }

        //public SchoolBranch ToSchoolBranch()
        //{
        //    SchoolBranch result = (SchoolBranch)this;
        //    SchoolClient client = new SchoolClient();
        //    result.School=client.Get(Int32.Parse(BranchId));
        //    return result;
        //}
        //public static SchoolBranchView ToSchoolBranchView(SchoolBranch item)
        //{
        //    SchoolBranchView result = new SchoolBranchView{ ID=item.ID, School=item.School, BranchId=item.School.ID.ToString(), AddressLine1=item.AddressLine1, AddressLine2=item.AddressLine2, IsActive=item.IsActive, Name=item.Name, PhoneNumbers=item.PhoneNumbers };
        //    return result;
        //}
    }
}