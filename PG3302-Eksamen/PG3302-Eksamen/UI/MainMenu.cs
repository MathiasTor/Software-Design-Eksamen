using PG3302_Eksamen.Renting;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.UI
{
    public class MainMenu
    {

        //Fields
        private UserLogic _userLogic = new();

        //Methods
        public void RunProgram()
        {
            Console.WriteLine("Welcome the the Library of Media!");
            Console.WriteLine("Please choose what you would like to do.\n" +
                               "1. Login\n" +
                               "2. Register\n" +
                               "\nIf you would like to exit the program, please type 0.\n\n");
            Console.Write("Write your choice here: ");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    RegisterUser();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid input! (1,2,0)");
                    RunProgram();
                    break;
            }

        }

        private void RegisterUser()
        {
            Console.WriteLine("Please enter username (Back: 0): ");
            string? username = Console.ReadLine();

            if (username == "0")
            {
                Console.Clear();
                RunProgram();
                return;
            }

            Console.WriteLine("Please enter email: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            string? password = Console.ReadLine();

            if(username == "" || email == "" || password == "")
            {
                Console.Clear();
                Console.WriteLine("One or more invalid inputs, please try again");
                RegisterUser();
                return;
            }

            SystemUser user = new(username, email, password, false);

            if (_userLogic.IsUsernameTaken(user))
            {
                Console.Clear();
                Console.WriteLine("Username is already taken, please try again");
                RegisterUser();
                return;
            }
            _userLogic.AddUser(user);

            Console.Clear();
            Console.WriteLine("User successfully registered!");
            LoginMenu();
        }

        private void LoginMenu()
        {
            Console.WriteLine("Please enter username (Back: 0): ");
            string? username = Console.ReadLine();

            if (username == "0")
            {
                Console.Clear();
                RunProgram();
                return;
            }

            Console.WriteLine("Please enter password: ");
            string? password = Console.ReadLine();

            if (username == null || password == null)
            {
                Console.Clear();
                Console.WriteLine("One or more invalid inputs, please try again");
                LoginMenu();
                return;
            }

            if(_userLogic.ValidateUser(new SystemUser(username, "", password, false)))
            {
                Console.Clear();
                Console.WriteLine("Login successful!");

                SystemUser user = new(username, "", password, false);

                DisplayMainMenu(user);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Login failed, please try again");
                LoginMenu();
            }
        }
        public void DisplayMainMenu(SystemUser user)
        {
            
            Console.WriteLine("Welcome the the Library of Media!\n" +
                "Please choose what type of media you would like to access:\n\n" +
                "1. Books\n" +
                "2. Movies\n" +
                "3. Music\n" +
                "4. Games\n\n" +
                "5. Renting\n\n" +
                "9. Logout\n" +
                "\nIf you would like to exit the program, please type 0.\n\n");
            Console.Write("Write your choice here: ");

            string ? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);
            Console.Clear();

            switch (userInputResult)
            {

                case 0:
                    break;

                case 1:
                    BookUI bookUI = new(user);
                    bookUI.BookMenu();
                    break;

                case 2:
                    MovieUI movieUI = new(user);
                    movieUI.MovieMenu();
                    break;

                case 3:
                    MusicUI musicUI = new(user);
                    musicUI.MusicMenu();
                    break;

                case 4:
                    GameUI gameUI = new(user);
                    gameUI.GameMenu();
                    break;
                case 5:
                    RentMediaUI rentMediaUI = new();
                    rentMediaUI.RentMediaMenu(user);
                    break;
                case 9:
                    RunProgram();
                    break;
                default:
                    Console.WriteLine("Invalid input! (1,2,3,4,5,0,9)");
                    DisplayMainMenu(user);
                    break;

            }

        }

    }
}
