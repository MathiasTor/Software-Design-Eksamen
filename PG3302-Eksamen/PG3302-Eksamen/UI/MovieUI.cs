using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.UI
{
    public class MovieUI
    {
        //Fields
        private DbLogicMovie _dbLogicMovie = new();
        private MovieLogic _movieLogic = new(new DbLogicMovie());
        private SystemUser _user;

        //Constructor
        public MovieUI(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        public void MovieMenu()
        {

            Console.WriteLine("\n\nWelcome to the movie registry\n" +
                    "Please Choose what you would like to do.\n" +
                    "1. Display movies.\n" +
                    "2. Add a new movie.\n" +
                    "3. Edit existing movie.\n" +
                    "4. Delete a movie.\n\n" +
                    "--------------------------\n\n" +
                    "9. Back to Main Menu\n" +
                    "0. To exit");

            Console.Write("\nPlease enter your input here: ");

            String? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);

            switch (userInputResult)
            {
                case 1:
                    DisplayMovies();
                    break;
                case 2:
                    AddMovie();
                    break;
                case 3:
                    EditMovie();
                    break;
                case 4:
                    DeleteMovie();
                    break;
                case 9:
                    BackToMainMenu();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid input! (1,2,3,4,0,9)");
                    MovieMenu();
                    break;

            }

        }

        private void AddMovie()
        {
            Console.Write("Movie title: ");
            string title = Console.ReadLine();

            Console.Write("Movie Creator: ");
            string creator = Console.ReadLine();

            Console.Write("Release Year: ");
            int releaseYear = Int32.Parse(Console.ReadLine());

            Console.Write("Movie Genre: ");
            string genre = Console.ReadLine();

            Console.WriteLine("Movie length in minutes: ");
            int lengthInMinutes = Int32.Parse(Console.ReadLine());

            Console.Clear();

            _movieLogic.AddMovie(title, creator, releaseYear, genre, lengthInMinutes);

            MovieMenu();
        }

        private void BackToMainMenu()
        {
            Console.Clear();
            ConsoleApp mainMenu = new();
            mainMenu.MainMenu(_user);
        }

        private void DeleteMovie()
        {
            Console.Write("Enter the Title of the Movie you wish to delete: ");
            string titleToDelete = Console.ReadLine();
            List<Movie> moviesWithSameTitle = _dbLogicMovie.GetAllMoviesWithSameTitle(titleToDelete);

            Movie movieToDelete = new();

            if (moviesWithSameTitle.Count > 1)
            {
                printMoviesWithSameTitle(moviesWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple movies with the same title!");
                Console.WriteLine("Enter ID of movie to delete: ");

                try
                {
                    int movieIdToDelete = Int32.Parse(Console.ReadLine());
                    movieToDelete = (Movie)moviesWithSameTitle[movieIdToDelete - 1];
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    DeleteMovie();
                }


            }
            else if (moviesWithSameTitle.Count == 1)
            {
                movieToDelete = (Movie)moviesWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No movies with that title found!");
                MovieMenu();
                return;
            }
            DeleteMovie(movieToDelete);
        }

        private void DeleteMovie(Movie movieToDelete)
        {
            _movieLogic.RemoveMovie(movieToDelete);
            Console.WriteLine("Movie deleted!");
            Console.WriteLine("Delete more? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                DeleteMovie();
            }
            else
            {
                Console.Clear();
                MovieMenu();
            }
        }

        private void printMoviesWithSameTitle(List<Movie> moviessWithSameTitle)
        {
            int counter = 0;
            foreach (Movie movie in moviessWithSameTitle)
            {
                counter++;
                Console.WriteLine($"{counter} - {movie}");
            }
        }

        private void EditMovie()
        {
            Console.WriteLine("Enter the Title of the Movie you wish to edit: ");
            string titleToEdit = Console.ReadLine();
            List<Movie> moviesWithSameTitle = _dbLogicMovie.GetAllMoviesWithSameTitle(titleToEdit);
            Movie movieToEdit = new();

            if (moviesWithSameTitle.Count > 1)
            {
                printMoviesWithSameTitle(moviesWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple movies with the same title!");
                Console.WriteLine("Enter ID of movie to edit: ");

                try
                {
                    int movieIdToEdit = Int32.Parse(Console.ReadLine());
                    movieToEdit = (Movie)moviesWithSameTitle[movieIdToEdit - 1];
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    EditMovie();
                }
            }
            else if (moviesWithSameTitle.Count == 1)
            {
                movieToEdit = moviesWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No movies with that title found!");
                MovieMenu();
                return;
            }

            EditMovie(movieToEdit);
        }

        private void EditMovie(Movie movieToEdit)
        {
            Console.Clear();
            Console.WriteLine("What would you like to edit?\n" +
                              "1. Title\n" +
                              "2. Creator\n" +
                              "3. Release Year\n" +
                              "4. Genre\n" +
                              "5. Length in minutes\n" +
                              "9. Back to Movie Menu\n" +
                              "0. Exit");

            Console.Write("Please enter your input here: ");
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Write("Enter new title: ");
                    string newTitle = Console.ReadLine();
                    _movieLogic.EditMovieTitle(movieToEdit, newTitle);
                    Console.WriteLine("Title changed!");
                    break;

                case "2":
                    Console.Write("Enter new creator: ");
                    string newCreator = Console.ReadLine();
                    _movieLogic.EditMovieCreator(movieToEdit, newCreator);
                    Console.WriteLine("Creator changed!");
                    break;

                case "3":
                    Console.Write("Enter new release year: ");
                    int newReleaseYear = Int32.Parse(Console.ReadLine());
                    _movieLogic.EditMovieReleaseYear(movieToEdit, newReleaseYear);
                    Console.WriteLine("Release year changed!");
                    break;

                case "4":
                    Console.Write("Enter new genre: ");
                    string newGenre = Console.ReadLine();
                    _movieLogic.EditMovieGenre(movieToEdit, newGenre);
                    Console.WriteLine("Genre changed!");
                    break;

                case "5":
                    Console.Write("Enter new length in minutes: ");
                    int newLength = Int32.Parse(Console.ReadLine());
                    _movieLogic.EditMovieLength(movieToEdit, newLength);
                    Console.WriteLine("Length changed!");
                    break;

                case "9":
                    Console.Clear();
                    MovieMenu();
                    break;

                case "0":
                    break;

                default:
                    Console.WriteLine("Invalid input! (1,2,3,4,5,0,9)");
                    EditMovie(movieToEdit);
                    break;
            }

            Console.WriteLine("Movie edited!");
            Console.WriteLine("Edit more? Y/N");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                EditMovie();
            }
            else
            {
                Console.Clear();
                MovieMenu();
            }
        }

        public void DisplayMovies() {
            Console.Clear();
            Console.WriteLine("\n" +
                "------------------" +
                "\n");
            _movieLogic.DisplayMovies();
            Console.WriteLine("\n" +
                "------------------" +
                "\n");

            MovieMenu();
        }

}
}
