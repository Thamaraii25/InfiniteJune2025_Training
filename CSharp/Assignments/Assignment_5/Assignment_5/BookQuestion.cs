using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
        class BookQuestion
        {
            static void Main(string[] args)
            {
                BookShelf shelf = new BookShelf(5);

                shelf.GetData();

                Console.WriteLine("\nBooks in the shelf:\n");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Book {i + 1}:");
                    shelf[i].Display();
                    Console.WriteLine();
                }

                Console.Read();
            }
        }

        class Books
        {
            public string BookName { get; set; }
            public string AuthorName { get; set; }

            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }

            public void Display()
            {
                Console.WriteLine("Book Name: " + BookName);
                Console.WriteLine("Author Name: " + AuthorName);
            }
        }

        class BookShelf
        {
            private Books[] books;

            public BookShelf(int size)
            {
                books = new Books[size];
            }


            public void GetData()
            {
                for (int i = 0; i < books.Length; i++)
                {
                    Console.WriteLine($"\nEnter details for Book {i + 1}:");
                    Console.Write("Book Name: ");
                    string bookName = Console.ReadLine();

                    Console.Write("Author Name: ");
                    string authorName = Console.ReadLine();

                    this[i] = new Books(bookName, authorName);
                }
            }

            public Books this[int index]
            {
                get
                {
                    if (index >= 0 && index < books.Length)
                        return books[index];
                    else
                        throw new IndexOutOfRangeException("Invalid book index.");
                }
                set
                {
                    if (index >= 0 && index < books.Length)
                        books[index] = value;
                    else
                        throw new IndexOutOfRangeException("Invalid book index.");
                }
            }    
        }

}
