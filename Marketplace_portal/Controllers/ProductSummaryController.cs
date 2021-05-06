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
        public ActionResult Index(int id)
        {
            ProductSummaryService productSummaryService = new ProductSummaryService();
            ProductSummaryModel properties = new ProductSummaryModel
            {
                //Array is [ManufacturerName, Series, Model, ModelYear]
                description = productSummaryService.getDescription(id),

                //Array is [PropertyName, IsType, Value, HasMinMax, Max, Min]
                properties = productSummaryService.getProperties(id)
            };

            ViewData["propertiesObject"] = properties;
            return View(properties);
        }
    }
}