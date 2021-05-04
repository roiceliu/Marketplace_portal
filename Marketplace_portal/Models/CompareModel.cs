using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class CompareModel
    {
        public String subcategory;
        public List<string> productTypes = new List<string>();
        public List<tblProduct> products = new List<tblProduct>();
        public List<tblPropertyValue> propertyValues = new List<tblPropertyValue>();
        public List<tblProperty> property = new List<tblProperty>();
        public List<tblManufacturer> manufacture = new List<tblManufacturer>();
        public List<tblTechSpecsFilter> techspec = new List<tblTechSpecsFilter>();
        public List<tblTypeFilter> type = new List<tblTypeFilter>();
        public List<IHtmlString> listOfDivs = new List<IHtmlString>();

    }
}