using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class ArraysAssignment
    {
        public static void Main(String[] args)
        {
            Question1();
            Console.WriteLine();

            Question2();
            Console.WriteLine();

            Question3();
            Console.WriteLine();
                
                
            Console.Read();
        }

        /*
            1. Write a  Program to assign integer values to an array  and then print the following
	                a.	Average value of Array elements
	                b.	Minimum and Maximum value in an array 
         */

        public static void Question1()
        {
            Console.WriteLine("***** Question 1 : Avg , Min, Max of Array *****");
            int[] arr;
            Console.Write("Input Size of Array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            arr = new int[size];
            Console.WriteLine("Enter the Elements of Array One by One");
            for(int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            //a. Average
            Console.WriteLine($"Average Of Array: {AvgOfArray(arr)}");
            //b. Min of Array
            Console.WriteLine($"Minimum Of Array: {MinOfArray(arr)}");
            //b. Max of Array
            Console.WriteLine($"Maximum Of Array: {MaxOfArray(arr)}");

            
        }

        /*     
            2.	Write a program in C# to accept ten marks and display the following
	            a.	Total
	            b.	Average
	            c.	Minimum marks
	            d.	Maximum marks
	            e.	Display marks in ascending order
	            f.	Display marks in descending order
         */


        public static void Question2()
        {
            Console.WriteLine("***** Question 2 : Total, Avg , Min, Max , asc, des of Array *****");
            int[] arr = new int[10];
            Console.WriteLine("Enter the Elements of Array one by one : Size : 10 ");
            for (int i = 0; i < 10; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Sum
            Console.WriteLine($"Sum Of Array: {SumOfArray(arr)}");
            //Average
            Console.WriteLine($"Average Of Array: {AvgOfArray(arr)}");
            //Min of Array
            Console.WriteLine($"Minimum Of Array: {MinOfArray(arr)}");
            //Max of Array
            Console.WriteLine($"Maximum Of Array: {MaxOfArray(arr)}");
            //Ascending Order
            Console.WriteLine($"Ascending Of Array:");
            AscOfArray(arr);
            Console.WriteLine();
            //Desending Order
            Console.WriteLine($"Desending Of Array:");
            DesOfArray(arr);
            Console.WriteLine();
        }

        /*
        3.  Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)
        */

        public static void Question3()
        {
            Console.WriteLine("***** Question 3: Copy Elements in One Arr to Another*****");
            int[] arr;
            Console.Write("Input Size of Array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            arr = new int[size];
            Console.WriteLine("Enter the Elements of Array One by One");
            for (int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] newArray = new int[size];

            //newArray = arr;

            for(int i = 0; i < size; i++)
            {
                newArray[i] = arr[i];
            }

            foreach(int i in newArray)
            {
                Console.Write(i + " ");
            }
        }


        public static int SumOfArray(int[] arr)
        {
            int sum = 0;
            foreach(int i in arr)
            {
                sum += i;
            }
            return sum;
        }

        public static float AvgOfArray(int[] arr)
        {
            float avg;
            avg = (SumOfArray(arr) / arr.Length );
            return avg;
        }

        public static int MinOfArray(int[] arr)
        {
            int MinValue = int.MaxValue;
            foreach(int i in arr)
            {
                if(i < MinValue)
                {
                    MinValue = i;
                }
            }
            return MinValue;
        }


        public static int MaxOfArray(int[] arr)
        {
            int MaxValue = int.MinValue;
            foreach (int i in arr)
            {
                if (i > MaxValue)
                {
                    MaxValue = i;
                }
            }
            return MaxValue;
        }

        public static void AscOfArray(int[] arr)
        {            
            Array.Sort(arr);
            foreach(int i in arr)
            {
                Console.Write(i + " ");
            }

        }

        public static void DesOfArray(int[] arr)
        {
            Array.Reverse(arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
  
        }


    }


}
