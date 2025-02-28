﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phase4Assessment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly PizzaBO context = new PizzaBO();
        private static List<PizzaModel> pizzas = context.GetAllPizzas();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(pizzas);
        }
        public IActionResult Details(int id)
        {
            return View(context.GetPizzaById(id));
        }
        public IActionResult Order(int id)
        {
            return View(context.GetPizzaById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
