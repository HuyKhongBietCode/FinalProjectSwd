using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
        }

        public int TableId { get; set; }
        public string TableName { get; set; } = null!;
        public short? MaximumQuantity { get; set; }
        public bool? TableStatus { get; set; }
        public string? AreaId { get; set; }

        public virtual Area? Area { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
