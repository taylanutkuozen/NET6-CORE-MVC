using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager=repositoryManager;
        }
        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _repositoryManager.Category.FindAll(trackChanges);
        }
    }
}