using Marketplace_portal.Models;
using MarketplacePortal_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace_portal.Controllers
{
    public class ProductSummaryController : Controller
    {
        // GET: ProductSummary
        public ActionResult Index()
        {
            ProductSummaryService productSummaryService = new ProductSummaryService();
            ProductSummaryModel properties = new ProductSummaryModel
            {
                //Key is propertyID, Value is [PropertyName, IsType, Value, HasMinMax, Max, Min]
                description = productSummaryService.getDescription(1), //Change this 1 to productID that's passed in.
                properties = productSummaryService.getProperties(1) //Change this 1 to productID that's passed in.
            };

            ViewData["propertiesObject"] = properties;
            return View();
        }
    }
}