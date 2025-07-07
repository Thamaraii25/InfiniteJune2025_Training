using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 First Question Already Done in Assignment 5 (BookShelf)
 2. Write a program in C# Sharp to create a file and write an array of strings to the file.
 */
namespace Assignment_6
{
    class WriteDataToFile
    {
        static void Main(string[] args)
        {
            string fileName = "Output.txt";

            Console.Write("Input No. of Lines you want to write in the file: ");

            int TotalLines = Convert.ToInt32(Console.ReadLine());

            List<String> strList = new List<string>();

            for(int i = 0; i < TotalLines; i++)
            {
                Console.WriteLine("Input Line {0}",i+1);
                string temp = Console.ReadLine();
                strList.Add(temp);
            }

            try
            {
                File.WriteAllLines(fileName, strList);
                Console.WriteLine($"\nSuccessfully Written in {fileName} File");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
