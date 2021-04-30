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

            //Get list of products
            Service s = new Service();
            List<tblProduct> products = s.GetAllProducts();
            ViewData["products"] = products;
            return View();
        }

        //public ActionResult getProducts()
        //{
        //    Service s = new Service();
        //    List<tblProduct> products = s.GetAllProducts();
        //    return (products);
        //}
    }
}