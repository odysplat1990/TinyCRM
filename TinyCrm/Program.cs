using System;
using System.IO;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ody_s\devel\tinyCRM\productList.txt";
            bool uniqueId = true;
            Random random = new Random();

            if (!File.Exists(path))
            {
                Console.WriteLine("CSV file not found");
            }

            // Open the file to read from.
            string[] readText = File.ReadAllLines(path);
            Product[] P = new Product[readText.Length];
            int i = 0;
            foreach (string row in readText)
            {
                string[] data = row.Split(';');

                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (data[0] == P[j].ProductId)
                        {
                            uniqueId = false;
                            //Console.WriteLine(P[j].ProductId);
                            Console.WriteLine($"Product ID {data[0]} already exists");
                            break;
                        }
                    }
                }

                if (uniqueId)
                {
                    P[i] = new Product(data[0], data[1], data[2], Convert.ToDecimal(Math.Round(random.NextDouble() * 1000, 2)));
                }
                else
                {
                    P[i] = new Product("invalid", "invalid", "invalid", 0M);
                }

                i += 1;
                uniqueId = true;
            }
        }
    }
}
