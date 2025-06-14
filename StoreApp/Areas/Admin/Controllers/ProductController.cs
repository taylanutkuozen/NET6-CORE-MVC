using System.Threading;//.RateLimiting;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using StoreApp.Models;
namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryID", "CategoryName", "1");//1.parametresi neleri liste haline getireceğiz, 2.parametre selected value olarak ne kullanacağız,3.parametre arayüzde ne görülecek, 4.parametre default olarak 1 görülecek. SelectList bir TagHelper nesnesidir.
        }
        public IActionResult Index([FromQuery]ProductRequestParameters productRequestParameters)
        {
            var products= _manager.ProductService.GetAllProductsWithDetails(productRequestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = productRequestParameters.PageNumber,
                ItemsPerPage = productRequestParameters.PageSize,
                TotalItems=_manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination=pagination
            });
        }
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//Formun doğrulanması için kullanılan komut
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file) //Gelecek file dosyalarini karsilamak icin IFormFile nesnesinden parametre gerekli
        {
            if (ModelState.IsValid)
            {
                //File Operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);//Ilk parametre uygulamanin calistigi dizin. Ikinci parametre olarak wwwroot ve wwwroot icerisindeki images dizini. file gelen dosyanın hem ismi hemde uzantısı son parametre olarak verildi.
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.ProductService.CreateProductService(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //File Operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);//Ilk parametre uygulamanin calistigi dizin. Ikinci parametre olarak wwwroot ve wwwroot icerisindeki images dizini. file gelen dosyanın hem ismi hemde uzantısı son parametre olarak verildi.
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}