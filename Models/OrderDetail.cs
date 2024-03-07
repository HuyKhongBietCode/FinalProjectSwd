using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int CommodityId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public bool? Status { get; set; }

        public virtual Commodity Commodity { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
