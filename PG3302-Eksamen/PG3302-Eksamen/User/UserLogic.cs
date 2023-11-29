namespace PG3302_Eksamen.User
{
    public class UserLogic
    {
        //Fields
        private List<SystemUser> _users = new ();
        private UserDbLogic _userDbLogic = new();

        //Constructor
        public UserLogic()
        {

        }

        //Methods
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
