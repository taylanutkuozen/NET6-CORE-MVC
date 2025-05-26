using System.Reflection.Metadata.Ecma335;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        //Interface
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductID.Equals(id), trackChanges);
        }
        public void CreateProduct(Product product) => Create(product);
        public void DeleteProduct(Product product) => Remove(product);
        public void UpdateOneProduct(Product entity) => Update(entity);
        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges).Where(p => p.ShowCase.Equals(true));
        }
    }
}