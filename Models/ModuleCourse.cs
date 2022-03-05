using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class ModuleCourse
    {
        public string ID { get; set; }
        public string CourseId { get; set; }
        public string ModuleId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Module Module { get; set; }
    }
}
