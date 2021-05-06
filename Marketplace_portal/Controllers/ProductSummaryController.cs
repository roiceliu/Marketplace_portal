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
                //Array is [ManufacturerName, Series, Model, ModelYear]
                description = productSummaryService.getDescription(2), //Change this 1 to the productID that's passed in.

                //Array is [PropertyName, IsType, Value, HasMinMax, Max, Min]
                properties = productSummaryService.getProperties(2) //Change this 1 to the productID that's passed in.
            };

            ViewData["propertiesObject"] = properties;
            return View(properties);
        }
    }
}