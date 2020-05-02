﻿using System;
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

        public List<Order> OrderList = new List<Order>();
    }
}
