using System;

namespace WAD_Portfolio_11359
{
    public class Payment
    {
        public int Id { get; set; }
        public bool Type { get; set; }
        public DateTime PaidDate { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
