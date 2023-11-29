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
        private SystemUser _user;

        private RentMovieDbLogic _rentMovieDbLogic = new();

        public RentMovieLogic(SystemUser user)
        {
            this._user = user;
        }

        public List<Movie> GetRentableMovies()
        {
            return _rentMovieDbLogic.GetRentableMovies();
        }

        public void RentMovie(Movie movie)
        {
            _rentMovieDbLogic.RentMovie(_user, movie);
        }
    }
}
