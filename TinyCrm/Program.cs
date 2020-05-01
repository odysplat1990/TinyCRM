using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"productList.txt";
            string[] productsFromFile;

            // Open the file to read from.
            try
            {
                productsFromFile = File.ReadAllLines(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
                return;
            }


            if (productsFromFile.Length == 0)
            {
                return;
            }

            //var productsArray = new Product[productsFromFile.Length];
            var productsList = new List<Product>();

            for (var i = 0; i < productsFromFile.Length; i++)
            {
                var values = productsFromFile[i].Split(';');
                var productId = values[0];

                var l = productsList.Where(product => product.ProductId.Equals(productId));

                if (l.Count() > 0)
                {
                    continue;
                }

                var product = new Product()
                {
                    ProductId = values[0],
                    Name = values[1],
                    Description = values[2],
                    Price = GetRandomPrice()
                };

                productsList.Add(product);
            }

            foreach (var p in productsList)
            {
                if (p != null)
                {
                    Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");
                }
            }
        }
        public static decimal GetRandomPrice()
        {
            var random = new Random();
            var randomNumber = random.NextDouble() * 100;
            var roundedNumber = Math.Round(randomNumber, 2);
            return (decimal)roundedNumber;
        }
    }


}
