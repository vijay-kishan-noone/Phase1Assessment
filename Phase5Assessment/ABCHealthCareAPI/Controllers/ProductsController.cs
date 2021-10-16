using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABCHealthCareAPI.Models;

namespace ABCHealthCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ABCHealthCareDBContext _context;

        public ProductsController(ABCHealthCareDBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<JointProduct>> GetProducts(int page=1,int limit=10,string categoryName="all")
        {
            var testObj = new List<JointProduct>();
            if (categoryName == "all")
            {
                foreach (var product in _context.Products.ToList())
                {
                    var cat = _context.Categories.Single(x => x.Id == product.CatId);
                    testObj.Add(new JointProduct { Id = product.Id, Title = product.Title, Description = product.Description, Image = product.Image, Images = product.Images, Price = product.Price, Quantity = product.Quantity, Category = cat.Title });
                }
                if (testObj.Skip((page - 1) * limit).Take(limit).ToList().Count() == 0)
                    return NotFound();
                return testObj.Skip((page - 1) * limit).Take(limit).ToList();
            }
            var category = _context.Categories.Single(x => x.Title.ToLower() == categoryName.ToLower());
            foreach (var product in _context.Products.ToList())
            {
                if (product.CatId == category.Id)
                    testObj.Add(new JointProduct { Id = product.Id, Title = product.Title, Description = product.Description, Image = product.Image, Images = product.Images, Price = product.Price, Quantity = product.Quantity, Category = category.Title });
            }
            if (testObj.Skip((page - 1) * limit).Take(limit).ToList().Count() == 0)
                return NotFound();
            return testObj.Skip((page - 1) * limit).Take(limit).ToList();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JointProduct>> GetProducts(int id)
        {
            var jointProduct = new JointProduct();
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            jointProduct.Id = products.Id;
            jointProduct.Title = products.Title;
            jointProduct.Description = products.Description;
            jointProduct.Image = products.Image;
            jointProduct.Images = products.Images;
            jointProduct.Price = products.Price;
            jointProduct.Quantity = products.Quantity;
            jointProduct.Category = _context.Categories.Single(x => x.Id == products.CatId).Title;

            return jointProduct;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(JointProduct products)
        {
            var product = new Products();
            product.Id = products.Id;
            product.Title = products.Title;
            product.Description = products.Description;
            product.Image = products.Image;
            product.Images = products.Images;
            product.ShortDesc = "";
            product.Price = products.Price;
            product.Quantity = products.Quantity;
            product.CatId = _context.Categories.Single(x => x.Title == products.Category).Id;
            _context.Update(product);
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JointProduct>> PostProducts(JointProduct products)
        {
            var product = new Products();
            product.Title = products.Title;
            product.Description = products.Description;
            product.Image = products.Image;
            product.Images = products.Images;
            product.Price = products.Price;
            product.Quantity = products.Quantity;
            product.ShortDesc = "";
            product.CatId = _context.Categories.Single(x => x.Title == products.Category).Id;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }
    }
}
