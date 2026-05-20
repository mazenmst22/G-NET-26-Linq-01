#region Using directives
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
#endregion

using static G_NET_26_Linq_01.DataSource.Source;
namespace G_NET_26_Linq_01
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            #region Q1

            var seafoodProducts = ProductList.Where(p => p.Category == "Seafood");

            foreach (var product in seafoodProducts)
            {
                Console.WriteLine($"Name: {product.ProductName},Category: {product.Category}");
            }

            #endregion
            #region Q2
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var productNames = ProductList.Select(p => p.ProductName);

            foreach (var name in productNames)
            {
                Console.Write($"{name}, ");
            }

            #endregion
            #region Q3
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var sortedProducts = ProductList.OrderBy(p => p.UnitPrice);

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: ${product.UnitPrice}");
            }


            #endregion
            #region Q4
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var filteredProducts = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.ProductName}, Price: ${product.UnitPrice}");
            }
            #endregion
            #region Q5
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var inStock = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var product in inStock)
            {
                Console.WriteLine($"Product: {product.ProductName}, Category: {product.Category}, Stock: {product.UnitsInStock}");
            }
            #endregion
            #region Q6
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var productStatus = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                Status = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in productStatus)
            {
                Console.WriteLine($"Name: {item.Name}, Price: ${item.Price}, Availability: {item.Status}");
            }
            #endregion
            #region Q7
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var idx = ProductList.Select((p,index)=> new
            {
                Position = index+1,
                Name = p.ProductName,
                
            });
            foreach(var item in idx)
            {
                Console.WriteLine($"{item.Position}.{item.Name}");
            }
            #endregion
            #region Q8
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var Sorted = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Name: {product.ProductName}, Price: ${product.UnitPrice}");
            }
            #endregion
            #region Q9
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var BeverageSort = ProductList
                .Where(p =>  p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var product in BeverageSort)
            {
                Console.WriteLine($"{product.ProductName}, Stock: {product.UnitsInStock}");
            }
            #endregion
            #region Q10
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
           

            var recentOrders =
                from c in CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };

            foreach (var item in recentOrders)
            {
                Console.WriteLine($"Customer: {item.CustomerID}, Date: {item.OrderDate:dd/MM/yyyy}");
            }
            #endregion
            #region Q11
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            var idx1 = ProductList
            .Select((p, index) => new
            {
                Position = index + 1,
                Product = p
            });

            foreach (var item in idx1)
            {
                Console.WriteLine($"{item.Position}. {item.Product.ProductName}");
            }
            #endregion
            #region Q12
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region Q13
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();

            foreach (var digit in reversedIDigits)
            {
                Console.WriteLine(digit);
            }
            #endregion
        }
    }
}