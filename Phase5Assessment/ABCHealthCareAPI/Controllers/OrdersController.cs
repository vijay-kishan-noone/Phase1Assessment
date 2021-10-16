using ABCHealthCareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ABCHealthCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ABCHealthCareDBContext _context;

        public OrdersController(ABCHealthCareDBContext context)
        {
            _context = context;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<JointOrders>> Get()
        {
            var result = new List<JointOrders>();
            List<OrdersDetails> od = _context.OrdersDetails.ToList();
            foreach (var item in od)
            {
                var product = _context.Products.Single(x => x.Id == item.ProductId);
                var order = _context.Orders.Single(x => x.Id == item.OrderId);
                var user = _context.Users.Single(x => x.Id == order.UserId); //delete if not needed later
                result.Add(new JointOrders
                {
                    Id = order.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image,
                    Quantity = item.Quantity
                });
            }
            if (result.ToList().Count() == 0)
                return NotFound();
            return result;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<JointOrders>> Get(int id)
        {
            var result = new List<JointOrders>();
            List<OrdersDetails> od = _context.OrdersDetails.Where(x=>x.OrderId == id).ToList();
            var order = _context.Orders.Single(x => x.Id == id);
            var user = _context.Users.Single(x => x.Id == order.UserId);
            foreach (var item in od)
            {
                var product = _context.Products.Single(x => x.Id == item.ProductId);
                result.Add(new JointOrders
                {
                    Id = order.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Image = product.Image,
                    Quantity = item.Quantity
                });
            }
            if (result.ToList().Count() == 0)
                return NotFound();
            return result;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<int> Post(PostOrders postOrders)
        {         
            var order = new Orders
            {
                UserId = postOrders.UserId
            };
            _context.Add(order);
            _context.SaveChanges();
            foreach(var item in postOrders.CartProducts)
            {
                var product = _context.Products.Single(x => x.Id == item.Id);
                var od = new OrdersDetails
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.InCart
                };
                _context.Add(od);
                _context.SaveChanges();
                product.Quantity = product.Quantity - item.InCart;
                _context.Update(product);
                _context.SaveChanges();
            }
            return order.Id;
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
