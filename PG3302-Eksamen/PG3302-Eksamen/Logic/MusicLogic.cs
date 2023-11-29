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

        readonly DbLogicMusic DbLogic;

        public MusicLogic (DbLogicMusic dbLogicMusic) {
            DbLogic = dbLogicMusic;
            Songs = new List<Music> ();
        }
        
        //Add a Song
        public void AddSong(string title, string artist, int releaseYear, string genre, int lengthInSeconds)
        {
            Music musicToAdd = new Music(title, artist, releaseYear, genre, lengthInSeconds);

            Songs.Add(musicToAdd);
            DbLogic.AddMusicToDb(musicToAdd);

            Console.WriteLine($"Song {title} has been added!");

        }
        
        //Remove music
        public void RemoveSong(Music song)
        {
            Songs.Remove(song);
            DbLogic.DeleteMusicFromDb(song);
        }
        
        //Print all songs
        public void DisplaySongs()
        {
            DbLogic.PrintAllMusicFromDb();
        }
        
        //Check if song exists - returns true/false
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
        
        //Edit song title
        public void EditSongTitle(Music song, String newTitle)
        {
            song.Title = newTitle;
            DbLogicMusic.EditMusicTitle(song, newTitle);
        }

        //Edit song artist
        public void EditSongArtist(Music song, String newArtist)
        {
            song.Creator = newArtist;
            DbLogicMusic.EditMusicArtist(song, newArtist);
        }

        //Edit song release year
        public void EditSongReleaseYear(Music song, int newReleaseYear)
        {
            song.ReleaseYear = newReleaseYear;
            DbLogicMusic.EditMusicReleaseYear(song, newReleaseYear);
        }

        //Edit song length
        public void EditSongLength(Music song, int newLength)
        {
            song.LengthInSeconds = newLength;
            DbLogicMusic.EditMusicLength(song, newLength);
        }

        //Edit song genre
        public void EditSongGenre(Music song, String newGenre)
        {
            song.Genre = newGenre;
            DbLogicMusic.EditMusicGenre(song, newGenre);
        }

    }
    
}
