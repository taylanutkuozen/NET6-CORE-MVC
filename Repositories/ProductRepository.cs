using System.Reflection.Metadata.Ecma335;
using Entities.Models;
using Repositories.Contracts;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Extensions;
namespace Repositories
{
    /*sealed ifadesi ilgili class icin daha fazla kalitilamayacagini belirtir. Son hali anlamina gelmektedir.*/
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
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
        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters productParameters)
        {
            return _context.Products.FilteredByCategoryId(productParameters.CategoryId)
                            .FilteredBySearchTerm(productParameters.SearchTerm)
                            .FilteredByPrice(productParameters.MinPrice, productParameters.MaxPrice, productParameters.IsValidPrice)
                            .ToPaginate(productParameters.PageNumber,productParameters.PageSize);
            //RepositoryExtension                              
        }
    }
}