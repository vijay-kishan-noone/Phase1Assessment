using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHealthCareAPI.Models
{
    public class JointProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
