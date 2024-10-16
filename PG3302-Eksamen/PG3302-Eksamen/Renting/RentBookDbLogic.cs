﻿using System.Collections;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentBookDbLogic
    {
        //Field
        private DbLogicBook _dbLogic = new();

        //Constructor
        public RentBookDbLogic()
        {
        }

        //Methods
        //Get all books that are not rented
        public List<Book> GetRentableBooks()
        {
            List<Book> books = _dbLogic.GetAllBooks();
            ArrayList rentedBooks = new();

            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (RentedMedia rm in db.RentedMedia)
                {
                    foreach (Book b in books)
                    {
                        if (!rm.IsReturned && rm.MediaId == b.Id && rm.Media == "Book")
                        {
                            rentedBooks.Add(b);
                        }
                    }
                }

                foreach (Book b in rentedBooks)
                {
                    books.Remove(b);
                }

                return books;
            }
        }

        //Get all rented books
        public void RentBook(SystemUser user, Book book)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                DateTime currentTime = DateTime.Now;
                RentedMedia rentedMedia = new("Book", book.Id, user.Name, currentTime, false);

                db.Add(rentedMedia);
                db.SaveChanges();
            }
        }
    }
}
