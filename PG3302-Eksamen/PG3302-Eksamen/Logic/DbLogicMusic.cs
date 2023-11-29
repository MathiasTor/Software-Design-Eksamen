using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class DbLogicMusic
    {
        //Methods
        //Add music to db
        public void AddMusicToDb(Music music)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Add(music);
                db.SaveChanges();
            }

        }

        //Delete music from db
        public Music? DeleteMusicFromDb(Music music)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                if (music != null)
                {
                    db.Remove(music);
                    db.SaveChanges();
                }
                return music;
            }

        }

        //Edit music title
        public static Music? EditMusicTitle(Music music, string newTitle)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (music != null)
                {
                    music.Title = newTitle;
                    db.Update(music);
                    db.SaveChanges();
                }
                return music;

            }
        }

        //Edit music artist
        public static Music? EditMusicArtist(Music music, string newArtist)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (music != null)
                {
                    music.Creator = newArtist;
                    db.Update(music);
                    db.SaveChanges();
                }
                return music;

            }
        }

        //Edit music release year
        public static Music? EditMusicReleaseYear(Music music, int newReleaseYear)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (music != null)
                {
                    music.ReleaseYear = newReleaseYear;
                    db.Update(music);
                    db.SaveChanges();
                }
                return music;

            }
        }

        //Edit music genre
        public static Music? EditMusicGenre(Music music, string newGenre)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (music != null)
                {
                    music.Genre = newGenre;
                    db.Update(music);
                    db.SaveChanges();
                }
                return music;

            }
        }

        //Edit music Length
        public static Music? EditMusicLength(Music music, int newLength)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {

                if (music != null)
                {
                    music.LengthInSeconds = newLength;
                    db.Update(music);
                    db.SaveChanges();
                }
                return music;

            }
        }

        //Get all music with same title
        public static List<Music> GetAllMusicWithSameTitle(string title)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                var music = db.Music.Where(m => m.Title == title).ToList();
                return music;
            }
        }

        //Print all music
        public void PrintAllMusicFromDb()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                var music = db.Music.ToList();

                foreach (var song in music)
                {
                    Console.WriteLine(song);
                }
            }
        }

        //Get all music
        public List<Music> GetAllMusic()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<Music> music = db.Music.ToList();
                return music;
            }
        }
    }
}
