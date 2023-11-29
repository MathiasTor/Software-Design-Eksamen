using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentMovieDbLogic
    {
        //Fields
        private DbLogicMovie _dbLogicMovie = new();

        //Constructor
        public RentMovieDbLogic()
        {
        }

        //Methods
        //Get all movies that are not rented
        public List<Movie> GetRentableMovies()
        {
            List<Movie> movies = _dbLogicMovie.GetAllMovies();
            List<Movie> rentedMovies = new();

            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (RentedMedia rm in db.RentedMedia)
                {
                    foreach (Movie m in movies)
                    {
                        if (!rm.IsReturned && rm.MediaId == m.Id && rm.Media == "Movie")
                        {
                            rentedMovies.Add(m);
                        }
                    }
                }

                foreach (Movie m in rentedMovies)
                {
                    movies.Remove(m);
                }

                return movies;
            }
        }

        //Rent movie
        public void RentMovie(SystemUser user, Movie movie)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                DateTime currentTime = DateTime.Now;
                RentedMedia rentedMedia = new("Movie", movie.Id, user.Name, currentTime, false);

                db.RentedMedia.Add(rentedMedia);
                db.SaveChanges();
            }

        }
    }
}
