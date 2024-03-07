using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class WorkingTime
    {
        public WorkingTime()
        {
            AttendanceDays = new HashSet<AttendanceDay>();
        }

        public string WtimeId { get; set; } = null!;
        public string WtimeName { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Salary { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AttendanceDay> AttendanceDays { get; set; }
    }
}
