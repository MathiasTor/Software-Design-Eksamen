using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    public class MovieUI
    {

        public void MovieMenu()
        {

            Console.WriteLine("\n\nWelcome to the book registry\n" +
                    "Please Choose what you would like to do.\n" +
                    "1. Display books.\n" +
                    "2. Add a new book.\n" +
                    "3. Edit existing book.\n" +
                    "4. Delete a book.\n\n" +
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

            }

        }

        public void DisplayMovies() { }

}
}
