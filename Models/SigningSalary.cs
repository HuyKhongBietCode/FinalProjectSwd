using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class SigningSalary
    {
        public int SsalaryId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateEnd { get; set; }
        public int? TotalShiftWork { get; set; }
        public string? SigningSalary1 { get; set; }
        public decimal? TotalSalary { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
