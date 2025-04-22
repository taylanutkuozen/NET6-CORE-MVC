using Entities.Models;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class OrderRepository:RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(RepositoryContext context) :base(context)
        {
            
        }
        public IQueryable<Order> Orders => _context.Orders.Include(o=>o.Lines).ThenInclude(c1=>c1.Product).OrderBy(o=>o.Shipped).ThenByDescending(o=>o.OrderID);
        public int NumberofInProcess => _context.Orders.Count(o=>o.Shipped.Equals(false));
        public void Complete(int id)
        {
            var order=FindByCondition(o=>o.OrderID.Equals(id),true);
            if(order is null)
                throw new Exception("Order could not found!");
            order.Shipped=true;
        }
        public Order? GetOrder(int id)
        {
            return FindByCondition(o=>o.OrderID.Equals(id),false);
        }
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l=>l.Product));
            if(order.OrderID==0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}