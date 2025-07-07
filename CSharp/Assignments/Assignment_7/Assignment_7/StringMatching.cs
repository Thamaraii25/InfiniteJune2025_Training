using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     Write a query that returns words starting with letter 'a' and ending with letter 'm'.
    Expected input and output
    "mum", "amsterdam", "bloom" → "amsterdam"
 */

namespace Assignment_7
{
    class StringMatching
    {
        public static void Main(String[] args)
        {

            Console.Write("Input total size of List(String Type): ");
            int totalSize = Convert.ToInt32(Console.ReadLine());
            List<String> stringList = new List<string>();
            for(int i = 0; i < totalSize; i++)
            {
                Console.WriteLine("Input String {0}",i+1);
                stringList.Add(Console.ReadLine());
            }

            var filteredList = from s in stringList
                               let strLower = s.ToLower()
                               where strLower.StartsWith("a") && strLower.EndsWith("m")
                               select s;


            Console.WriteLine("\nResult based on Filteration");
            foreach(var item in filteredList)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
