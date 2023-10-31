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
        }

        public void AddBook(string title, string creator, int releaseYear, string genre, int pages)
        {
            //Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Books.Add(new Book(title, creator, releaseYear, genre, pages));
            Console.WriteLine($"Book {title} has been added!");

        }

        public void RemoveBook(String title)
        {
            Books.RemoveAll(book => book.Title == title);
        }

        public void DisplayBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }
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
