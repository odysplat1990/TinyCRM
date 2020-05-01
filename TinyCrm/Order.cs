using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddress { get; set; }
        public int TotalAmount { get; set; }
        public List<Product> ProductList = new List<Product>();
    }
}
