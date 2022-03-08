using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Address
    {
        public Address()
        {
            Person = new HashSet<Person>();
        }

        public string AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal? Zip { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
