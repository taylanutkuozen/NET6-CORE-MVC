using Entities.Models;
using Entities.RequestParameters;
namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters productParameters);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateOneProduct(Product entity);
    }
}