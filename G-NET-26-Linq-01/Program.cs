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
            public double UnitPrice { get; set; }
            public int unitsInStock { get; set; }
        }
        //Q10
        public class Order
        {
            public DateTime OrderDate { get; set; }
        }

        public class Customer
        {
            public string CustomerID { get; set; }
            public List<Order> Orders { get; set; }
        }
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
            new Product { Name = "Ikura", Category = "Seafood", UnitPrice = 31.00, unitsInStock = 13 },
            new Product { Name = "Chai", Category = "Beverages", UnitPrice  = 2.35, unitsInStock = 110 },
            new Product { Name = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.40, unitsInStock =0 },
            new Product { Name = "Tofu", Category = "Produce", UnitPrice = 23.25, unitsInStock =35},
            new Product { Name = "Aniseed Syrup", Category = "Condiments",UnitPrice =12.00,  unitsInStock = 13 },
            new Product { Name = "Chef Anton's Cajun Seasoning", Category = "Condiments",UnitPrice =18.00, unitsInStock = 0 },
            new Product { Name = "Grandma's Boysenberry Spread", Category = "Condiments",UnitPrice =23.34, unitsInStock = 120 },
            new Product { Name = "Karak", Category = "Beverages",UnitPrice =4.75, unitsInStock = 35 }
            };

            #region Q1

            var seafoodProducts = products.Where(p => p.Category == "Seafood");

            foreach (var product in seafoodProducts)
            {
                Console.WriteLine($"Name: {product.Name},Category: {product.Category}");
            }

            #endregion
            #region Q2
            Console.WriteLine();
            var productNames = products.Select(p => p.Name);

            foreach (var name in productNames)
            {
                Console.Write($"{name}, ");
            }

            #endregion
            #region Q3
            Console.WriteLine();
            var sortedProducts = products.OrderBy(p => p.UnitPrice);

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Name: {product.Name}, Price: ${product.UnitPrice}");
            }


            #endregion
            #region Q4
            Console.WriteLine();
            var filteredProducts = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name}, Price: ${product.UnitPrice}");
            }
            #endregion
            #region Q5
            Console.WriteLine();
            var inStock = products.Where(p => p.unitsInStock > 0 && p.Category == "Condiments");

            foreach (var product in inStock)
            {
                Console.WriteLine($"Product: {product.Name}, Category: {product.Category}, Stock: {product.unitsInStock}");
            }
            #endregion
            #region Q6
            Console.WriteLine();
            var productStatus = products.Select(p => new
            {
                Name = p.Name,
                Price = p.UnitPrice,
                Status = p.unitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in productStatus)
            {
                Console.WriteLine($"Name: {item.Name}, Price: ${item.Price}, Availability: {item.Status}");
            }
            #endregion
            #region Q7
            Console.WriteLine();
            var idx = products.Select((p,index)=> new
            {
                Position = index+1,
                Name = p.Name,
                
            });
            foreach(var item in idx)
            {
                Console.WriteLine($"{item.Position}.{item.Name}");
            }
            #endregion
            #region Q8
            Console.WriteLine();
            var Sorted = products
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Name: {product.Name}, Price: ${product.UnitPrice}");
            }
            #endregion
            #region Q9
            Console.WriteLine();
            var BeverageSort = products
                .Where(p =>  p.Category == "Beverages")
                .OrderByDescending(p => p.unitsInStock);
            foreach (var product in BeverageSort)
            {
                Console.WriteLine($"{product.Name}, Stock: {product.unitsInStock}");
            }
            #endregion
            #region Q10
            Console.WriteLine();
            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = "KEHBMP",
                    Orders = new List<Order>
                    {
                        new Order { OrderDate = new DateTime(1996, 8, 25) },
                        new Order { OrderDate = new DateTime(1997, 10, 3) },
                        new Order { OrderDate = new DateTime(1998, 1, 15) }
                    }
                },
                new Customer
                {
                    CustomerID = "ANATR",
                    Orders = new List<Order>
                    {
                        new Order { OrderDate = new DateTime(1996, 11, 28) }
                    }
                },
                new Customer
                {
                    CustomerID = "BERGS",
                    Orders = new List<Order>
                    {
                        new Order { OrderDate = new DateTime(1997, 3, 4) }
                    }
                }
            };

            var recentOrders =
                from c in customers
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };

            foreach (var item in recentOrders)
            {
                Console.WriteLine($"Customer: {item.CustomerID}, Date: {item.OrderDate:dd/MM/yyyy}");
            }
            #endregion

        }
    }
}