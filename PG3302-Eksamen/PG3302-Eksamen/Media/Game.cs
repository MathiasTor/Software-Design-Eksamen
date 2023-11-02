using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    [Table("Games")]
    public class Game : Media
    {
        //Properties
        public string? Platform { get; set; }

        //Constructor
        public Game(string title, string creator, int releaseYear, string genre, string platform)
        {
            Title = title;
            Creator = creator;
            ReleaseYear = releaseYear;
            Genre = genre;
            Platform = platform;
        }
        public Game() { }

        //Methods
        public override string ToString()
        {
            return $"Title: {Title}, Game-Studio: {Creator}, Release Year: {ReleaseYear}, Genre: {Genre}, Platform: {Platform}";
        }
    }
}
