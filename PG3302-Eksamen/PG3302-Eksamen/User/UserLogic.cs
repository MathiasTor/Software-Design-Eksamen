using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.User
{
    public class UserLogic
    {
        List<SystemUser> users = new ();
        UserDbLogic userDbLogic = new();

        public UserLogic()
        {

        }

        //Add user
        public void AddUser(SystemUser user)
        {
            users.Add(user);
            userDbLogic.AddUser(user);
        }

        //Remove user
        public void RemoveUser(SystemUser user)
        {
            users.Remove(user);
            userDbLogic.RemoveUser(user);
        }

        //Validate user
        public bool ValidateUser(SystemUser user)
        {
            return userDbLogic.ValidateUser(user);
        }

        //Check if username is taken
        public bool IsUsernameTaken(SystemUser user)
        {
            return userDbLogic.IsUsernameTaken(user);
        }
    }
}
