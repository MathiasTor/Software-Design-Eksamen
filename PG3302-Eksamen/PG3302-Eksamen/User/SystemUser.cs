using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302_Eksamen.User
{
   [Table("Users")]
    public class SystemUser
    {
        //Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }

        //Constructors
        public SystemUser(string Name, String Email, String Password, bool IsAdmin) {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
        }

        public SystemUser() { }
    }
}
