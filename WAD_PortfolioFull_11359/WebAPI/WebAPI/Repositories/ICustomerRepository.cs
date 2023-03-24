using System.Collections.Generic;
using WebAPI.Models;
namespace WebAPI.Repositories
{
    public interface ICustomerRepository
    {
        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(int customerid);

        Customer GetCustomerById(int Id);

        IEnumerable<Customer> GetCustomer();
    }
}
