using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace_portal.Controllers
{
    public class ProductComparisonController : Controller
    {
        // GET: ProductComparison
        public ActionResult Index()
        {
            return View(ProductComparison);
        }
    }
}