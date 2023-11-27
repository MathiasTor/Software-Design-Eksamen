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
        SystemUser user;

        RentBookDbLogic rentBookDbLogic = new();
        public RentBookLogic(SystemUser user)
        {
            this.user = user;
        }

        public ArrayList GetRentableBooks()
        {
            return rentBookDbLogic.GetRentableBooks();
        }

        public void RentBook(Book book)
        {
            rentBookDbLogic.RentBook(user, book);
        }

    }
}
