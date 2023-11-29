using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentBookLogic
    {
        //Field
        private SystemUser _user;
        private RentBookDbLogic _rentBookDbLogic = new();

        //Constructor
        public RentBookLogic(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        //Get all books that are not rented
        public List<Book> GetRentableBooks()
        {
            return _rentBookDbLogic.GetRentableBooks();
        }

        //Rent book
        public void RentBook(Book book)
        {
            _rentBookDbLogic.RentBook(_user, book);
        }

    }
}
