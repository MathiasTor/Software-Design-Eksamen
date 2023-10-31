using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    internal class GameUI
    {
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

            }


        }

        public void DisplayGames()
        {

            Console.WriteLine("test");

        }



    }
}
