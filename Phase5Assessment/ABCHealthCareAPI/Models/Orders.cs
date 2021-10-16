using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCHealthCareAPI.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
