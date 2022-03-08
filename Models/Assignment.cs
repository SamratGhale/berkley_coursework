using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Result = new HashSet<Result>();
        }

        public string AssignmentId { get; set; }
        public string Type { get; set; }
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
