using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_Portfolio_11359
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Product product = new Product
            {
                Name = "Apple Pie",
                Price = 123456
            };
            product.ProductAdding(product);
            Console.ReadLine();
        }

            /*public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });*/
    }
}
