using System;
using System.Collections.Generic;

namespace berkley_coursework.Models
{
    public partial class Attendance
    {
        public string StudentId { get; set; }
        public string ModuleId { get; set; }
        public decimal? AttendanceCount { get; set; }

        public virtual Module Module { get; set; }
        public virtual Student Student { get; set; }
    }
}
