using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTime Created { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }

        public List<Order> OrderList = new List<Order>();

        public Customer()
        {
            Created = DateTime.Now;
        }
    }
}
