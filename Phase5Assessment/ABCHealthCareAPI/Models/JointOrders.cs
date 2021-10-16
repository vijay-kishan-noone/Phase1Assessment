using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHealthCareAPI.Models
{
    public class JointOrders
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
    public class CartProduct
    {
        public int Id { get; set; }
        public int InCart { get; set; }
    }
    public class PostOrders
    {
        public int UserId { get; set; }
        public CartProduct[] CartProducts { get; set; }
    }
}
