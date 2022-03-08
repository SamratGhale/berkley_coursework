using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Payment
    {
        public string PaymentId { get; set; }
        public string StudentId { get; set; }
        public decimal Amount { get; set; }
        public decimal Year { get; set; }
        public DateTime Date { get; set; }
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Student Student { get; set; }
    }
}
