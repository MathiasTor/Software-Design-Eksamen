using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    public class ConsoleApp
    {
       

        BookUI bookUI = new();
        GameUI gameUI = new();
        public void RunProgram()
        {
            
            Console.WriteLine("Welcome the the Library of Media!\n" +
                "Please choose what type of media you would like to access:\n\n" +
                "1. Books\n" +
                "2. Movies\n" +
                "3. Music\n" +
                "4. Games\n" +
                "\nIf you would like to exit the program, please type 0.\n\n");
            Console.Write("Write your choice here: ");

            string ? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);
            switch (userInputResult)
            {

                case 0:

                    Console.WriteLine("program still running!");
                    break;

                case 1:

                    bookUI.BookMenu();


                    break; 
                case 2:

                    break;

                    case 4:
                    gameUI.GameMenu();

                    break;

            }

        }

    }
}
