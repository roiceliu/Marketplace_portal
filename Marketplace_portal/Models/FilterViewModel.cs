using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketplacePortal_DAL;

namespace Marketplace_portal.Models
{
    public class FilterViewModel
    {
        public List<string> productTypes { get; set; }
        public List<tblProduct> products { get; set; }
    }
}