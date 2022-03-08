using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Result
    {
        public string ResultId { get; set; }
        public string ModuleId { get; set; }
        public string AssignmentId { get; set; }
        public string StudentId { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Module Module { get; set; }
        public virtual Student Student { get; set; }
    }
}
