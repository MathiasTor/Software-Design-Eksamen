using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        public List<Book> Books { get; set; }
        public BookLogic()
        {
            Books = new List<Book>();

            //Sample-data - for testing purposes
            AddBook("Harry Potter", "J.K. Rowling", 1997, "Fantasy", 300);
            AddBook("The Lord of the Rings", "J.R.R. Tolkien", 1954, "Fantasy", 500);
            AddBook("The Hobbit", "J.R.R. Tolkien", 1937, "Fantasy", 300);
        }

        //Add a book
        public void AddBook(string title, string creator, int releaseYear, string genre, int pages)
        {
            //Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Books.Add(new Book(title, creator, releaseYear, genre, pages));
            Console.WriteLine($"Book {title} has been added!");

        }

        //Remove a book
        public void RemoveBook(String title)
        {
            Books.RemoveAll(book => book.Title == title);
        }

        //Print all books
        public void DisplayBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }

        //Check if book exists - returns true/false
        public bool CheckIfBookExists(string title)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    return true;
                }
            }
            return false;
        }

        //Edit book title - takes in old title and new title
        public void EditBookTitle(String title, String newTitle)
        {
           for(int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Title == title)
                {
                    Books[i].Title = newTitle;
                }
            }
        }
    }
}
