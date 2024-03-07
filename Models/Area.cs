using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Area
    {
        public Area()
        {
            Tables = new HashSet<Table>();
        }

        public string AreaId { get; set; } = null!;
        public string AreaName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}
