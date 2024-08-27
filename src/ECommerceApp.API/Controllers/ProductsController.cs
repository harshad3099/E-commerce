using ECommerceApp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Example of a simple GET method
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            // Assuming you have some method to get products
            var products = new List<Product>();  // Replace with actual data access code
            return Ok(products);
        }
    }
}
