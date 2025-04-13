using System.ComponentModel.DataAnnotations;
namespace Entities.Dtos
{
    public record ProductDto
    {
    public int ProductID { get; init; }
    [Required(ErrorMessage="ProductName is required")]
    public string? ProductName { get; init; } = String.Empty;
    [Required(ErrorMessage="Price is required")]
    public decimal ProductPrice { get; init; }
    public string? Summary {get;init;}=String.Empty;
    public string? ImageUrl {get;set;}
    public int? CategoryID {get;init;}
    }
}
//Immutable olmak = Veriyi bir kez verdiğimiz zaman verinin değişmeyeceği yönünde garanti vermiş oluruz.