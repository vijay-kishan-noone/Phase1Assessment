using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCHealthCareAPI.Models
{
    public partial class Products
    {
        public Products()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public int? CatId { get; set; }

        public virtual Categories Cat { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
