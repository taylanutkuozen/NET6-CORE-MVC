using System.ComponentModel.DataAnnotations;
namespace Entities.Models;

public class Product
{
    public int ProductID { get; set; }
    [Required(ErrorMessage = "ProductName is required")]
    public string? ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Price is required")]
    public decimal ProductPrice { get; set; }
    public string? Summary { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
    public int? CategoryID { get; set; } //Foreign Key
    public Category? Category { get; set; } //Navigation property. Fiziksel bir kayıt olmayacak.
    public bool ShowCase{ get; set; }
}