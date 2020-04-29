using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
   public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string productId, string name, string description, decimal price)
        {
            ProductId = productId;
            Description = description;
            Name = name;
            Price = price;
        }


    }
}
