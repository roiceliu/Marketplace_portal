using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketplacePortal_Service;
using MarketplacePortal_DAL;
using Marketplace_portal.Models;

namespace Marketplace_portal.Controllers
{
    public class ProductSearchController : Controller
    {
        // GET: ProductSearch
        public ActionResult Index()
        {

            ProductSearchService productSearchService = new ProductSearchService();
            ProductSearchModel p = new ProductSearchModel
            {
                subcategoryNames = productSearchService.getSubcategoryNames(),
                subcategoryIDs = productSearchService.getSubcategoryIDs(),
                departmentNames = productSearchService.getDepartmentNames(),
                subCategoryDepartmentDict = productSearchService.getSubcategoryDepartmentDict()
            };

            ViewBag.Title = "Product Search";
            Session.Add("productObject", p);
            //return View("Intro");
            return View();
        }
    }
}