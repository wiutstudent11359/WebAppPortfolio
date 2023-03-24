using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.DAL
{
    public class OrderContext:DbContext
    {
        // Constructer
        public OrderContext(DbContextOptions<OrderContext> o) : base(o) 
        {
            Database.EnsureCreated();
        }

        // Order Database
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
