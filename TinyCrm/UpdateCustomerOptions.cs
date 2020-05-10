using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class UpdateCustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
    }
}
