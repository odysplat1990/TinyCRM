using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Service.Options
{
    public class SearchOrderOptions
    {
        public int? OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}
