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

            //select specific columns from the current product row
            var img = product.Select(x => x.ProductImage);
            var model = product.Select(x => x.Model);
            var modelYear = product.Select(x => x.ModelYear);
            var manufacturerId = product.Select(x => x.ManufacturerID);



            return View();
        }

    }
}
