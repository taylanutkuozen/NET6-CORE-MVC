using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] //Area tanımlamak için ihtiyaç vardır.
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}