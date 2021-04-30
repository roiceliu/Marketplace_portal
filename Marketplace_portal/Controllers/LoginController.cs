using Marketplace_portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MarketplacePortal_Service;

namespace Marketplace_portal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                //get UserTble 
                IUserService us = new UserService();
                Boolean isValid = us.IsUserExist(user.UserName, user.Password);
                if (isValid)
                    return RedirectToAction("Success");
                else {
                    ViewData["errorMessage"] = "UserID or Password is incorrect";
                    return View();
                }
                    
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}