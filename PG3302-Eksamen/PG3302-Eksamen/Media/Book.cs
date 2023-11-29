using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302_Eksamen.Media
{
    [Table("Books")]
    public class Book : Media
    {
        //Properties
        public int? Pages { get; set; }

        //Constructor
        public Book(string title, string creator, int releaseYear, string genre, int pages)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            Pages = pages;
        }

        public Book() { }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, Pages: {Pages}";
        }

    }
}
