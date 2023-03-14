namespace WAD_Portfolio_11359.Models
{
    public class Menu
    {
        //department=menu
        public int Id { get; set; }
        public string Name { get; set; }

        public void GenerateData()
        {
            Product p1 = new Product()
            {
                Id = 1,
                Name = "Apple Pie",
                Price = 100000
            };

            Product p2 = new Product()
            {
                Id = 2,
                Name = "Croussans",
                Price = 15000
            };

            Product p3 = new Product()
            {
                Id = 3,
                Name = "Chocolate Cake",
                Price = 170000
            };

            Product p4 = new Product()
            {
                Id = 4,
                Name = "Candies",
                Price = 10456
            };


        }
    }
}
