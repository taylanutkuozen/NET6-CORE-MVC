using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetAllProducts(trackChanges);
        }
        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
            var products = _repositoryManager.Product.GetShowCaseProducts(trackChanges);
            return products;
        }
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
            {
                throw new Exception("Product not found!");
            }
            else
            {
                return product;
            }
        }
        public void CreateProductService(ProductDtoForInsertion productDto)
        {
            /*Product product=new Product()
            {
              ProductName=productDto.ProductName,
              ProductPrice=productDto.ProductPrice,
              CategoryID=productDto.CategoryID  
            };Automapper kullanılmadan*/
            Product product = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.Create(product);
            _repositoryManager.Save();
        }
        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity=_repositoryManager.Product.GetOneProduct(productDto.ProductID,true);
            //entity.ProductName=productDto.ProductName;
            //entity.ProductPrice=productDto.ProductPrice;
            //entity.CategoryID=productDto.CategoryID;
            var entity = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.UpdateOneProduct(entity);
            _repositoryManager.Save();
        }
        public void DeleteOneProduct(int id)
        {
            Product product = _repositoryManager.Product.GetOneProduct(id, false);
            if (product is not null)
            {
                _repositoryManager.Product.DeleteProduct(product);
                _repositoryManager.Save();
            }
        }
        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, false);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }
        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters productParameters)
        {
            return _repositoryManager.Product.GetAllProductsWithDetails(productParameters);
        }
    }
}