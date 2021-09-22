using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phase3Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase3Assessment.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext _context;

        public CustomerController(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Laptops);
        }
        public async Task<IActionResult> Details(int id)
        {
            Laptop laptop = new Laptop();
            foreach (var lap in _context.Laptops.ToList())
            {
                if(lap.Id == id)
                {
                    laptop = lap;
                    break;
                }
            }
            var user = await userManager.FindByIdAsync(laptop.Userid);
            ViewBag.msg = user.Name;

            return View(laptop);
        }
        public IActionResult Payment(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> Order(int id)
        {
            Laptop laptop = new Laptop();
            foreach (var lap in _context.Laptops.ToList())
            {
                if (lap.Id == id)
                {
                    laptop = lap;
                    break;
                }
            }
            laptop.NoOfSales = laptop.NoOfSales + 1;
            _context.Update(laptop);
            _context.SaveChanges();
            var seller = await userManager.FindByIdAsync(laptop.Userid);
            ViewBag.sellerAddress = seller.Address;
            string name = User.Identity.Name;
            var user = await userManager.FindByNameAsync(name);
            ViewBag.address = user.Address;

            return View(laptop);
        }
    }
}
