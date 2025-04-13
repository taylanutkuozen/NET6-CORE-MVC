using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] //Area tanımlamak için ihtiyaç vardır.
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}