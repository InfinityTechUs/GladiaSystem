using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class TrackOrder
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Payment { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public double Quant { get; set; }
    }
}