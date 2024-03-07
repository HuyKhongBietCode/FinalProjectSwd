using System;
using System.Collections.Generic;

namespace FinalProjectSwd.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public int? AccumulatedPoints { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
