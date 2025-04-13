using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public RepositoryManager(IProductRepository productRepository,ICategoryRepository categoryRepository,RepositoryContext context)
        {
            _context=context;
            _productRepository=productRepository;
            _categoryRepository=categoryRepository;
        }
        public IProductRepository Product =>  _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}