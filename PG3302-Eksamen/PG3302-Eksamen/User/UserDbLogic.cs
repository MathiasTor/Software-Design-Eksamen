using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;

namespace PG3302_Eksamen.User
{
    public class UserDbLogic
    {

        //Methods
        //Add _user to db
        public void AddUser(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        //Check if username is taken
        public bool IsUsernameTaken(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (SystemUser u in db.Users)
                {
                    if (u.Name == user.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        //Remove _user from db
        public void RemoveUser(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        //Validate _user
        public bool ValidateUser(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (SystemUser u in db.Users)
                {
                    if (u.Name == user.Name && u.Password == user.Password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        //Promote _user to admin
        public void PromoteUser(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (SystemUser u in db.Users)
                {
                    if (u.Name == user.Name)
                    {
                        u.IsAdmin = true;
                    }
                }
                db.SaveChanges();
            }
        }

    }
}
