using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class CompareModel
    {
        
        public List<string> ProductDetails { get; set; } = new List<string>();
        public List<tblManufacturer> Manufacturer { get; set; }
        public List<tblProduct> Products { get; set; }
        public List<tblProperty> Properties { get; set; }
        public List<tblPropertyValue> ProperValues { get; set; }
        public List<tblTypeFilter> TypeInfo { get; set; }
        public List<tblTechSpecsFilter> Minmax { get; set; }
        public int ProductID { get; set; }
        public int ManufacturerName { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }
        //public image productImage { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        /*
         * Now when I wanna add a string to the list I try

            Product p=new Product();
            p.CategoryRef.Add("sadi");

         */




    }
}