using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace_portal.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult Practice()
        {
            /*
                int hour = DateTime.Now.Hour;
                ViewBag.Message = hour < 12 ? "Good Morning" : "Good Afternoon";*/
                return View();
            }
        
    }
}