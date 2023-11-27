using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;

namespace PG3302_Eksamen.User
{
    public class UserDbLogic
    {
        //Add user to db
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

        //Remove user from db
        public void RemoveUser(SystemUser user)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        //Validate user
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

        //Promote user to admin
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
