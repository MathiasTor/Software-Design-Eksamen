using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    public abstract class Media
    {
        //Properties
        public string? Title { get; set; }
        public string? Creator { get; set; }
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }

    }
}
