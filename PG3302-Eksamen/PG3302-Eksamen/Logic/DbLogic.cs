using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

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

        public void DeleteBookFromDb(Book book)
        {

        }
        
        public static Book? UpdateBook(string oldTitle, string newTitle)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                Book? book = db.Books.SingleOrDefault(x => x.Title == oldTitle);
                if(book != null)
                {
                    book.Title = newTitle;
                    db.Update(book);
                    db.SaveChanges();
                }
                return book;

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
