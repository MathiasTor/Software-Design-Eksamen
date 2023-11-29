using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;
using System.Collections;

namespace PG3302_Eksamen.Logic
{
    public class DbLogicBook
    {

        //Methods
        //Add book to db
        public void AddBookToDb(Book book)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(book);
                db.SaveChanges();
            }

        }

        //Delete book from db
        public static Book? DeleteBookFromDb(Book book)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (book != null) { 
                db.Remove(book);
                db.SaveChanges();
            }
                return book;
            }

        }
        
        //Edit book title in db
        public static Book? EditBookTitle(Book book, string newTitle)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if(book != null)
                {
                    book.Title = newTitle;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;

            }
        }

        //Edit book author in db
        public static Book? EditBookAuthor(Book book, string newAuthor)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (book != null)
                {
                    book.Creator = newAuthor;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;

            }
        }

        //Edit book release year in db
        public static Book? EditBookReleaseYear(Book book, int newReleaseYear)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (book != null)
                {
                    book.ReleaseYear = newReleaseYear;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;
            }
        }

        //Edit book genre in db
        public static Book? EditBookGenre(Book book, string newGenre)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (book != null)
                {
                    book.Genre = newGenre;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;
            }
        }

        //Edit book pages in db
        public static Book? EditBookPages(Book book, int newPages)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (book != null)
                {
                    book.Pages = newPages;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;
            }
        }

        //Get all books with same name from db
        public ArrayList getAllBooksWithSameName(String name)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                ArrayList books = new ArrayList();
                foreach (Book book in db.Books)
                {
                    if (book.Title == name)
                    {
                        books.Add(book);
                    }
                }
                return books;
            }
        }
        

        //Print all books
        public void PrintAllBooksFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (db.Books != null)
                {
                    foreach (Book book in db.Books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }

        //Return all books
        public List<Book> GetAllBooks()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<Book> books = db.Books.ToList();
                return books;
            }
        }
        
    }
}
