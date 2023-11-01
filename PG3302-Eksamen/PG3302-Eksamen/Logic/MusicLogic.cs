using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public class MusicLogic
    {

        public List<Music> Songs { get; set; }

        public MusicLogic () { 
        Songs = new List<Music> ();
            //Sample music/songs

        }
        
        //Add a book
        public void AddSong(string title, string artist, int releaseYear, string genre, int lengthInSeconds)
        {
            //Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Songs.Add(new Music(title, artist, releaseYear, genre, lengthInSeconds));
            Console.WriteLine($"Book {title} has been added!");

        }
        
        //Remove a book
        public void RemoveSong(String title)
        {
            Songs.RemoveAll(song => song.Title == title);
        }
        
        //Print all books
        public void DisplaySongs()
        {
            foreach (Music song in Songs)
            {
                Console.WriteLine(song);
            }
        }
        
        //Check if book exists - returns true/false
        public bool CheckIfSongExists(string title)
        {
            foreach (Music song in Songs)
            {
                if (song.Title == title)
                {
                    return true;
                }
            }
            return false;
        }
        
        //Edit book title - takes in old title and new title
        public void EditSongTitle(String title, String newTitle)
        {
            for(int i = 0; i < Songs.Count; i++)
            {
                if (Songs[i].Title == title)
                {
                    Songs[i].Title = newTitle;
                }
            }
        }

    }
    
}
