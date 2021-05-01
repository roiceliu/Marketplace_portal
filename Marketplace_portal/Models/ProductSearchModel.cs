using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class ProductSearchModel
    {
        public List<tblProduct> products { get; set; }
        public String[] productNames { get; set; }

        //[Key]
        //public int ProductID { get; set; }
        //public int ManufacturerID { get; set; }
        //public int SubcategoryID { get; set; }

        //public string ProductName { get; set; }

        //public string ProductImage { get; set; }

        //public string Model { get; set; }
        //public string ModelYear { get; set; }
        //public string Series { get; set; }

    }
}