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
                products = productSearchService.getProducts().ToList(),
                productNames = productSearchService.getProductNames(),
                productSubcategoryIDs = productSearchService.getProductSubcategoryIDs(),
                departmentNames = productSearchService.getDepartmentNames(),
                subCategoryDepartmentDict = productSearchService.getSubcategoryDepartmentDict()
            };

            ////Get list of products
            //Service s = new Service();
            //List<tblProduct> products = s.GetAllProducts();
            ViewData["productObject"] = p;
            //ViewData["productNames"] = p.productNames;
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