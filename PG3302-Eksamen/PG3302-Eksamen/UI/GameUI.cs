using PG3302_Eksamen.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    public class GameUI
    {       
        
        public GameLogic gameLogic = new();
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

            gameLogic.DisplayGames();

            GameMenu();
        }

        private void EditGame()
        {
            Console.Write("Enter the title of the game you wish to edit: ");
            string? oldTitle = Console.ReadLine();
            Console.Write("Enter the new title. ");
            string? newTitle = Console.ReadLine();
            gameLogic.EditGameTitle(oldTitle, newTitle);
            GameMenu();
        }

        private void DeleteGame()
        {
            Console.Write("Enter the Title of the Game you wish to delete: ");
            string userInput = Console.ReadLine();
            gameLogic.RemoveGame(userInput);
            GameMenu();
        }
        
        private void BackToMainMenu()
        {

            ConsoleApp consoleApp = new();
            consoleApp.RunProgram();
        

        }
    }
}
