using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Student
    {
        public Student()
        {
            Payment = new HashSet<Payment>();
            Result = new HashSet<Result>();
        }

        public string StudentId { get; set; }
        public string PersonId { get; set; }
        public string CourseId { get; set; }
        public decimal? Year { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
