using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketplacePortal_DAL;

namespace Marketplace_portal.Models
{
    public class FilterViewModel
    {
        public String subcategory;
        public List<string> productTypes = new List<string>();
        public List<tblProduct> products = new List<tblProduct>();
        public List<tblPropertyValue> propertyValues = new List<tblPropertyValue>();
        public List<tblProperty> property = new List<tblProperty>();
        public List<IHtmlString> listOfDivs = new List<IHtmlString>(); 
        
    }
}