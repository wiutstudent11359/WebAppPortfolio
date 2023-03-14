using System;

namespace WAD_Portfolio_11359.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime OrderedDate { get; set; }
        public PaymentContext Payment { get; set; }
        public Product Product { get; set; }
    }
}
