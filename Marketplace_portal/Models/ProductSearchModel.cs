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

        public int[] productSubcategoryIDs { get; set; }
        public int[] subcategoryIDs { get; set; }
        public String[] departmentNames { get; set; }
        public String[] subcategoryNames { get; set; }
        public Dictionary<string, string> subCategoryDepartmentDict { get; set; }

        //public List<tblProduct> products { get; set; }
        //public String[] productNames { get; set; }
    }
}