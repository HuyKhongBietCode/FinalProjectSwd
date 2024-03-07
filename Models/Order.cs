using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal? TotalMoney { get; set; }
        public int? Discount { get; set; }
        public int? AccumulateedPoints { get; set; }
        public decimal? OrtherMoney { get; set; }
        public bool? Status { get; set; }
        public int? TableId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Table? Table { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
