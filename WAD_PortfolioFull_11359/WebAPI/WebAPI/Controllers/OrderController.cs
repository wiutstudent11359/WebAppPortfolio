using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DAL;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetOrders();
            return new OkObjectResult(orders);
            //return new string[] { "value1", "value2" };
        }
        // GET: api/Order/5
        [HttpGet, Route("{id}", Name = "GetO")]
        public IActionResult Get(int id)
        {
            var Order = _orderRepository.GetOrderById(id);
            return new OkObjectResult(Order);
            //return "value";
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody]Order Order)
        {
            using (var scope = new TransactionScope())
            {
                _orderRepository.InsertOrder(Order);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Order.ID }, Order);
            }
        }
        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Order Order)
        {
            if (Order != null)
            {
                using (var scope = new TransactionScope())
                {
                    _orderRepository.UpdateOrder(Order);
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
            _orderRepository.DeleteOrder(id);
            return new OkResult();
        }

    }
}
