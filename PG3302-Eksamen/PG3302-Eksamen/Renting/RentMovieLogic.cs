using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMovieLogic
    {
        //Fields
        private SystemUser _user;
        private RentMovieDbLogic _rentMovieDbLogic = new();

        //Constructor
        public RentMovieLogic(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        //Get all movies that are not rented
        public List<Movie> GetRentableMovies()
        {
            return _rentMovieDbLogic.GetRentableMovies();
        }

        //Rent movie
        public void RentMovie(Movie movie)
        {
            _rentMovieDbLogic.RentMovie(_user, movie);
        }
    }
}
