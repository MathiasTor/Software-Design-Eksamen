namespace PG3302_Eksamen.Media
{
    public class Book : Media
    {
        //Properties
        private int Pages { get; set; }

        //Constructor
        public Book(string title, string creator, int releaseYear, string genre, int pages)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            Pages = pages;
        }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, Pages: {Pages}";
        }

    }
}
