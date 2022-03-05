using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class ModuleCourse
    {
        public string CourseId { get; set; }
        public string ModuleId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Module Module { get; set; }
    }
}
