using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    3. Write a program in C# Sharp to append some text to an existing file. 
    If file is not available, then create one in the same workspace.
    Hint: (Use the appropriate mode of operation. Use stream writer class)
 */

namespace CodeChallenge_3
{
    class FileWriting
    {
        public static void Main(String[] args)
        {
            Console.Write("Input File Name To Create: ");
            string fileName = Console.ReadLine();

            //Console.Write("Input No. Of Files u want to write in File: ");
            //int TotalLines = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input Text to Append: ");
            string text = Console.ReadLine();

            //List<string> listContent = new List<string>();

            //for(int i = 0; i< TotalLines; i++)
            //{
            //    Console.WriteLine("Input Line 1: {0}",i+1);
            //    string temp = Console.ReadLine();
            //    listContent.Add(temp);
            //}
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
            }
            Console.WriteLine("\nSuccessFully Written in the File");
            Console.Read();
        }
    }
}
