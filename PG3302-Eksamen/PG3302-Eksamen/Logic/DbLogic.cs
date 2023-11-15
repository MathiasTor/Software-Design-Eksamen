using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;
using System.Collections;

namespace PG3302_Eksamen.Logic
{
    public class DbLogic
    {
        //Books
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
        
        public static Book? EditBookTitle(Book book, string oldTitle, string newTitle)
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

        public static Book? EditBookAuthor(Book book, string author, string newAuthor)
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

        public static Book? EditBookReleaseYear(Book book, int releaseYear, int newReleaseYear)
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

        public static Book? EditBookGenre(Book book, string genre, string newGenre)
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

        public static Book? EditBookPages(Book book, int pages, int newPages)
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

        //Music
        //Add Song to db
        public void AddMusicToDb(Music music)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(music);
                db.SaveChanges();
            }

        }
        
        //Games
        //Add Game to db
        public void AddGameToDb(Game game)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(game);
                db.SaveChanges();
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

        //Return all books as arraylist
        public ArrayList GetAllBooks()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                ArrayList books = new ArrayList();
                foreach (Book book in db.Books)
                {
                    books.Add(book);
                }
                return books;
            }
        }

        
        //Print all Songs
        public void PrintAllMusicFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (db.Music != null)
                {
                    foreach (Music music in db.Music)
                    {
                        Console.WriteLine(music);
                    }
                }
            }
        }
        
        //Print all games
        public void PrintAllGamesFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (db.Games != null)
                {
                    foreach (Game game in db.Games)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
        }
    }
}
