using MarketplacePortal_DAL;
using MarketplacePortal_Repository;
using MarketplacePortal_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketplacePortal_Service.ModelService
{
    class ListOfProducts
    {
        public List<IProductRepository> Products { get; set; }
    }
}
