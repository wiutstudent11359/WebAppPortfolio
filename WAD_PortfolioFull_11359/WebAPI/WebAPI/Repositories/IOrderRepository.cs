using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IOrderRepository
    {
        void InsertOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(int orderid);

        Order GetOrderById(int Id);

        IEnumerable<Order> GetOrders();
    }
}
