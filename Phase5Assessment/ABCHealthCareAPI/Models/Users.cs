using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCHealthCareAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Addresses = new HashSet<Addresses>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
