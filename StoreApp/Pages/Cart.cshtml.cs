using Microsoft.AspNetCore.Mvc.RazorPages; //PageModel library
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; } //IoC kaydi yapilacaktir.
        public CartModel(IServiceManager manager,Cart cart)
        {
            _manager=manager;
            Cart=cart;
        }
        public string ReturnUrl{get;set;}
        public void OnGet(string returnUrl)
        /*Bu sayfa sunucudan talep edildiginde, kullaniciya ne donulecek bu bilgiyi paylasacagiz*/
        {
            //Hangi sayfadan eristiyse, o sayfaya kullanici geri donebilsin
            ReturnUrl=returnUrl ?? "/";//??--> eger ifade referans almadiysa diye kullanildi.
        }
        public IActionResult OnPost(int productID, string returnUrl)
        {
            /*IActionResult parametrelerini Razorpage icerisinde
            kullanabiliriz.Library'si paylasildigi surece.
            IActionResult view ifadelerini tutabildigi gibi, referansini saklayabildigi gibi
            Page ifadelerininde referansini saklayabiliyor.*/
            Product? product=_manager.ProductService.GetOneProduct(productID,false);
            if(product is not null)
            {
                Cart.AddItem(product,1);
            }
            return Page(); //returnUrl logic yapilabilir.
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductID.Equals(id)).Product);
            return Page();
        }
    }
}