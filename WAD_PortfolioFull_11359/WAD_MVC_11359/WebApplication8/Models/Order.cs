using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_MVC_11359.Models
{
    public class Order
    {
        public int ID { get; set; }
        public bool Delivered { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }

        public Customer Customer { get; set; }
       // public int OrderCustomerId { get; set; }

    }
}
