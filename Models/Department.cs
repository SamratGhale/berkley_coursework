using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Department
    {
        public Department()
        {
            Assignment = new HashSet<Assignment>();
            Payment = new HashSet<Payment>();
        }

        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
