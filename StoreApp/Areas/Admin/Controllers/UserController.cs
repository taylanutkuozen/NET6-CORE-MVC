using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            var users = _serviceManager.AuthService.GetAllUsers();
            return View(users);
        }
    }
}