using Marketplace_portal.Models;
using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using MarketplacePortal_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace_portal.Controllers
{
    public class CompareController : Controller
    {
        // GET: Compare
        JooleEntities context = new JooleEntities();
        public ActionResult CompareProduct(int id)
        {
            //const urlParams = new URLSearchParams(queryString);
            return View();
        }

    }
}
