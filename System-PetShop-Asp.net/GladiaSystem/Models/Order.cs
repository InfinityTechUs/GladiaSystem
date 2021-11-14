using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class Order
    {
        public string ID { get; set; }

        [Display(Name = "Data")]
        public string DateOrder { get; set; }

        [Display(Name = "Pagamento")]
        public string Payment { get; set; }

        public string PriceTotal { get; set; }
    }
}