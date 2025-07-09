using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 2. Write a class Box that has Length and breadth as its members. 
   Write a function that adds 2 box objects and stores in the 3rd. 
   Display the 3rd object details. Create a Test class to execute the above.
 */
namespace CodeChallenge_3
{
    class AddOperatorOverloading
    {
        public static void Main()
        {
            Box box1 = new Box();
            Console.Write("Input 'Box 1' Length: ");
            box1.Length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 'Box 1' Breadth: ");
            box1.Breadth = Convert.ToInt32(Console.ReadLine());
            Box box2 = new Box();
            Console.Write("\nInput 'Box 2' Length: ");
            box2.Length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 'Box 2' Breadth: ");
            box2.Breadth = Convert.ToInt32(Console.ReadLine());

            Box box3 = box1 + box2;

            Console.WriteLine("\nLength of Box 3 (Sum of Length of Box 1 and Box 2): {0}",box3.Length);
            Console.WriteLine("Breadth of Box 3 (Sum of Breadth of Box 1 and Box 2): {0}",box3.Breadth);

            Console.Read();
        }
    }
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public static Box operator +(Box box1,Box box2)
        {
            Box box3 = new Box();
            box3.Length = box1.Length + box2.Length;
            box3.Breadth = box1.Breadth + box2.Breadth;
            return box3;

        }
    }

}
