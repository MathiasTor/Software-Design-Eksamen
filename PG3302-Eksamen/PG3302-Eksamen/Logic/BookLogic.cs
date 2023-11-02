﻿using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        public List<Book> Books { get; set; }


        public BookLogic()
        {
            Books = new List<Book>();
        }

        //Add a book
        public void AddBook(string title, string creator, int releaseYear, string genre, int pages)
        {
            Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Books.Add(bookToAdd);
            Console.WriteLine($"Book {title} has been added!");
            var options = new DbContextOptionsBuilder<MediaDbContext>()
            .UseSqlite(@"Data Source = .\Resources\Media.db")
            .Options;

            using (var db = new MediaDbContext(options))
            {
                db.Add(bookToAdd);
                db.SaveChanges();
            }
            
        }

        //Remove a book
        public void RemoveBook(String title)
        {
            Books.RemoveAll(book => book.Title == title);

        }

        //Print all books
        public void DisplayBooks()
        {
            var options = new DbContextOptionsBuilder<MediaDbContext>()
            .UseSqlite(@"Data Source = .\Resources\Media.db")
            .Options;

            using (var db = new MediaDbContext(options))
            {
                if (db.Books != null)
                {
                    foreach (Book book in db.Books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
            
        }

        //Check if book exists - returns true/false
        public bool CheckIfBookExists(string title)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    return true;
                }
            }
            return false;
        }

        //Edit book title - takes in old title and new title
        public void EditBookTitle(String title, String newTitle)
        {
           for(int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Title == title)
                {
                    Books[i].Title = newTitle;
                }
            }
        }
    }
}
