using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.DAL;
using System.Linq;

namespace WebAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderContext _dbContext;
        public CustomerRepository(OrderContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void DeleteCustomer(int customerid)
        {
            var customer = _dbContext.Customers.Find(customerid);
            _dbContext.Customers.Remove(customer);
            Save();
        }


        public Customer GetCustomerById(int Id)
        {
            var cate = _dbContext.Customers.Find(Id);

            return cate;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return _dbContext.Customers.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
             _dbContext.Add(customer);
            Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save() 
        {
            _dbContext.SaveChanges();
        }
    }
}
