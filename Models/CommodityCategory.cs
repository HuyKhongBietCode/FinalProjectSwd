using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class CommodityCategory
    {
        public CommodityCategory()
        {
            Commodities = new HashSet<Commodity>();
        }

        public int CcategoryId { get; set; }
        public string CcategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}
