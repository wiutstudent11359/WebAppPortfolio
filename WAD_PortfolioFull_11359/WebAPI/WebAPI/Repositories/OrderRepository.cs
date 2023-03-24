using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly OrderContext _dbContext;
        public OrderRepository(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrder(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(order);
            Save();
        }
        public Order GetOrderById(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            _dbContext.Entry(order).Reference(s => s.Customer).Load();
            return order;
        }
        public IEnumerable<Order> GetOrders()
        {

            return _dbContext.Orders.Include(s => s.Customer).ToList();
        }
        public void InsertOrder(Order order)
        {

            order.Customer = _dbContext.Customers.Find(order.Customer);
            _dbContext.Add(order);
            Save();
        }
        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        

    }
}
