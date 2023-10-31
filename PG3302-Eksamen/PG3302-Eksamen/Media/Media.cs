using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    public class Media
    {
        //Properties
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected string Type { get; set; }
        protected DateTime Released { get; set; }

        //Constructor
        public Media(string name, string description, string type, DateTime released)
        {
            Name = name;
            Description = description;
            Type = type;
            Released = released;
        }
    }
}
