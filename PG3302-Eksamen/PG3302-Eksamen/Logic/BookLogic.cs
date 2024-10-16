﻿using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class BookLogic
    {
        //Properties
        public List<Book> Books { get; set; }

        //Field
        readonly DbLogicBook _dbLogic;

        //Constructor
        public BookLogic(DbLogicBook dbLogic)
        {
            this._dbLogic = dbLogic;
            Books = new List<Book>();
        }

        //Methods
        //Add a book
        public void AddBook(string title, string creator, int releaseYear, string genre, int pages)
        {
            Book bookToAdd = new Book(title, creator, releaseYear, genre, pages);

            Books.Add(bookToAdd);
            Console.WriteLine($"Book {title} has been added!");
            
            _dbLogic.AddBookToDb(bookToAdd);
        }

        //Remove a book
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            DbLogicBook.DeleteBookFromDb(book);

        }

        //Print all books
        public void DisplayBooks()
        {
            _dbLogic.PrintAllBooksFromDb();
            
        }

        //Edit book title
        public void EditBookTitle(Book book, String newTitle)
        {
            book.Title = newTitle;
            DbLogicBook.EditBookTitle(book, newTitle);
        }

        //Edit book author
        public void EditBookAuthor(Book book, String newAuthor)
        {
            book.Creator = newAuthor;
            DbLogicBook.EditBookAuthor(book, newAuthor);
        }

        //Edit book release year
        public void EditBookReleaseYear(Book book, int newReleaseYear)
        {
            book.ReleaseYear = newReleaseYear;
            DbLogicBook.EditBookReleaseYear(book, newReleaseYear);
        }

        //Edit book genre - takes in old genre and new genre
        public void EditBookGenre(Book book, String newGenre)
        {
            book.Genre = newGenre;
            DbLogicBook.EditBookGenre(book, newGenre);
        }

        //Edit book number of pages
        public void EditBookPages(Book book, int newPages)
        {
            book.Pages = newPages;
            DbLogicBook.EditBookPages(book, newPages);
        }
    }
}
