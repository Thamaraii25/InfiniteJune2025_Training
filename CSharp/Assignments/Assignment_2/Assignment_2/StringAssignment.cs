using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class StringAssignment
    {
        public static void Main()
        {
            Console.WriteLine("***** 1. Length of String *****");
            LengthOfString();
            Console.WriteLine();

            Console.WriteLine("***** 2. Reverse of String *****");
            ReverseOfString();
            Console.WriteLine();

            Console.WriteLine("***** 3. IsEqualString *****");
            isEqualString();
            Console.WriteLine();

            Console.Read();
        }



        // 1.	Write a program in C# to accept a word from the user and display the length of it.

        public static void LengthOfString()
        {
            Console.Write("Input String: ");
            string str = Console.ReadLine();
            Console.WriteLine("Length of String: {0}" ,str.Length);

        }

       //  2.	Write a program in C# to accept a word from the user and display the reverse of it. 

        public static void ReverseOfString()
        {
            Console.Write("Input String: ");
            string str = Console.ReadLine();
            string reverseString = "";
            for(int i = str.Length - 1; i >= 0; i--)
            {
                reverseString += str[i];
            }
            Console.WriteLine($"Reverse Of that String:{ reverseString}");
        }

        public static void isEqualString()
        {
            Console.Write("Enter 1st String: ");
            string str1 = Console.ReadLine();
            Console.Write("Enter 2nd String: ");
            string str2 = Console.ReadLine();

            bool result = (str1.Equals(str2));
            Console.WriteLine($"Is {str1} and {str2} are Equal: {result} ");
        }
    }
}
