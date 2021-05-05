using Marketplace_portal.Models;
using MarketplacePortal_DAL;
using MarketplacePortal_Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace_portal.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView(new UserRegister()); //had to change here to make it work-Mark
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                //get fileName
                string FileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                //get image extension
                string FileExtension = Path.GetExtension(user.ImageFile.FileName);

                //setting up image path for user
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                //get config upload path
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                user.ImagePath = UploadPath + FileName;
                //To copy and save file into project "UserImages" path
                user.ImageFile.SaveAs(user.ImagePath);


                //save user into database 
                //FIXME: database Identity key, database image type
                IUserService us = new UserService();
                tblUser newUser = new tblUser
                {
                    UserEmail = user.UserEmail,
                    UserPassword = user.Password,
                    UserName = user.Username,
                    UserProfileImage = user.ImagePath
                };

                us.InsertUser(newUser);
                return RedirectToAction("Login", "Login");
            }
            
            //Add Error Message
            //ViewData["ErrorMessage"] = 
            return PartialView("Register");
            
        }
    }
}