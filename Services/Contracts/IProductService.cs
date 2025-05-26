using Entities.Dtos;
using Entities.Models;
namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProductService(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
    }
}