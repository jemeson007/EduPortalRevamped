using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduPortal.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string grant_type { get; set; }

        public override String ToString()
        {
            String result = "";
            result += "grant_type=" + grant_type;
            result += "&Username=" + Username;
            result += "&Password=" + Password;
            return result;
        }
    }
}