using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase3Assessment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string RoleType { get; set; }
    }
}
