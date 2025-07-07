using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
     Write a query that returns list of numbers and their squares only if square is greater than 20 

    Example input [7, 2, 30]  
    Expected output
    → 7 - 49, 30 - 900

 */

namespace Assignment_7
{
    class IsSquareGreaterThanTwenty
    {
        public static void Main(string[] args)
        {
            Console.Write("Input size of List: ");
            int totalSize = Convert.ToInt32(Console.ReadLine());

            List<int> numbers = new List<int>();
            for (int i = 0; i < totalSize; i++)
            {
                Console.WriteLine("Input Number {0}", i + 1);
                int temp = Convert.ToInt32(Console.ReadLine());
                numbers.Add(temp);
            }

            var filtered = from n in numbers
                           let square = n * n
                           where square > 20
                           select new { Number = n, Square = square };

            Console.WriteLine("Output: List of Numbers and their Squares based on Criteria.....");
            foreach (var item in filtered)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }

            Console.Read();
        }
    }
}
