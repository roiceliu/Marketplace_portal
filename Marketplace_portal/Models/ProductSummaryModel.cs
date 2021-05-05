using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class ProductSummaryModel
    {
        public string[] description { get; set; } //Array is [ManufacturerName, Series, Model, ModelYear]
        public List<string[]> properties { get; set; } //String array of [PropertyName, IsType, Value, HasMinMax, Max, Min]

    }
}