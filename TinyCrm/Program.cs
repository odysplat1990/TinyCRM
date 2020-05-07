using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var custOptions = new CustomerOptions()
            {
                FirstName = "Georgio",
                //LastName = "Platsakis",
                //VatNumber = "987654321",
                CustomerId = 4,
                //CreateFrom = new DateTime(2020, 5, 5),
                //CreateTo = DateTime.Now
            };

            var prodOptions = new ProductOptions()
            {
                ProductId = 4,
                Categories = "sports",
                PriceFrom = 45,
                PriceTo = 80
            };

            List<Customer> customerList = SearchCustomers(custOptions);
            foreach (Customer customer in customerList)
            {
                Console.WriteLine(customer.CustomerId);
            }

            Console.WriteLine(customerList.Count);
        }
        public static List<Customer> SearchCustomers(CustomerOptions options)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();
            var customerList = tinyCrmDbContext
                .Set<Customer>()
                .Where(c => ((c.FirstName == options.FirstName || options.FirstName == null)
                && (c.LastName == options.LastName || options.LastName == null)
                && (c.VatNumber == options.VatNumber || options.VatNumber == null)
                && (DateTime.Compare(c.Created, options.CreateFrom) >= 0 || options.CreateFrom == null)
                && (DateTime.Compare(c.Created, options.CreateTo) <= 0 || options.CreateTo == null)
                && (c.CustomerId == options.CustomerId || options.CustomerId == 0)))
                .Take(500)
                .ToList();
            return customerList;
        }

        public static List<Product> SearchProducts(ProductOptions options)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();
            var productList = tinyCrmDbContext
                .Set<Product>()
                .Where(p => ((p.ProductId == options.ProductId || options.ProductId == 0))
                && (p.Price >= options.PriceFrom || options.PriceFrom == 0)
                && (p.Price <= options.PriceTo || options.PriceTo == 0)
                && (p.ProductCategory == options.Categories || options.Categories == null))
                .ToList();
            return productList;
        }
    }
}
