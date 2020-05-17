using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Service;
using TinyCrm.Core.Service.Options;
using TinyCrm.Core.Services;

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


                var customer = customerService.CreateCustomer(new CreateCustomerOptions()
                {
                    FirstName = "Dimitris",
                    LastName = "Pnevmatikos",
                    VatNumber = "123456789"
                });
            }
        }
    }
}