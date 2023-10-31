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
        protected DateTime Released { get; set; }

        //Constructor
        public Media(string name, string description, DateTime released)
        {
            Name = name;
            Description = description;
            Released = released;
        }

        //ToString
        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Released: {Released}";
        }
    }
}
