using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Commodity
    {
        public Commodity()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CommodityId { get; set; }
        public string CommodityName { get; set; } = null!;
        public int? Quantity { get; set; }
        public string? CommodityImage { get; set; }
        public decimal? PriceCommodity { get; set; }
        public string? Description { get; set; }
        public int? CcategoryId { get; set; }

        public virtual CommodityCategory? Ccategory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
