namespace Entities.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }=String.Empty;
        public ICollection<Product> Products {get;set;} //Collection navigation property=nesneler arasında gezinmemizi sağlar.
    }
}