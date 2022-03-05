using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
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
