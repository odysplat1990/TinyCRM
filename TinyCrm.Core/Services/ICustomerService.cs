using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Service.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(SearchCustomerOptions options);

        Customer CreateCustomer(CreateCustomerOptions options);

        Customer UpdateCustomer(UpdateCustomerOptions options);

        Customer GetCustomerById(int? custId);
    }
}
