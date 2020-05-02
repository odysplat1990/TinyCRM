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
            //List with products of UNIQUE id's*********************************************************
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

            var order1 = new Order();
            var order2 = new Order();

            // Orders with 10 randomly selected products**************************************************
            List<int> firstList = CreateRandomUnique(productsList.Count());
            List<int> secondtList = CreateRandomUnique(productsList.Count());

            for (int j = 0; j < 10; j++) //to FOREACH den ginotan na xrhsimopoihthei
            {
                order1.ProductList.Add(productsList[firstList[j]]);
                productsList[firstList[j]].OrderList.Add(order1);
                order2.ProductList.Add(productsList[secondtList[j]]);
                productsList[secondtList[j]].OrderList.Add(order2);
                //Console.WriteLine(myList[j]);
            }



            //Create two Customers************************************************************************
            decimal customerValue1 = 0m;
            decimal customerValue2 = 0m;

            try
            {
                var customer1 = new Customer("123456789");
                customer1.OrderList.Add(order1);
                customerValue1 = customer1.OrderList[0].Total();
                //for (int j = 0; j < 10; j++) //to FOREACH den ginotan na xrhsimopoihthei
                //{
                //    Console.WriteLine(customer1.OrderList[0].ProductList[j].Description);
                //}
                //Console.WriteLine(customer1.OrderList[0].OrderId);
                //customerValue1 = customer1.OrderList[0].TotalAmount;
                //Console.WriteLine(customerValue1);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                var customer2 = new Customer("111111111");
                customer2.OrderList.Add(order2);
                customerValue2 = customer2.OrderList[0].Total();
                //Console.WriteLine(customerValue2);
            }
            catch (Exception)
            {
                return;
            }

            //output the most valuable customer*************************************************
            if (customerValue1 > customerValue2)
            {
                Console.WriteLine($"the most valuable customer is customer1");
            }
            else if (customerValue1 < customerValue2)
            {
                Console.WriteLine($"the most valuable customer is customer2");
            }
            else
            {
                Console.WriteLine($"both customers spend the same");
            }

            //5 most sold products
            var sdf = productsList.OrderByDescending(product => product.OrderList.Count());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(sdf.ToList()[i].ProductId);
            }


        }
        public static decimal GetRandomPrice()
        {
            var random = new Random();
            var randomNumber = random.NextDouble() * 100;
            var roundedNumber = Math.Round(randomNumber, 2);
            return (decimal)roundedNumber;
        }

        public static List<int> CreateRandomUnique(int productListSize)
        {
            Random rand = new Random();
            int myNumber;
            var j = 0;
            List<int> randomList = new List<int>();

            while (j < 10)
            {
                myNumber = rand.Next(productListSize - 1);
                if (!randomList.Contains(myNumber))
                {
                    randomList.Add(myNumber);
                    j++;
                }
            }
            return randomList;
        }
    }


}
