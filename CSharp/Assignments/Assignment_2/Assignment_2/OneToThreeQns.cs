using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class OneToThreeQns
    {
        enum days { Monday = 1, Tuesday, Wednesday, Thrusday, Friday, Saturday, Sunday};
        static void Main(string[] args)
        {
            Console.WriteLine("***** 1. Swapping Numbers *****");
            SwapNumber();
            Console.WriteLine();

            Console.WriteLine("***** 2. Printing Model *****");
            PrintingModel();
            Console.WriteLine();

            Console.WriteLine("***** 3. Finding a Day of the Week *****");
            DisplayDayOfInteger();
            Console.WriteLine();


            Console.Read();
        }

        //1. Write a C# Sharp program to swap two numbers.

        public static void SwapNumber()
        {
            Console.Write("Input 1st Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before Swapping");
            Console.WriteLine($"Num1 = {num1} , Num2 = {num2}");

            int temp;
            //Swapping Logic
            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After Swapping Using Value Type");
            Console.WriteLine($"Num1 = {num1} , Num2 = {num2}");
        }

        /* 2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

                Test Data:
                Enter a digit: 25

                Expected Output:
                25 25 25 25
                25252525
                25 25 25 25
                25252525

        */

        public static void PrintingModel()
        {
            Console.Write("Enter a digit: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {1} {2} {3}", num, num, num, num);
            Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);
            Console.WriteLine("{0} {1} {2} {3}", num, num, num, num);
            Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);

        }

        /*
           3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

                Test Data / input: 2

                Expected Output :
                Tuesday
         */

        public static void DisplayDayOfInteger() {
            Console.Write("Enter the Day of the Week In Integer: ");
            int day = Convert.ToInt32(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(days)))
            {
                if (i == day)
                {
                    Console.WriteLine(Enum.GetName(typeof(days),i));
                }
            }
        }



    }
}
