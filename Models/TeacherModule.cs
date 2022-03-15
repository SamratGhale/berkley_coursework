using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace berkeley_college.Models
{
    public partial class TeacherModule
    {
        [NotMapped]
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
