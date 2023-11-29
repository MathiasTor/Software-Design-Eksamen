using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMovieUI
    {
        //Field
        private SystemUser _user;

        //Constructor
        public RentMovieUI(SystemUser user)
        {
            this._user = user;
        }
        //Methods
        internal void RentMovieMenu(SystemUser user)
        {
            RentMovieLogic rentMovieLogic = new(user);

            List<Movie> rentableMovies = rentMovieLogic.GetRentableMovies();

            Console.Clear();

            Console.WriteLine("Rentable movies:");
            foreach (Movie m in rentableMovies)
            {
                Console.WriteLine(rentableMovies.IndexOf(m) + 1 + " - " + m);
            }

            Console.Write("Enter ID of movie to rent (Back: 0): ");

            try
            {
                int movieId = Convert.ToInt32(Console.ReadLine());

                if(movieId == 0)
                {
                    Console.Clear();
                    RentMediaUI rentMediaUI1 = new();
                    rentMediaUI1.RentMediaMenu(user);
                    return;
                }

                if (movieId > rentableMovies.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid ID!");
                    RentMovieMenu(user);
                    return;
                }

                Movie movieToRent = rentableMovies[movieId - 1];

                Console.Clear();

                Console.WriteLine("You have rented: " + movieToRent.Title);

                rentMovieLogic.RentMovie(movieToRent);

                RentMediaUI rentMediaUI = new();
                rentMediaUI.RentMediaMenu(user);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
                RentMovieMenu(user);
                return;
            }
        }
    }
}
