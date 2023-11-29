using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class MusicLogic
    {
        //Properties
        public List<Music> Songs { get; set; }

        //Field
        readonly DbLogicMusic _dbLogic;

        //Constructor
        public MusicLogic (DbLogicMusic dbLogicMusic) {
            _dbLogic = dbLogicMusic;
            Songs = new List<Music> ();
        }
        
        //Methods
        //Add a Song
        public void AddSong(string title, string artist, int releaseYear, string genre, int lengthInSeconds)
        {
            Music musicToAdd = new Music(title, artist, releaseYear, genre, lengthInSeconds);

            Songs.Add(musicToAdd);
            _dbLogic.AddMusicToDb(musicToAdd);

            Console.WriteLine($"Song {title} has been added!");

        }
        
        //Remove music
        public void RemoveSong(Music song)
        {
            Songs.Remove(song);
            _dbLogic.DeleteMusicFromDb(song);
        }
        
        //Print all songs
        public void DisplaySongs()
        {
            _dbLogic.PrintAllMusicFromDb();
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
