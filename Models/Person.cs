using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Person
    {
        public Person()
        {
            Teacher = new HashSet<Teacher>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PersonId { get; set; }
        public string AddressId { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
