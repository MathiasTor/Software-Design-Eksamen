using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302_Eksamen.Media
{
    [Table("Music")]
    public class Music : Media
    {

        //Properties
        public int LengthInSeconds{ get; set; }

        //Constructor
        public Music(string title, string creator, int releaseYear, string genre, int lengthInSeconds)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            LengthInSeconds = lengthInSeconds;
        }

        public Music() { }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, artist: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, length: {LengthInSeconds}";
        }

    }
}
