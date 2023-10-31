using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    public class Movie : Media
    {
        //Properties
        private int LengthInMinutes { get; set; }
        
        //Constructor
        public Movie(string title, string creator, int releaseYear, string genre, int lengthInMinutes)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            LengthInMinutes = lengthInMinutes;
        }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Director: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, Length in minutes: {LengthInMinutes}";
        }
    }
}
