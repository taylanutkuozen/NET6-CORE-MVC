using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
namespace Services
{
    public class OrderManager:IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        public OrderManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager=repositoryManager;
        }
        public IQueryable<Order> Orders=>_repositoryManager.Order.Orders;
        public int NumberofInProcess=>_repositoryManager.Order.NumberofInProcess;
        public void Complete(int id)
        {
            _repositoryManager.Order.Complete(id);
            _repositoryManager.Save();
        }
        public Order? GetOrder(int id)
        {
            return _repositoryManager.Order.GetOrder(id);
        }
        public void SaveOrder(Order order)
        {
            _repositoryManager.Order.SaveOrder(order);
        }
    }
}