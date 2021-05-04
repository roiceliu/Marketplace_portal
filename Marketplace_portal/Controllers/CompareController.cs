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
        FilterService fservice = new FilterService();

        public ActionResult Test()
        {
            //List<int> testList = new List<int>();
            //testList.Add(1);
            //testList.Add(2);
            //testList.Add(3);
            TempData["testList"] = new int[] { 1, 2, 3 };
            return RedirectToAction("CompareProduct", "Compare");
        }

        //Main functional part
        public ActionResult CompareProduct(int[] IdList)
        {
            IdList = (int[])TempData["testList"];
            CompareList list = new CompareList();
            List<ProductModel> productModels = new List<ProductModel>();
            

            foreach(int id in IdList)
            {
                ProductModel item = GetModelByID(id);
                productModels.Add(item);
            }

            list.ProductModels = productModels;
            //ViewBag.Message = product;
            return View("CompareTest",list);
        }

        //get product properties mapped to productModel
        private ProductModel GetModelByID(int productId)
        {
            //get current product using productID
            List<tblProduct> currProduct = fservice.GetProductsByProductID(productId);
            int manufacturerId = (int)currProduct.Select(x => x.ManufacturerID).FirstOrDefault();
            List<tblProperty> propertyNames = fservice.GetPropertyNames();
            List<tblPropertyValue> productProperties = fservice.GetPropertyInfoForProduct(productId);

            //Set all product related values to Product Model
            ProductModel product = new ProductModel()
            {
                ManufacturerName = fservice.GetManufacturerNameByID(manufacturerId),
                Series = currProduct.Select(x => x.Series).FirstOrDefault(),
                Model = currProduct.Select(x => x.Model).FirstOrDefault(),
                ModelYear = currProduct.Select(x => x.ModelYear).FirstOrDefault(),
                UseType = productProperties[0].Value,
                Application = productProperties[1].Value,
                MountingLocation = productProperties[2].Value,
                Accessories = productProperties[3].Value,
                AirFlow = productProperties[4].Value,
                //Power = productProperties[5].Value,
                //OperatingVoltage = productProperties[6].Value,
                //NumberFanSpeed = productProperties[8].Value,
                //MaxSpeed = productProperties[9].Value,
                //FanSpeed = productProperties[7].Value,
                //FanSweep = productProperties[10].Value,
                //Height = productProperties[11].Value,
                Weight = productProperties[12].Value,
                Image = currProduct.Select(x => x.ProductImage).FirstOrDefault()
            };
            return product;
        }

    }
}
