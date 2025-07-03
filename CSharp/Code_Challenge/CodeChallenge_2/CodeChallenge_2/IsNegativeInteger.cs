using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
   3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative.
   Handle the exception in the calling code.
*/

namespace CodeChallenge_2
{
    class IsNegativeInteger
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Input Integer: ");
                int Number = Convert.ToInt32(Console.ReadLine());
                if(Number < 0)
                {
                    throw new NegativeNumberException("Entered Number is Negative...Try Using Only Positive Number..");
                }
                else
                {
                    Console.WriteLine("Number is {0}", Number);
                    Console.WriteLine("Thankyou for using our service!!...Have a Good Day");
                }
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }

    class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException(string message) : base(message) { }
    }

}
