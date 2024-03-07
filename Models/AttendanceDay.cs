using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class AttendanceDay
    {
        public int EmployeeId { get; set; }
        public string WtimeId { get; set; } = null!;
        public DateTime DateWork { get; set; }
        public bool? Attendance { get; set; }
        public string? Note { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual WorkingTime Wtime { get; set; } = null!;
    }
}
