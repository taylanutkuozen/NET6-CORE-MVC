using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters productParameter);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProductService(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
    }
}