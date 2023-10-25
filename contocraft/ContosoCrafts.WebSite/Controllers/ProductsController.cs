using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.productService = productService;
        }
        public JsonFileProductService productService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        // HttpPathch
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId, 
            [FromQuery] int Rating)
        {
            productService.AddRating(ProductId, Rating);
            return Ok(); 
        }
    }
}
