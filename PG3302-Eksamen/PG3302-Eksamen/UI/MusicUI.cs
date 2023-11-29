using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.UI
{
    public class MusicUI
    {

        public MusicLogic MusicLogic = new(new DbLogicMusic());
        private SystemUser _user;

        public MusicUI(SystemUser user)
        {
            this._user = user;
        }

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
                
                case 2: 
                    AddSong();
                    break;
                
                case 3: 
                    EditSong();
                    break;
                
                case 4: 
                    DeleteSong();
                    break;
                
                case 9: 
                    BackToMainMenu();
                     break;
                
                
                case 0:
                    break;
                
                default: Console.WriteLine("Invalid input! (1,2,3,4,0)");
                    MusicMenu();
                    break;
            }
        }

        private void DeleteSong()
        {
            Console.WriteLine("Enter title of song to delete: ");
            string title = Console.ReadLine();
            int counter = 0;
            Music songToDelete = new();

            List<Music> songsWithSameTitle = DbLogicMusic.GetAllMusicWithSameTitle(title);

            Console.WriteLine("\n");

            if(songsWithSameTitle.Count > 1)
            {
                printSongsWithSameTitle(songsWithSameTitle);
                Console.WriteLine("Found multiple songs with the same title!");

                Console.WriteLine("Enter ID of song to delete: ");

                try
                {
                    int songIdToDelete = Int32.Parse(Console.ReadLine());
                    songToDelete = songsWithSameTitle[songIdToDelete - 1];
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    DeleteSong();
                }
            }
            else if (songsWithSameTitle.Count == 1)
            {
                songToDelete = songsWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No songs with that title found!");
                MusicMenu();
                return;
            }

            DeleteSong(songToDelete);
        }

        private void DeleteSong(Music song)
        {
            MusicLogic.RemoveSong(song);
            Console.WriteLine($"Song {song.Title} has been deleted!");
            Console.WriteLine("Delete more? Y/N");

            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                DeleteSong();
            }
            else
            {
                Console.Clear();
                MusicMenu();
            }
        }

        private void EditSong()
        {
            Console.WriteLine("Enter title of song to edit: ");
            string title = Console.ReadLine();
            int counter = 0;
            Music songToEdit = new();

            List<Music> songsWithSameTitle = DbLogicMusic.GetAllMusicWithSameTitle(title);
            Console.WriteLine("\n");

            if (songsWithSameTitle.Count > 1)
            {
                printSongsWithSameTitle(songsWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple games with the same title!");
                Console.WriteLine("Enter ID of game to edit: ");

                try
                {
                    int gameIdToEdit = Int32.Parse(Console.ReadLine());
                    songToEdit = songsWithSameTitle[gameIdToEdit - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    EditSong();
                }

            }
            else if (songsWithSameTitle.Count == 1)
            {
                songToEdit = songsWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No games with that title found!");
                MusicMenu();
                return;
            }

            EditSong(songToEdit);
        }

        private void EditSong(Music songToEdit)
        {
            Console.Clear();
            Console.WriteLine("Editing: ");
            Console.WriteLine(songToEdit);

            Console.WriteLine("What would you like to edit?\n" +
                                             "1. Title\n" +
                                             "2. Artist\n" +
                                             "3. Release Year\n" +
                                             "4. Genre\n" +
                                             "5. Length in seconds\n\n" +
                                             "9. Back to Music Menu\n" +
                                             "0. Exit");

            Console.Write("Please enter your input here: ");
            String? userInput = Console.ReadLine();

            try
            {
                int userInputResult = Int32.Parse(userInput);

                switch (userInputResult)
                {
                    case 1:
                        Console.WriteLine("Enter new title: ");
                        string newTitle = Console.ReadLine();
                        MusicLogic.EditSongTitle(songToEdit, newTitle);
                        break;

                    case 2:
                        Console.WriteLine("Enter new artist: ");
                        string newCreator = Console.ReadLine();
                        MusicLogic.EditSongArtist(songToEdit, newCreator);
                        break;

                    case 3:
                        Console.WriteLine("Enter new release year: ");
                        int newReleaseYear = Int32.Parse(Console.ReadLine());
                        MusicLogic.EditSongReleaseYear(songToEdit, newReleaseYear);
                        break;

                    case 4:
                        Console.WriteLine("Enter new genre: ");
                        string newGenre = Console.ReadLine();
                        MusicLogic.EditSongGenre(songToEdit, newGenre);
                        break;

                    case 5:
                        Console.WriteLine("Enter new length in seconds: ");
                        int newLengthInSeconds = Int32.Parse(Console.ReadLine());
                        MusicLogic.EditSongLength(songToEdit, newLengthInSeconds);
                        break;

                    case 9:
                        MusicMenu();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid input! (1,2,3,4,5,9,0)");
                        EditSong(songToEdit);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input! (1,2,3,4,5,9,0)");
                EditSong(songToEdit);
            }

            Console.WriteLine("Edit more? Y/N");
            string answer = Console.ReadLine();
            Console.WriteLine(answer);
            if (answer == "Y" || answer == "y")
            {
                EditSong(songToEdit);
            }
            else
            {
                Console.Clear();
                MusicMenu();
            }
        }

        private void printSongsWithSameTitle(List<Music> songsWithSameTitle)
        {
            int counter = 0;
            foreach (Music song in songsWithSameTitle)
            {
                counter++;
                Console.WriteLine($"{counter} - {song}");
            }
        }

        private void DisplaySongs()
        {
            Console.WriteLine("\n" +
                              "------------------" +
                              "\n");
            MusicLogic.DisplaySongs();
            
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

            MusicLogic.AddSong(title, creator, year, genre, lengthInSeconds);
            
            MusicMenu();

        }
        
        
        private void BackToMainMenu()
        {
            Console.Clear();
            ConsoleApp consoleApp = new();
            consoleApp.MainMenu(_user);
            
        }
        
    }

}

