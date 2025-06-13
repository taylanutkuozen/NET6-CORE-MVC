using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
namespace Presentation.AddControllers
{
    [Route("api/product")]/*Erisim icin route yapisi*/
    [ApiController] /*Api ozelligi kazandirdik.*/
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_serviceManager.ProductService.GetAllProducts(false));
        }
    }
}