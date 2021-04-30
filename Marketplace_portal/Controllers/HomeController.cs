using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketplacePortal_DAL;
using MarketplacePortal_Service;

namespace Marketplace_portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<tblDepartment> departments = new List<tblDepartment>();
            Service service = new Service();
            departments = service.GetAllDepartments();


            return View(departments);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}