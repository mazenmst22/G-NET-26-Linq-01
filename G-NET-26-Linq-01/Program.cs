#region Using directives
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
#endregion
namespace G_NET_26_Linq_01
{
    public class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
        }
        public static void Main(string[] args)
        {
            #region Q1
                //List<Product> products = new List<Product>
                //{
                //new Product { Name = "Ikura", Category = "Seafood" },
                //new Product { Name = "Chai", Category = "Beverages" },
                //new Product { Name = "Boston Crab Meat", Category = "Seafood" },
                //new Product { Name = "Tofu", Category = "Produce" }
                //};

                //var seafoodProducts = products.Where(p => p.Category == "Seafood");

                //foreach (var product in seafoodProducts)
                //{
                //    Console.WriteLine($"Name: {product.Name},Category: {product.Category}");
                //}

            #endregion
        }
    }
}