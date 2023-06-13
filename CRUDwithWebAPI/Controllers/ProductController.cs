using CRUDwithWebAPI.DAL;
using CRUDwithWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDwithWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public ProductController(MyAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _context.students.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Products not available");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try
            {
                var product = _context.students.Find(id);
                if (product == null)
                {
                    return NotFound("Product details Not found");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Product created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public IActionResult Put(Product model) { 
        if(model==null || model.Id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if(model.Id == 0) {

                    return BadRequest("Product ID is invalid");

                }
            }
            try
            {
                var product = _context.students.Find(model.Id);
                if (product == null)
                {
                    return NotFound("Product is not found");
                }
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.SaveChanges();
                return Ok("Product details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _context.students.Find(id);
                if (product == null)
                {
                    return NotFound("Product is not found");
                }
                _context.students.Remove(product);
                _context.SaveChanges();
                return Ok("Product details deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
