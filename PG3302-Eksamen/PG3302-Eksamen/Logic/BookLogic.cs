using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        public List<Book> Books { get; set; }
        readonly DbLogicBook DbLogic = new();

        public BookLogic()
        {
            Books = new List<Book>();
        }

        //Add a book
        public void AddBook(string title, string creator, int releaseYear, string genre, int pages)
        {
            Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Books.Add(bookToAdd);
            Console.WriteLine($"Book {title} has been added!");
            
            DbLogic.AddBookToDb(bookToAdd);
        }

        //Remove a book
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            DbLogicBook.DeleteBookFromDb(book);

        }


        //Print all books
        public void DisplayBooks()
        {
            DbLogic.PrintAllBooksFromDb();
            
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


        //Edit book title
        public void EditBookTitle(Book book, String newTitle)
        {
           book.Title = newTitle;
            DbLogicBook.EditBookTitle(book, newTitle);
        }

        //Edit book author
        public void EditBookAuthor(Book book, String newAuthor)
        {
            book.Creator = newAuthor;
            DbLogicBook.EditBookAuthor(book, newAuthor);
        }

        //Edit book release year
        public void EditBookReleaseYear(Book book, int newReleaseYear)
        {
            book.ReleaseYear = newReleaseYear;
            DbLogicBook.EditBookReleaseYear(book, newReleaseYear);
        }

        //Edit book genre - takes in old genre and new genre
        public void EditBookGenre(Book book, String newGenre)
        {
            book.Genre = newGenre;
            DbLogicBook.EditBookGenre(book, newGenre);
        }

        //Edit book number of pages
        public void EditBookPages(Book book, int newPages)
        {
            book.Pages = newPages;
            DbLogicBook.EditBookPages(book, newPages);
        }
    }
}
