namespace WAD_Portfolio_11359.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public Order Order { get; set; }

        public void ProductAdding(Product product)
        {
            StaticData.Products.Add(product);
        }
    }
}
