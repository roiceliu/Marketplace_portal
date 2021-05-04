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
        FilterViewModel viewModel = new FilterViewModel();
        FilterService fservice = new FilterService();

        public ActionResult CompareProduct(int id)
        {
            int productId = int.Parse(Request.QueryString["id"].ToString());

            //get current product using productID
            List<tblProduct> product = fservice.GetProductsByProductID(productId);

            //select specific columns for current product
            var img = product.Select(x => x.ProductImage);
            var model = product.Select(x => x.Model);
            var modelYear = product.Select(x => x.ModelYear);
            int manufacturerId = (int)product.Select(x => x.ManufacturerID).FirstOrDefault();
            string manufacturerName = fservice.GetManufacturerNameByID(manufacturerId);
            List<tblProperty> propertyNames = fservice.GetPropertyNames();
            List<tblPropertyValue> productProperties = fservice.GetPropertyInfoForProduct(productId);

            
            

            return View();
        }

    }
}
