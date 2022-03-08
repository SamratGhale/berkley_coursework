using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Module
    {
        public Module()
        {
            Result = new HashSet<Result>();
        }

        public string ModuleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public decimal? TeachingDays { get; set; }

        public virtual ICollection<Result> Result { get; set; }
    }
}
