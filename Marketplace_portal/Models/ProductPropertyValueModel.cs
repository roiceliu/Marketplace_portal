using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class ProductPropertyValueModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string Model { get; set; }

        public string Series { get; set; }

        public string ModelYear { get; set; }

        public string Value { get; set; }

        public int HasMinMax { get; set; }

        public float Min { get; set; }

        public float Max { get; set; }

        public int PropertyID { get; set; }

        public string PropertyName { get; set; }
    }
}