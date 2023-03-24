using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal  Price { get; set; }

        public Customer Customer{ get; set; }
    }
}
