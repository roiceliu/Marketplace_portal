using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketplacePortal_DAL;
using MarketplacePortal_Service;
using Marketplace_portal.Models;

namespace Marketplace_portal.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            FilterViewModel viewModel = new FilterViewModel();
            FilterService fservice = new FilterService();

            //add products with type roof
            viewModel.products = fservice.GetProductsByProductType("Roof");

            //add temp values for product types
            /*
            viewModel.productTypes.Add("Roof");
            viewModel.productTypes.Add("Commercial");
            viewModel.productTypes.Add("Non Commercial");

            ViewBag.ProductTypes = new SelectList(viewModel.productTypes);

            */

            return View(viewModel);
        }
    }
}