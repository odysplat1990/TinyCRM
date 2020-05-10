using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public List<string> ProductIds { get; set; }
        public string DeliveryAddress { get; set; }
        public CreateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
