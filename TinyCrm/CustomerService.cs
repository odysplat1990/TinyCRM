using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;
        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Firstname))
            {
                query = query.Where(c => c.Firstname == options.Firstname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }

        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = new Customer()
            {
                Lastname = options.LastName,
                Firstname = options.FirstName,
                VatNumber = options.VatNumber
            };

            context_.Add(customer);

            if (context_.SaveChanges() > 0)
            {
                return customer;
            }

            return null;
        }


        public Customer GetCustomerById(int? custId)
        {
            if (custId == null)
            {
                return null;
            }

            var customer = SearchCustomers(new SearchCustomerOptions()
            {
                CustomerId = custId
            });

            if (customer == null)
            {
                return null;
            }

            return customer.SingleOrDefault();
        }

        public Customer UpdateCustomer(UpdateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = SearchCustomers(new SearchCustomerOptions()
            {
                CustomerId = options.CustomerId
            }).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            if (options.FirstName != null)
            {
                customer.Firstname = options.FirstName;
            }
            if (options.LastName != null)
            {
                customer.Lastname = options.LastName;
            }
            if (options.Email != null)
            {
                customer.Email = options.Email;
            }
            if (options.IsActive != null)
            {
                customer.IsActive = options.IsActive.Value;
            }

            context_.SaveChanges();

            return customer;
        }
    }
}
