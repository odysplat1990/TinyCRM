using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Service.Options;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);

        Order UpdateOrder(UpdateOrderOptions options);

        IQueryable<Order> SearchOrders(SearchOrderOptions options);
    }
}
