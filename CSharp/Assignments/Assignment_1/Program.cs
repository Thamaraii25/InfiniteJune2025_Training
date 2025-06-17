using System;


namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Question 1 : IsEqualInteger *****");
            isEqualInteger();
            Console.WriteLine();


            Console.WriteLine("***** Question 2 : IsPositiveOrNegative ****");
            isPositiveOrNegative();
            Console.WriteLine();


            Console.WriteLine("***** Question 3 : ArithmeticOperations *****");
            arithmeticOperations();
            Console.WriteLine();

            Console.WriteLine("***** Question 4: MultiplicationTable *****");
            multiplicationTable();
            Console.WriteLine();

            Console.WriteLine("***** Question 5: SumOrTripleOfSum *****");
            SumOrTripleOfSum();
            Console.WriteLine();

            Console.Read();

        }

        /*
         1. Write a C# Sharp program to accept two integers and check whether they are equal or not. 

                Test Data :
                Input 1st number: 5
                Input 2nd number: 5
                Expected Output :
                5 and 5 are equal
         */

        public static void isEqualInteger()
        {
            Console.Write("Input 1st number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            string result = (num1 == num2) ? "Equal" : "Not Equal";
            Console.WriteLine($"{num1} and {num2} are {result}");
        }


        /*
         2. Write a C# Sharp program to check whether a given number is positive or negative. 

            Test Data : 14
            Expected Output :
            14 is a positive number
         */

        public static void isPositiveOrNegative()
        {
            Console.Write("Input number: ");
            int number = int.Parse(Console.ReadLine());
            string result = (number < 0) ? "Negative" : "Positive";
            Console.WriteLine($"{number} is {result}");
        }

        /*
         3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

            Test Data
            Input first number: 20
            Input operation: -
            Input second number: 12
            Expected Output :
            20 - 12 = 8
         */

        public static void arithmeticOperations()
        {
            Console.Write("Input first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Operation: ");
            string symbol = Console.ReadLine();
            Console.Write("Input second number: ");
            
            int num2 = Convert.ToInt32(Console.ReadLine());
  
            switch (symbol)
            {
                case "+":
                    {
                        int result = num1 + num2;
                        Console.WriteLine($"{num1} {symbol} {num2} = {result}");
                        break;
                    }
                case "-":
                    {
                        int result = num1 - num2;
                        Console.WriteLine($"{num1} {symbol} {num2} = {result}");
                        break;
                    }
                case "*":
                    {
                        int result = num1 * num2;
                        Console.WriteLine($"{num1} {symbol} {num2} = {result}");
                        break;
                    }
                case "/":
                    {
                        float result = num1 / num2;
                        Console.WriteLine($"{num1} {symbol} {num2} = {result}");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }
        }

        /*
         4. Write a C# Sharp program that prints the multiplication table of a number as input.

                Test Data:
                Enter the number: 5
                Expected Output:
                5 * 0 = 0
                5 * 1 = 5
                5 * 2 = 10
                5 * 3 = 15
                ....
                5 * 10 = 50
         */

        public static void multiplicationTable()
        {
            Console.Write("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }

        /*
         5. Write a C# program to compute the sum of two given integers. 
           If two values are the same, return the triple of their sum.
         */

        public static void SumOrTripleOfSum()
        {
            Console.Write("Input first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = (num1 == num2) ? (3 * (num1 + num2)) : (num1 + num2) ;
            Console.WriteLine($"Result is {sum}");
        }

    }
}
