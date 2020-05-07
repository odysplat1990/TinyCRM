using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class CustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public DateTime CreateFrom { get; set; }
        public DateTime CreateTo { get; set; }
        public int CustomerId { get; set; }
    }
}
