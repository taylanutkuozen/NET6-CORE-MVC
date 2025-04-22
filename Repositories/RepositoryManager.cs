using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public RepositoryManager(IProductRepository productRepository,ICategoryRepository categoryRepository,RepositoryContext context,IOrderRepository orderRepository)
        {
            _context=context;
            _productRepository=productRepository;
            _categoryRepository=categoryRepository;
            _orderRepository=orderRepository;
        }
        public IProductRepository Product =>  _productRepository;
        public ICategoryRepository Category => _categoryRepository;
        public IOrderRepository Order=>_orderRepository;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}