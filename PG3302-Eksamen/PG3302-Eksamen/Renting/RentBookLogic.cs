using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentBookLogic
    {
        private SystemUser _user;

        RentBookDbLogic rentBookDbLogic = new();
        public RentBookLogic(SystemUser user)
        {
            this._user = user;
        }

        public List<Book> GetRentableBooks()
        {
            return rentBookDbLogic.GetRentableBooks();
        }

        public void RentBook(Book book)
        {
            rentBookDbLogic.RentBook(_user, book);
        }

    }
}
