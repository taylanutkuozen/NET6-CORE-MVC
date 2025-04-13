using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager=manager;
        }
          public IActionResult Get([FromRoute(Name ="id")]int id) //request = http://localhost:5135/Product/Get/1
        {
            var model=_manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
        public IActionResult Index()
        {
            var model= _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        /*public IEnumerable<Product> Index()
        {
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("Data Source=C:\\Users\\utku.ozen\\source\\repos\\ASPNET Core MVC\\ProductDb.db")
                .Options 
            ); Dependency Injection sayesinde buradan kurtuluyoruz.
            return new List<Product>()
            {
                new Product(){ProductID=1, ProductName="Computer", ProductPrice=5}
            };*/
    }        
}