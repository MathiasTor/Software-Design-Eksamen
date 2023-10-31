using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Media
{
    public class Media
    {
        //Private fields
        private string _name
        {
            get => _name;
            set => _name = value;
        }
        private string _description
        {
            get => _description;
            set => _description = value;
        }
        private string _type
        {
            get => _type;
            set => _type = value;
        }
        private DateTime _released
        {
            get => _released; 
            set => _released = value;
        }

        //Constructor
        public Media(string name, string description, string type, DateTime released)
        {
            _name = name;
            _description = description;
            _type = type;
            _released = released;
        }
    }
}
