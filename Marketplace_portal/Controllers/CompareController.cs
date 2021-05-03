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

        private readonly IProductService productService;
        private readonly IPropertyService propertyService;
        private readonly IPropertyValueService propertyValueService;
        private readonly IManufacturerService ManufacturerService;
        private readonly ITypeFilterService typeFilterService;
        private readonly ITechSpecsFilterService techSpecsFilterService;



        public CompareController(IProductService productService, IPropertyService propertyService, IPropertyValueService propertyValueService, IManufacturerService ManufacturerService, ITypeFilterService typeFilterService, ITechSpecsFilterService techSpecsFilterService)
        {
            this.productService = productService;
            this.propertyService = propertyService;
            this.propertyValueService = propertyValueService;
            this.ManufacturerService = ManufacturerService;
            this.typeFilterService = typeFilterService;
            this.techSpecsFilterService = techSpecsFilterService;


        }
    }
}
