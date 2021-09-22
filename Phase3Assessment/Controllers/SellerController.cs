using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Phase3Assessment.Models;
using Phase3Assessment.ViewModels;

namespace Phase3Assessment.Controllers
{
    [Authorize(Roles ="Seller")]
    public class SellerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext _context;

        public SellerController(UserManager<ApplicationUser> userManager,AppDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string name = User.Identity.Name;
            var user = await userManager.FindByNameAsync(name);
            ViewBag.msg = user.Name;            
            return View();
        }
        [HttpGet]
        public IActionResult AddLaptop()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult AddLaptop(Laptop model)
        {
            if (ModelState.IsValid)
            {
                var laptop = new Laptop
                {
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    Userid = userManager.GetUserId(User),
                    NoOfSales = 0                
                };
                _context.Add(laptop);
                _context.SaveChanges();
                return RedirectToAction("index", "seller");
            }
            return View(model);
        }
        public IActionResult SalesReport()
        {
            var laptops = new List<Laptop>();
            foreach (var laptop in _context.Laptops.ToList())
            {
                if (laptop.Userid == userManager.GetUserId(User))
                    laptops.Add(laptop);
            }
            return View(laptops);
        }
        public IActionResult Details(int id)
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
            return View(laptop);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            return View(laptop);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            _context.Laptops.Remove(laptop);
            _context.SaveChanges();
            return RedirectToAction(nameof(SalesReport));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            return View(laptop);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Laptop model)
        {
            //var laptop = await _context.Laptops.FindAsync(id);
            model.Userid = userManager.GetUserId(User);
            _context.Laptops.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(SalesReport));
        }
    }
}
