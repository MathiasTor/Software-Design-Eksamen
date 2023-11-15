using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        public List<Book> Books { get; set; }
        readonly DbLogic DbLogic = new();

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
            DbLogic.DeleteBookFromDb(book);

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


        //Edit book title - takes in old title and new title
        public void EditBookTitle(Book book, String title, String newTitle)
        {
           book.Title = newTitle;
            DbLogic.EditBookTitle(book, title, newTitle);
        }

        //Edit book author - takes in old author and new author
        public void EditBookAuthor(Book book, String author, String newAuthor)
        {
            book.Creator = newAuthor;
            DbLogic.EditBookAuthor(book, author, newAuthor);
        }

        //Edit book release year - takes in old release year and new release year
        public void EditBookReleaseYear(Book book, int releaseYear, int newReleaseYear)
        {
            book.ReleaseYear = newReleaseYear;
            DbLogic.EditBookReleaseYear(book, releaseYear, newReleaseYear);
        }

        //Edit book genre - takes in old genre and new genre
        public void EditBookGenre(Book book, String genre, String newGenre)
        {
            book.Genre = newGenre;
            DbLogic.EditBookGenre(book, genre, newGenre);
        }

        //Edit book number of pages - takes in old number of pages and new number of pages
        public void EditBookPages(Book book, int pages, int newPages)
        {
            book.Pages = newPages;
            DbLogic.EditBookPages(book, pages, newPages);
        }
    }
}
