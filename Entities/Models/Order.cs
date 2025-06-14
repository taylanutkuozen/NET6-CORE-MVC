using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class Order
    {
        public int OrderID {get;set;}
        public ICollection<CartLine> Lines{get;set;}=new List<CartLine>();
        [Required(ErrorMessage="CustomerName is required")]
        public string? CustomerName { get; set; }
        [Required(ErrorMessage="Line1 is required.")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; }=DateTime.Now;
    }
}