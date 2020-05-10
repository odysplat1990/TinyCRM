using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);

        Order UpdateOrder(UpdateOrderOptions options);

        IQueryable<Order> SearchOrders(SearchOrderOptions options);
    }
}
