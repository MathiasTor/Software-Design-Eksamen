using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    public class Book : Media
    {
        //Properties
        public int Pages { get; set; }

        //Constructor
        public Book(string title, string author, int releaseYear, string genre, int pages)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Genre = genre;
            Pages = pages;
        }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Release Year: {ReleaseYear}, Genre: {Genre}, Pages: {Pages}";
        }

    }
}
