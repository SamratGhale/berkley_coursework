using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Course
    {
        public Course()
        {
            Student = new HashSet<Student>();
        }

        public string CourseId { get; set; }
        public string Name { get; set; }
        public decimal Years { get; set; }
        public decimal Fee { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
