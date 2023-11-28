using PG3302_Eksamen.Media;
using PG3302_Eksamen.Renting;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.UI
{
    public class ConsoleApp
    {
       

        BookUI bookUI = new();
        GameUI gameUI = new();
        MusicUI musicUI = new();
        MovieUI movieUI = new();

        UserLogic userLogic = new();

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
            Console.WriteLine("Please enter username: ");
            string? username = Console.ReadLine();
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

            if (userLogic.IsUsernameTaken(user))
            {
                Console.Clear();
                Console.WriteLine("Username is already taken, please try again");
                RegisterUser();
                return;
            }
            userLogic.AddUser(user);

            Console.Clear();
            Console.WriteLine("User successfully registered!");
            LoginMenu();
        }

        private void LoginMenu()
        {
            Console.WriteLine("Please enter username: ");
            string? username = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            string? password = Console.ReadLine();

            if (username == null || password == null)
            {
                Console.Clear();
                Console.WriteLine("One or more invalid inputs, please try again");
                LoginMenu();
                return;
            }

            if(userLogic.ValidateUser(new SystemUser(username, "", password, false)))
            {
                Console.Clear();
                Console.WriteLine("Login successful!");

                SystemUser user = new(username, "", password, false);

                MainMenu(user);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Login failed, please try again");
                LoginMenu();
            }
        }
        public void MainMenu(SystemUser user)
        {
            
            Console.WriteLine("Welcome the the Library of Media - Admin menu!\n" +
                "Please choose what type of media you would like to access:\n\n" +
                "1. Books\n" +
                "2. Movies\n" +
                "3. Music\n" +
                "4. Games\n\n" +
                "5. Renting\n" +
                "\nIf you would like to exit the program, please type 0.\n\n");
            Console.Write("Write your choice here: ");

            string ? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);
            Console.Clear();

            switch (userInputResult)
            {

                case 0:
                    Console.WriteLine("program still running!");
                    break;

                case 1:

                    bookUI.BookMenu();
                    break;

                case 2:
                    movieUI.MovieMenu();
                    break;

                case 3:
                    
                    musicUI.MusicMenu();
                    break;

                case 4:
                    gameUI.GameMenu();
                    break;
                case 5:
                    RentMediaUI rentMediaUI = new();
                    rentMediaUI.RentMediaMenu(user);
                    break;

            }

        }

    }
}
