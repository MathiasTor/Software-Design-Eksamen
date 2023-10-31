using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.UI
{
    public class MusicUI
    {

        public void MusicMenu()
        {

            Console.WriteLine("\n\nWelcome to the music registry\n" +
                "Please Choose what you would like to do.\n" +
                "1. Display songs.\n" +
                "2. Add a new song.\n" +
                "3. Edit existing song.\n" +
                "4. Delete a song.\n\n" +
                "--------------------------\n\n" +
                "9. Back to Main Menu\n" +
                "0. To exit");

            Console.Write("\nPlease enter your input here: ");

            String? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);

            switch (userInputResult)
            {
                case 1:
                    DisplayMusic();
                    break;

            }


        }

        public void DisplayMusic()
        {

            Console.WriteLine("test");

        }



    }





}
}
