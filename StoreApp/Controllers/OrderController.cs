using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
namespace StoreApp.Controllers
{
    public class OrderController:Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly Cart _cart;
        public OrderController(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager=serviceManager;
            _cart=cart;
        }
        [Authorize]
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        [ValidateAntiForgeryToken] //Sahteciliği onlemek amaciyla
        public IActionResult Checkout([FromForm]Order order)
        {
            if(_cart.Lines.Count()==0)
            {
                ModelState.AddModelError("","Sorry your cart is empty");
            }
            if(ModelState.IsValid)
            {
                order.Lines=_cart.Lines.ToArray();
                _serviceManager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new {OrderID=order.OrderID});
            }
            else
            {
                return View();
            }
        }
    }
}