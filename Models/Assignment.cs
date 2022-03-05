using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Exam = new HashSet<Exam>();
        }

        public string AssignmentId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
