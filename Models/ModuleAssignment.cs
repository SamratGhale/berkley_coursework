using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class ModuleAssignment
    {
        public string ID { get; set; }
        public string AssignmentId { get; set; }
        public string ModuleId { get; set; }
        public string Type { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Module Module { get; set; }
    }
}
