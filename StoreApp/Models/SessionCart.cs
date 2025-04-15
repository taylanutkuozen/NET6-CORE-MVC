using Entities.Models;
using StoreApp.Infrastructure.Extensions; 
using System.Text.Json.Serialization;
namespace StoreApp.Models
{
    public class SessionCart:Cart
    {
        [JsonIgnore] //Session tekrar yazilmasin diye Deserialize isleminde ignore edilsin diye bu komut kullanildi.
        public ISession? Session { get; set; }
        public static SessionCart GetCart(IServiceProvider services)
        {
            ISession? session=services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;    
            SessionCart cart=session?.GetJson<SessionCart>("cart")?? new SessionCart(); 
            cart.Session=session;
            return cart;
        }
        public override void AddItem(Product product,int quantity)
        {
            base.AddItem(product,quantity);
            Session?.SetJson<SessionCart>("cart",this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart",this);
        }
    }
}