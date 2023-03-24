using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;
using System.Transactions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: api/customer
        [HttpGet]
        public IActionResult Get()
        {
            var customer = _customerRepository.GetCustomer();
            return new OkObjectResult(customer);
        }
        // GET: api/customer/5
        [HttpGet("{id}", Name = "GetC")]
        public IActionResult Get(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return new OkObjectResult(customer);
        }
        // POST: api/customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            using (var scope = new TransactionScope())
            {
                _customerRepository.InsertCustomer(customer);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = customer.ID }, customer);
            }
        }
        // PUT: api/customer/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (customer != null)
            {
                using (var scope = new TransactionScope())
                {
                    _customerRepository.UpdateCustomer(customer);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return new OkResult();
        }
    }
}
