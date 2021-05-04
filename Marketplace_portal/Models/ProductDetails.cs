using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace_portal.Models
{
    public class ProductDetails
    {
        //Description part of the product
        public string Manufacturer { get; set; }
        //public string Series { get; set; }
        //public string Model { get; set; }

        //Type
        public string UserType { get; set; }
        //public string Application { get; set; }
        //public string MountLocation { get; set; }
        //public string Accessories { get; set; }
        //public string ModelYear { get; set; }

        //Technical 
        public string AirFlow { get; set; }
        //public string NumberOfFans { get; set; }
        //public string SoundSpeed { get; set; }
        //public string FanDiameter { get; set; }
        //public string Weight { get; set; }

        //power
        public float PowerMin { get; set; }
        public float PowerMax { get; set; }

        ////voltage
        //public float VoltageMin { get; set; }
        //public float VoltageMax { get; set; }

        ////Fan speed
        //public float FanMin { get; set; }
        //public float FanMax { get; set; }

        ////height
        //public float HeightMin { get; set; }
        //public float HeightMax { get; set; }

    }
}