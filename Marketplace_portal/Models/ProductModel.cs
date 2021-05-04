using MarketplacePortal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class ProductModel
    {
        public String ManufacturerName { get; set; }
        public String Series { get; set; }
        public String Model { get; set; }
        public String ModelYear { get; set; }
        public String UseType { get; set; }
        public String Application { get; set; }
        public String MountingLocation { get; set; }
        public String Accessories { get; set; }
        public String AirFlow { get; set; }
        public String Power { get; set; }
        public String OperatingVoltage { get; set; }
        public String NumberFanSpeed { get; set; }
        public String MaxSpeed { get; set; }
        public String FanSpeed { get; set; }

        public String FanSweep { get; set; }
        public String Height { get; set; }
        public String Weight { get; set; }

        public String Image { get; set; }
    }
}