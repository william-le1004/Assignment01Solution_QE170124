using Assignment01Solution_QE170124.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Laptop", UnitPrice = 999.99M, UnitsInStock = 10 },
            new Product { ProductID = 2, ProductName = "Phone", UnitPrice = 699.99M, UnitsInStock = 50 }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = updatedProduct.ProductName;
            product.UnitPrice = updatedProduct.UnitPrice;
            product.UnitsInStock = updatedProduct.UnitsInStock;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }
    }
}
