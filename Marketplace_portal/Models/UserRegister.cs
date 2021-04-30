using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage ="Please Enter a Username")]
        [StringLength(30)]
        //To change label title value  
        [DisplayName("UserName")]
        public string Username { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Please Enter a Password")] 
        [DisplayName("Password")]
        public string Password { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Please re-enter the Password above")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [StringLength(30)]
        [DisplayName("Email Address")]
        public string UserEmail { get; set; }


        //for Profile Image
        [DisplayName("Your Profile Pic")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}