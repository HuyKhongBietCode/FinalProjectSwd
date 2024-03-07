using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AttendanceDays = new HashSet<AttendanceDay>();
            Orders = new HashSet<Order>();
            SigningSalaries = new HashSet<SigningSalary>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? Gender { get; set; }
        public DateTime StartDayOfWork { get; set; }
        public string Password { get; set; } = null!;
        public string? PositionId { get; set; }

        public virtual Position? Position { get; set; }
        public virtual ICollection<AttendanceDay> AttendanceDays { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SigningSalary> SigningSalaries { get; set; }
    }
}
