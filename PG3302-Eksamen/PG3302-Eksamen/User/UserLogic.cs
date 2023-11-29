using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.User
{
    public class UserLogic
    {
        List<SystemUser> _users = new ();
        UserDbLogic _userDbLogic = new();

        public UserLogic()
        {

        }

        //Add _user
        public void AddUser(SystemUser user)
        {
            _users.Add(user);
            _userDbLogic.AddUser(user);
        }

        //Remove _user
        public void RemoveUser(SystemUser user)
        {
            _users.Remove(user);
            _userDbLogic.RemoveUser(user);
        }

        //Validate _user
        public bool ValidateUser(SystemUser user)
        {
            return _userDbLogic.ValidateUser(user);
        }

        //Check if username is taken
        public bool IsUsernameTaken(SystemUser user)
        {
            return _userDbLogic.IsUsernameTaken(user);
        }
    }
}
