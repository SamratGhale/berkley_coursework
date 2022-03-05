using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Module
    {
        public Module()
        {
            Exam = new HashSet<Exam>();
        }

        public string ModuleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public decimal? TeachingDays { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
