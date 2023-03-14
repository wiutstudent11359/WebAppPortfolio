using WAD_Portfolio_11359.Models;

namespace WAD_Portfolio_11359
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
    }
}
