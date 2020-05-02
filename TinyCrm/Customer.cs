using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public DateTime Created { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        public List<Order> OrderList = new List<Order>();

        //public  CustomerOrderList (List<Order> order)
        //{
        //    OrderList = order;
        //}
        public Customer(string vatNumber)
        {
            if (!IsValidVatNumber(vatNumber))
            {
                throw new Exception("Invalid Vat number");
            }

            VatNumber = vatNumber;
            Created = DateTime.Now;
        }

        public bool IsValidVatNumber(string vatNumber)
        {
            if (string.IsNullOrWhiteSpace(vatNumber))
            {
                //Console.WriteLine($"length is equal to 0 or value is null");
                return false;
            }

            VatNumber = vatNumber.Trim();

            if (VatNumber.Length != 9)
            {
                return false;
            }

            if (!int.TryParse(VatNumber, out int number))
            {
                return false;
            }

            return true;
        }
        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}
