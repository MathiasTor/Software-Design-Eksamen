using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class DbLogicMovie
    {
        //Methods
        //Add movie to db
        public void AddMovieToDb(Movie movie)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(movie);
                db.SaveChanges();
            }
        }

        //Delete movie from db
        public static Movie? DeleteMovieFromDb(Movie movie)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (movie != null)
                {
                    db.Remove(movie);
                    db.SaveChanges();
                }
                return movie;
            }

        }

        //Edit movie title
        public static Movie? EditMovieTitle(Movie movie, string newTitle)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (movie != null)
                {
                    movie.Title = newTitle;
                    db.Update(movie);
                    db.SaveChanges();
                }
                return movie;

            }
        }

        //Edit movie creator
        public static Movie? EditMovieCreator(Movie movie, string newCreator)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (movie != null)
                {
                    movie.Creator = newCreator;
                    db.Update(movie);
                    db.SaveChanges();
                }
                return movie;

            }
        }

        //Edit movie release year
        public static Movie? EditMovieReleaseYear(Movie movie, int newReleaseYear)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (movie != null)
                {
                    movie.ReleaseYear = newReleaseYear;
                    db.Update(movie);
                    db.SaveChanges();
                }
                return movie;

            }
        }

        //Edit movie genre
        public static Movie? EditMovieGenre(Movie movie, string newGenre)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (movie != null)
                {
                    movie.Genre = newGenre;
                    db.Update(movie);
                    db.SaveChanges();
                }
                return movie;

            }
        }

        //Edit movie length
        public static Movie? EditMovieLength(Movie movie, int newLength)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (movie != null)
                {
                    movie.LengthInMinutes = newLength;
                    db.Update(movie);
                    db.SaveChanges();
                }
                return movie;

            }
        }

        //Get all movies with same title
        public List<Movie> GetAllMoviesWithSameTitle(string title)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                var movies = db.Movies.Where(m => m.Title == title).ToList();
                return movies;
            }
        }

        //Print all movies
        public void PrintAllMoviesFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                var movies = db.Movies.ToList();

                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }
        }

        internal List<Movie> GetAllMovies()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<Movie> movies = db.Movies.ToList();
                return movies;
            }
        }
    }
}
