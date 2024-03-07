using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public string PositionId { get; set; } = null!;
        public string? PositionName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
