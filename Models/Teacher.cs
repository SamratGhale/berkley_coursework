using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace berkley_coursework.Models
{
    public partial class Teacher
    {
        public string TeacherId { get; set; }
        public string PersonId { get; set; }
        public string Type { get; set; }
        public decimal Salary { get; set; }

        public virtual Person Person { get; set; }
        [NotMapped]
        public virtual ICollection<Module> Modules { get; set; }
    }
}
