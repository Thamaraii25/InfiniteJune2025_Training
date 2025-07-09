using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 4. Write a console program that uses delegate object as an argument to call Calculator Functionalities like 
    1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. 
    You should display all the return values accordingly.
 */
namespace CodeChallenge_3
{
    public delegate int CalcDelegates(int n1, int n2);
    class Calculator
    {
        public int AddNumbers(int n1, int n2)
        {
            return n1 + n2;
        }  
        
        public int SubtractNumbers(int n1, int n2)
        {
            return Math.Abs(n1 - n2);
        }

        public int MultiplyNumbers(int n1, int n2)
        {
            return n1 * n2;
        }
    }

    class CalculatorMainFunc
    {
        public static void Main(String[] args)
        {
            Console.Write("Input Number 1: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Number 2: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            Calculator calculator = new Calculator();

            CalcDelegates calcDelegates = new CalcDelegates(calculator.AddNumbers);
            int SumOfNumbers = calcDelegates(number1, number2);

            calcDelegates += calculator.SubtractNumbers;
            int SubOfNumbers = calcDelegates(number1, number2);

            calcDelegates += calculator.MultiplyNumbers;
            int MulOfNumbers = calcDelegates(number1, number2);

            Console.WriteLine("\nSum of Numbers: {0}, Subtraction of Numbers: {1}, Multiplication of Numbers: {2}",SumOfNumbers,SubOfNumbers,MulOfNumbers);

            Console.Read();

        }
    }
}
