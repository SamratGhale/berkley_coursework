using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Student
    {
        public Student()
        {
            Exam = new HashSet<Exam>();
            Payment = new HashSet<Payment>();
        }

        public string StudentId { get; set; }
        public string PersonId { get; set; }
        public string CourseId { get; set; }
        public decimal? Year { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
