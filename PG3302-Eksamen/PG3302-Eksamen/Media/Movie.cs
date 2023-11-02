using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302_Eksamen.Media
{
    [Table("Movies")]
    public class Movie : Media
    {
        //Properties
        public int LengthInMinutes { get; set; }
        
        //Constructor
        public Movie(string title, string creator, int releaseYear, string genre, int lengthInMinutes)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            LengthInMinutes = lengthInMinutes;
        }

        public Movie() { }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Director: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, Length in minutes: {LengthInMinutes}";
        }
    }
}
