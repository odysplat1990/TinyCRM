using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; private set; }
        public List<Product> ProductList = new List<Product>();

        public decimal Total()
        {
            TotalAmount = 0;
            for (int i = 0; i < ProductList.Count; i++)
            {
                TotalAmount += ProductList[i].Price;
            }
            return TotalAmount;
        }

        public Order()
        {
            var guid1 = Guid.NewGuid().ToString();
            OrderId = guid1;
        }
    }
}
