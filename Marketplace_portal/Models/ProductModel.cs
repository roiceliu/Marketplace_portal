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
        public String ProductImage { get; set; }
        public String Series { get; set; }
        public String Model { get; set; }
        public String ModelYear { get; set; }
        public String UseType { get; set; }
        public String Application { get; set; }
        public String MountingLocation { get; set; }
        public String Accessories { get; set; }
        public String AirFlow { get; set; }
        public int HasMinMax { get; set; }
        public float? PowerMin { get; set; }
        public float? PowerMax { get; set; }        
        public float? Min { get; set; }      
        public float? Max { get; set; }
        public float? OperatingVoltageMin { get; set; }
        public float? OperatingVoltageMax { get; set; }
        public String NumberFanSpeed { get; set; }
        public float? FanSpeedMin { get; set; }
        public float? FanSpeedMax { get; set; }
        public String MaxSpeed { get; set; }
        public String FanSweep { get; set; }
        public float? HeightMin { get; set; }
        public float? HeightMax { get; set; }
        public String Weight { get; set; }
        public String Image { get; set; }
    }
}