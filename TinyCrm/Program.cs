using Microsoft.EntityFrameworkCore;
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
            using (var context = new TinyCrmDbContext())
            {
                IProductService productService = new ProductService(context);
                ICustomerService customerService = new CustomerService(context);
                IOrderService orderService = new OrderService(context, customerService, productService);

                //var product1 = productService.CreateProduct(new CreateProductOptions()
                //{
                //    Name = "headphones",
                //    Price = 63,
                //    ProductId = "3"
                //});

                //var product2 = productService.SearchProducts(new SearchProductOptions()
                //{
                //    PriceFrom = 50
                //}).ToList();

                //foreach (var p in product2)
                //{
                //    Console.WriteLine(p.Name);
                //}

                //var product2 = productService.UpdateProduct(new UpdateProductOptions()
                //{
                //    Price = 15,
                //    ProductId = "123"
                //});

                var product2 = productService.GetProductById("123456");
                Console.WriteLine(product2.Name);

                //List<string> prodIds = new List<string>();
                //prodIds.Add("123");
                //prodIds.Add("1234");

                //var order1 = orderService.CreateOrder(new CreateOrderOptions()
                //{
                //    DeliveryAddress = "koukaki",
                //    CustomerId = 3,
                //     ProductIds = prodIds
                //}); 

                var order = orderService.SearchOrders(new SearchOrderOptions()
                {
                    DeliveryAddress = "koukaki"
                }).ToList();
                Console.WriteLine(order[0].OrderId);
            }
        }
    }
}