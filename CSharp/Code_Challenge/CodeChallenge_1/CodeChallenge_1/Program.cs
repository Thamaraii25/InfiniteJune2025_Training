using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------Question 1 ----------");
            CharRemovalInString strQn = new CharRemovalInString();
            Console.WriteLine("Enter the Number of Testcases: ");
            int t1 = Convert.ToInt32(Console.ReadLine());
            while (t1 > 0)
            {
                strQn.RemoveCharInString();
                t1--;
            }


            Console.WriteLine("---------Question 2 ----------");
            ReplaceFirstAndLast re = new ReplaceFirstAndLast();
            Console.WriteLine("Enter the Number of Testcases: ");
            int t2 = Convert.ToInt32(Console.ReadLine());
            while (t2 > 0)
            {
                re.ReplaceFunc();
                t2--;
            }

            Console.WriteLine("---------Question 3 ----------");
            CheckLargest cl = new CheckLargest();
            Console.WriteLine("Enter the Number of Testcases: ");
            int t3 = Convert.ToInt32(Console.ReadLine());
            while (t3 > 0)
            {
                cl.GetData();
                cl.GetLargest();
                t3--;
            }


            Console.Read();
        }
    }

    /*
     * 1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
        Sample Input:
        "Python", 1
        "Python", 0
        "Python", 4
        Expected Output:
        Pthon
        ython
        Pythn
     */

    class CharRemovalInString
    {
        String str;
        int pos;
        public void RemoveCharInString()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Input String Alone: ");
            str = Console.ReadLine();
            sb.Append(str);
            Console.WriteLine("Input Position of the Char to be Removed in String: ");
            pos = Convert.ToInt32(Console.ReadLine());

            sb.Remove(pos, 1);
            Console.WriteLine(sb);
        }
    }

    /*
     2. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
        Sample Input:
        "abcd"
        "a"
        "xy"
        Expected Output:
 
        dbca
        a
        yx

     */

    class ReplaceFirstAndLast
    {
        public void ReplaceFunc() {
            char[] c;
            string str;
            Console.WriteLine("Input String: ");
            str = Console.ReadLine();
            c = str.ToCharArray();
            char temp = c[0];
            c[0] = c[c.Length - 1];
            c[c.Length - 1] = temp;
            String Result = new string(c);
            Console.WriteLine("Result: {0}",Result);
         }

    }

    /*
         Write a C# Sharp program to check the largest number among three given integers.
 
        Sample Input:
        1,2,3
        1,3,2
        1,1,1
        1,2,2
        Expected Output:
        3
        3
        1
        2
     */

    class CheckLargest
    {
        int[] arr = new int[3];
        public void GetData()
        {           
            for(int i = 0; i<3; i++)
            {
                Console.WriteLine("Enter Element {0}",i+1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void GetLargest()
        {
            if(arr[0] > arr[1] && arr[0] > arr[2])
            {
                Console.WriteLine("Largest: {0}",arr[0]);
            }
            else if (arr[1] > arr[0] && arr[1] > arr[2])
            {
                Console.WriteLine("Largest: {0}", arr[1]);
            }
            else
            {
                Console.WriteLine("Largest: {0}",arr[2]);
            }

        }
    }
}
