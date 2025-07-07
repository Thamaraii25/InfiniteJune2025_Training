using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class CountLinesInFile
    {
        public static void Main()
        {
            string fileName = "FileCountExample.txt";

            int ch;
            do {
                Console.WriteLine("\nSelect the Choice From Below..");
                Console.WriteLine("1. Add Data To File");
                Console.WriteLine("2. Count No. Of Lines in the File");
                ch = Convert.ToInt32(Console.ReadLine());
                int TotalLines;
                switch (ch)
                {
                    case 1:
                        {
                            Console.Write("Input No. of Lines you want to write in the file: ");

                            TotalLines = Convert.ToInt32(Console.ReadLine());

                            List<String> strList = new List<string>();

                            for (int i = 0; i < TotalLines; i++)
                            {
                                Console.WriteLine("Input Line {0}", i + 1);
                                string temp = Console.ReadLine();
                                strList.Add(temp);
                            }

                            try
                            {
                                File.WriteAllLines(fileName, strList);
                                Console.WriteLine($"\nSuccessfully Written in {fileName} File");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 2:
                        try
                        {
                            if (File.Exists(fileName))
                            {
                                int CountLines = File.ReadAllLines(fileName).Length;
                                Console.WriteLine($"\nTotal Number of Lines in {fileName}: {CountLines}");
                            }
                            else
                            {
                                Console.WriteLine($"\nFile {fileName} does not exist.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            } while (ch < 2);
            Console.Read();
        }
    }
}
