using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;
using StoreApp.Models;
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
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }
        public IActionResult Index(ProductRequestParameters productParameters)
        {
            var products= _manager.ProductService.GetAllProductsWithDetails(productParameters);
            var pagination = new Pagination()
            {
                CurrentPage = productParameters.PageNumber,
                ItemsPerPage = productParameters.PageSize,
                TotalItems=_manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination=pagination
            });
        }
    }        
}