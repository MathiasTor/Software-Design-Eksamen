using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        public List<Book> Books { get; set; }
        public void AddBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException("Book is null");
            }

            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException("Book is null");
            }

            Books.Remove(book);
        }

        public void DisplayBooks()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
