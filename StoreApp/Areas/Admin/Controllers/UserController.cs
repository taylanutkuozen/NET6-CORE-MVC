using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_serviceManager.AuthService.Roles.Select(r => r.Name).ToList())
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _serviceManager.AuthService.CreateUser(userDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }
        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _serviceManager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.Update(userDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto resetPasswordDto)
        {
            var result=await _serviceManager.AuthService.ResetPassword(resetPasswordDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View(resetPasswordDto);
        }
    }
}