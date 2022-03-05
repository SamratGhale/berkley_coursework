using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Department
    {
        public Department()
        {
            Staff = new HashSet<Staff>();
        }

        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
