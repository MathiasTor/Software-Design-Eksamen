using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    public class GameUI
    {       
        
        public GameLogic gameLogic = new(new DbLogicGame());
        private DbLogicGame dbLogicGame = new();
        SystemUser user;

        public GameUI(SystemUser user)
        {
            this.user = user;
        }

        public void GameMenu()
        {

            Console.WriteLine("\n\nWelcome to the game registry\n" +
                              "Please Choose what you would like to do.\n" +
                              "1. Display games.\n" +
                              "2. Add a new game.\n" +
                              "3. Edit existing game.\n" +
                              "4. Delete a game.\n\n" +
                              "--------------------------\n\n" +
                              "9. Back to Main Menu\n" +
                              "0. To exit");

            Console.Write("\nPlease enter your input here: ");

            String? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);

            switch (userInputResult)
            {
                case 1:
                    DisplayGames();
                    break;

                case 2:
                    AddGame();
                    break;

                case 3:
                    EditGame();
                    break;

                case 4:
                    DeleteGame();
                    break;
                
                case 9: BackToMainMenu();
                    break;
                
                case 0:
                    break;

                default:
                    Console.WriteLine("Invalid input! (1,2,3,4,0)");
                    GameMenu();
                    break;
            }
        }

        public void DisplayGames()
        {
            Console.WriteLine("\n" + 
                              "------------------" +
                              "\n");
            gameLogic.DisplayGames();

            GameMenu();

        }

        private void AddGame()
        {

            Console.Write("Game title: ");
            string title = Console.ReadLine();

            Console.Write("Game Creator: ");
            string creator = Console.ReadLine();

            Console.Write("Release Year: ");
            int releaseYear = Int32.Parse(Console.ReadLine());

            Console.Write("Game Genre: ");
            string genre = Console.ReadLine();
            
            Console.Write("Game Platform: ");
            string platform = Console.ReadLine();

            gameLogic.AddGame(title, creator, releaseYear, genre, platform);

            GameMenu();
        }

        private void EditGame()
        {
            Console.WriteLine("Enter title of game to edit");
            String? titleToEdit = Console.ReadLine();
            int counter = 0;
            Game gameToEdit = new();

            List<Game> gamesWithSameTitle = dbLogicGame.GetAllGamesWithSameTitle(titleToEdit);
            Console.WriteLine("\n");

            if (gamesWithSameTitle.Count > 1)
            {
                printGamesWithSameTitle(gamesWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple games with the same title!");
                Console.WriteLine("Enter ID of game to edit: ");

                try
                {
                    int gameIdToEdit = Int32.Parse(Console.ReadLine());
                    gameToEdit = gamesWithSameTitle[gameIdToEdit - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    EditGame();
                }

            }
            else if (gamesWithSameTitle.Count == 1)
            {
                gameToEdit = gamesWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No games with that title found!");
                GameMenu();
                return;
            }

            EditGame(gameToEdit);
        }

        private void EditGame(Game gameToEdit)
        {
            Console.Clear();
            Console.WriteLine("Editing:");
            Console.WriteLine(gameToEdit+"\n");

            Console.WriteLine("What would you like to edit?\n" +
                                             "1. Title\n" +
                                             "2. Creator\n" +
                                             "3. Release Year\n" +
                                             "4. Genre\n" +
                                             "5. Platform\n" +
                                             "9. Back to Game Menu\n" +
                                             "0. Exit");

            Console.Write("Please enter your input here: ");
            String? userInput = Console.ReadLine();

            try
            {
                int? userInputResult = Int32.Parse(userInput);

                switch (userInputResult)
                {
                    case 1:
                        Console.Write("Enter new title: ");
                        string newTitle = Console.ReadLine();
                        gameLogic.EditGameTitle(gameToEdit, newTitle);
                        break;

                    case 2:
                        Console.Write("Enter new creator: ");
                        string newCreator = Console.ReadLine();
                        gameLogic.EditGameCreator(gameToEdit, newCreator);
                        break;

                    case 3:
                        Console.Write("Enter new release year: ");
                        int newReleaseYear = Int32.Parse(Console.ReadLine());
                        gameLogic.EditGameReleaseYear(gameToEdit, newReleaseYear);
                        break;

                    case 4:
                        Console.Write("Enter new genre: ");
                        string newGenre = Console.ReadLine();
                        gameLogic.EditGameGenre(gameToEdit, newGenre);
                        break;

                    case 5:
                        Console.Write("Enter new platform: ");
                        string newPlatform = Console.ReadLine();
                        gameLogic.EditGamePlatform(gameToEdit, newPlatform);
                        break;

                    case 9:
                        GameMenu();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid input! (1,2,3,4,5,9,0)");
                        EditGame(gameToEdit);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input!");
                EditGame(gameToEdit);
                return;
            }
            
            Console.WriteLine("Game edited!");
            Console.WriteLine("Edit more? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                EditGame(gameToEdit);
            }
            else
            {
                Console.Clear();
                GameMenu();
            }
            
        }

        private void DeleteGame()
        {
            Console.Write("Enter the Title of the Game you wish to delete: ");
            string titleToDelete = Console.ReadLine();
            List<Game> gamesWithSameTitle = dbLogicGame.GetAllGamesWithSameTitle(titleToDelete);
            int counter = 0;

            Game gameToDelete = new();

            if (gamesWithSameTitle.Count > 1)
            {
                printGamesWithSameTitle(gamesWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple games with the same title!");
                Console.WriteLine("Enter ID of game to delete: ");

                try
                {
                    int gameIdToDelete = Int32.Parse(Console.ReadLine());
                    gameToDelete = (Game)gamesWithSameTitle[gameIdToDelete - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    DeleteGame();
                }


            }
            else if (gamesWithSameTitle.Count == 1)
            {
                gameToDelete = (Game)gamesWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No games with that title found!");
                GameMenu();
                return;
            }
            DeleteGame(gameToDelete);
        }

        private void DeleteGame(Game game)
        {
            gameLogic.RemoveGame(game);
            Console.WriteLine("Game deleted!");
            Console.WriteLine("Delete more? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                DeleteGame();
            }
            else
            {
                Console.Clear();
                GameMenu();
            }
        }

        private void printGamesWithSameTitle(List<Game> gamesWithSameTitle)
        {
            int counter = 0;
            foreach (Game game in gamesWithSameTitle)
            {
                counter++;
                Console.WriteLine($"{counter} - {game}");
            }
        }

        private void BackToMainMenu()
        {
            Console.Clear();
            ConsoleApp consoleApp = new();
            consoleApp.MainMenu(user);
        }
    }
}
