using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TinyCrm
{
    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customerService;
        private IProductService productService;
        public OrderService(TinyCrmDbContext context, ICustomerService custService, IProductService prodService)
        {
            context_ = context;
            customerService = custService;
            productService = prodService;
        }
        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = customerService.SearchCustomers(new SearchCustomerOptions()
            {
                CustomerId = options.CustomerId
            }).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress,
            };

            foreach (var prod in options.ProductIds)
            {
                if (prod == null) continue;

                var product = productService.SearchProducts(new SearchProductOptions()
                {
                    ProductId = prod
                }).SingleOrDefault();

                if (prod != null)
                {
                    var orderProd = new OrderProduct()
                    {
                        Product = product,
                    };

                    order.OrderProducts.Add(orderProd);
                }
                else
                {
                    return null;
                }
            }

            if (order.OrderProducts.Count == 0)
            {
                return null;
            }

            customer.Orders.Add(order);
            context_.Update(customer);

            return context_.SaveChanges() > 0 ? order : null;
        }

        public IQueryable<Order> SearchOrders(SearchOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Order>()
                .AsQueryable();

            if (options.DeliveryAddress != null)
            {
                query = query.Where(o => o.DeliveryAddress == options.DeliveryAddress);
            }
            if (options.PriceFrom != null)
            {
                query = query.Where(o => o.TotalAmount >= options.PriceFrom);
            }
            if (options.PriceTo != null)
            {
                query = query.Where(o => o.TotalAmount <= options.PriceTo);
            }

            return query.AsQueryable();
        }

        public Order UpdateOrder(UpdateOrderOptions options)
        {
            if (options == null || options.OrderId == null)
            {
                return null;
            }

            var order = context_
                .Set<Order>()
                .Where(o => o.OrderId == options.OrderId)
                .Include(o => o.OrderProducts)
                .SingleOrDefault();

            if (order == null)
            {
                return null;
            }

            if (options.DeliveryAddress != null)
            {
                order.DeliveryAddress = options.DeliveryAddress;
            }

            if (options.ProductIds != null)
            {
                order.OrderProducts.Clear();
                order.TotalAmount = 0m;

                foreach (var id in options.ProductIds)
                {
                    var product = productService.GetProductById(id);

                    if (product == null)
                    {
                        return null;
                    }

                    order.OrderProducts.Add(new OrderProduct()
                    {
                        Product = product
                    });

                    order.TotalAmount += product.Price;
                }
            }
            return context_.SaveChanges() > 0 ? order : null;
        }
    }
}
