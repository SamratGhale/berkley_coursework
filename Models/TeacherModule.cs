using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class TeacherModule
    {
        public string ID { get; set; }
        public string TeacherId { get; set; }
        public string ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
