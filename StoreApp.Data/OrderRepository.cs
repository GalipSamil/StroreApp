using StoreApp.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entities.Models;


namespace StoreApp.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(StoreAppContext context) : base(context) 
        {

        }

        public IQueryable<Order> Orders => _context.Orders              
            .Include(o => o.Lines)
            .ThenInclude(c1 => c1.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);
        


        public int NumberOfInProcess =>
            _context.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order =FindByCondition(o => o.OrderId.Equals(id),true);
            if(order is null)
                throw new Exception("Order could not found");
            order.Shipped = true;
            

            
        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(o => o.OrderId.Equals(id),false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(ı => ı.Product));
            if(order.OrderId == 0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }

       
    }
}
