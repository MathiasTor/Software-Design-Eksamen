using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentMovieLogic
    {
        SystemUser user;

        RentMovieDbLogic rentMovieDbLogic = new();

        public RentMovieLogic(SystemUser user)
        {
            this.user = user;
        }

        public List<Movie> GetRentableMovies()
        {
            return rentMovieDbLogic.GetRentableMovies();
        }

        public void RentMovie(Movie movie)
        {
            rentMovieDbLogic.RentMovie(user, movie);
        }
    }
}
