using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.UI;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentBookUI
    {
        private SystemUser _user;
        public RentBookUI(SystemUser user)
        {
            this._user = user;
        }

        internal void RentBookMenu(SystemUser user)
        {
            RentBookLogic rentBookLogic = new(user);

            List<Book> rentableBooks = rentBookLogic.GetRentableBooks();

            Console.Clear();

            Console.WriteLine("Rentable books:");
            foreach (Book b in rentableBooks)
            {
                Console.WriteLine(rentableBooks.IndexOf(b)+1 + " - " + b);
            }

            Console.Write("Enter ID of book to rent (Back: 0): ");

            try
            {
                int bookID = Convert.ToInt32(Console.ReadLine());

                if(bookID == 0)
                {
                    Console.Clear();
                    RentMediaUI rentMediaUI1 = new();
                    rentMediaUI1.RentMediaMenu(user);
                    return;
                }

                if (bookID > rentableBooks.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid ID!");
                    RentBookMenu(user);
                    return;
                }

                Book bookToRent = (Book)rentableBooks[bookID-1];

                Console.Clear();

                Console.WriteLine("You have rented: " + bookToRent.Title);

                rentBookLogic.RentBook(bookToRent);

                RentMediaUI rentMediaUI = new();
                rentMediaUI.RentMediaMenu(user);
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input!");
                RentBookMenu(user);
                return;
            }
        }
    }
}
