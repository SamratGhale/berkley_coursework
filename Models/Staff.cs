using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Staff
    {
        public string StaffId { get; set; }
        public string PersonId { get; set; }
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Person Person { get; set; }
    }
}
