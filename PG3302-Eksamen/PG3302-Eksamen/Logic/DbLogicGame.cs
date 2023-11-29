using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public class DbLogicGame
    {
        //Add game to db
        public void AddGameToDb(Game game)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(game);
                db.SaveChanges();
            }

        }

        //Delete game from db
        public static Game? DeleteGameFromDb(Game game)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (game != null)
                {
                    db.Remove(game);
                    db.SaveChanges();
                }
                return game;
            }

        }

        //Edit game title
        public static Game? EditGameTitle(Game game, string newTitle)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (game != null)
                {
                    game.Title = newTitle;
                    db.Update(game);
                    db.SaveChanges();
                }
                return game;

            }
        }

        //Edit game creator
        public static Game? EditGameCreator(Game game, string newCreator)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (game != null)
                {
                    game.Creator = newCreator;
                    db.Update(game);
                    db.SaveChanges();
                }
                return game;

            }
        }

        //Edit game release year
        public static Game? EditGameReleaseYear(Game game, int newReleaseYear)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (game != null)
                {
                    game.ReleaseYear = newReleaseYear;
                    db.Update(game);
                    db.SaveChanges();
                }
                return game;

            }
        }

        //Edit game genre
        public static Game? EditGameGenre(Game game, string newGenre)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (game != null)
                {
                    game.Genre = newGenre;
                    db.Update(game);
                    db.SaveChanges();
                }
                return game;

            }
        }

        //Edit game platform
        public static Game? EditGamePlatform(Game game, string newPlatform)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (game != null)
                {
                    game.Platform = newPlatform;
                    db.Update(game);
                    db.SaveChanges();
                }
                return game;

            }
        }

        //Print all games from db
        public void PrintAllGamesFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                var games = db.Games.ToList();

                foreach (var game in games)
                {
                    Console.WriteLine(game);
                }
            }
        }

        //Get all games with same title
        public List<Game> GetAllGamesWithSameTitle(string title)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<Game> games = new List<Game>();
                foreach (Game game in db.Games)
                {
                    if (game.Title == title)
                    {
                        games.Add(game);
                    }
                }
                return games;
            }
        }

        //Get all games
        public List<Game> GetAllGames()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<Game> games = new List<Game>();
                foreach (Game game in db.Games)
                {
                    games.Add(game);
                }
                return games;
            }
        }
    }
}
