using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Marketplace_portal.Models
{
    public class UserLogin
    {
        [Display(Name ="UserName")]
        [Required(ErrorMessage ="Please Enter Your Email or User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
    }
}