using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Logic;

namespace PG3302_Eksamen.UI
{
    public class MusicUI
    {

        public MusicLogic musicLogic = new();

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
                    DisplaySongs();
                    break;
                
                case 2: AddSong();
                    break;
                
                case 3: EditSong();
                    break;
                
                case 4: DeleteSong();
                    break;
                
                case 9: BackToMainMenu();
                     break;
                
                
                case 0:
                    break;
                
                default: Console.WriteLine("Invalid input! (1,2,3,4,0)");
                    MusicMenu();
                    break;
            }
        }

        private void DisplaySongs()
        {

            musicLogic.DisplaySongs();
            
            MusicMenu();
        }
        
        private void AddSong()
        {
           
            Console.Write("Song title: ");
            string title = Console.ReadLine();
       
            Console.Write("Song Artist: ");
            string creator = Console.ReadLine();
          
            Console.Write("Release Year: ");
           
            int year = Int32.Parse(Console.ReadLine());

            Console.Write("Song Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Length in seconds: ");
            int lengthInSeconds = Int32.Parse(Console.ReadLine());

            musicLogic.AddSong(title, creator, year, genre, lengthInSeconds);

            musicLogic.DisplaySongs();
            
            MusicMenu();

        }
        
        private void EditSong()
        {
            Console.Write("Enter the title of the Song you wish to edit: ");
            string? oldTitle = Console.ReadLine();
            Console.Write("Enter the new title. ");
            string? newTitle = Console.ReadLine();
            musicLogic.EditSongTitle(oldTitle, newTitle);
            MusicMenu();
        }
        
        private void DeleteSong()
        {
            Console.Write("Enter the Title of the Song you wish to delete: ");
            string userInput = Console.ReadLine();
            musicLogic.RemoveSong(userInput);
            MusicMenu();
        }
        
        private void BackToMainMenu()
        {

            ConsoleApp consoleApp = new();
            consoleApp.RunProgram();
            
        }
        
    }

}

