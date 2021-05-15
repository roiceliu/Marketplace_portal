using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketplacePortal_DAL;

namespace Marketplace_portal.Models
{
    public class SearchDepartment
    {
        public int Department_id { get; set; }
        public String Department_name { get; set; }
        public IEnumerable<SelectListItem> departments { get; set; }
    }
}