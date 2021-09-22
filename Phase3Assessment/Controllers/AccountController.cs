using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phase3Assessment.Models;
using Phase3Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase3Assessment.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to ApplicationUser
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    RoleType = model.RoleType
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, user.RoleType);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    if (user.RoleType == "Seller")
                        return RedirectToAction("Index", "Seller");
                    else
                        return RedirectToAction("Index", "Customer");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                var user = await userManager.FindByEmailAsync(model.Email);              
                
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else if (User.IsInRole("Seller"))
                    {
                        return RedirectToAction("index", "seller");
                    }
                    else if (User.IsInRole("Customer"))
                    {
                        return RedirectToAction("index", "customer");
                    }
                    else if (await userManager.IsInRoleAsync(user,"Admin"))
                    {
                        return RedirectToAction("createrole", "administration");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
        [Authorize(Roles ="Admin")]
        //[AllowAnonymous]
        public async Task<IActionResult> CreateAdmin()
        {
            var admin = new ApplicationUser
            {
                Name = "Admin",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                PhoneNumber = "9898989898",
                Address = "My Address",
                RoleType = "Admin"
            };
            var result = await userManager.CreateAsync(admin, "Admin@123");
            if (result.Succeeded)
                result = await userManager.AddToRoleAsync(admin, "Admin");
            ViewBag.msg = result.Succeeded;
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
