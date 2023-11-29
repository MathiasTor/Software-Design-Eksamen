using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using NUnit.Framework.Internal;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using System.Collections;
using static System.Formats.Asn1.AsnWriter;
using System.Transactions;
using PG3302_Eksamen.Database;

namespace PG3302_Eksamen_Tests
{
    public class Tests
    {
        [Test]
        public void Add_Book_ShouldBeAddedToList()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act

            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            // Asssert
            Assert.That(books.Count() == 1);
        }
    
        [Test]
        public void Remove_Book_ListShouldBeEmpty()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            bookLogic.RemoveBook(bookLogic.Books[0]);

            List<Book> books = bookLogic.Books;

            // Asssert
            Assert.That(books.Count() == 0);
        }

        [Test]
        public void Edit_BookTitle_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            Book bookToTest = bookLogic.Books[0];

            bookLogic.EditBookTitle(bookToTest, "newTitle");

            // Asssert
            Assert.That(bookToTest.Title == "newTitle");
            Assert.That(books[0].Title == "newTitle");
        }

        [Test]
        public void Edit_BookAuthor_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            Book bookToTest = bookLogic.Books[0];

            bookLogic.EditBookAuthor(bookToTest, "newAuthor");

            // Asssert
            Assert.That(bookToTest.Creator == "newAuthor");
            Assert.That(books[0].Creator == "newAuthor");
        }
        [Test]
        public void Edit_BookRelease_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            Book bookToTest = bookLogic.Books[0];

            bookLogic.EditBookReleaseYear(bookToTest, 999);

            // Asssert
            Assert.That(bookToTest.ReleaseYear == 999);
            Assert.That(books[0].ReleaseYear == 999);
        }

        [Test]
        public void Edit_BookGenre_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            Book bookToTest = bookLogic.Books[0];

            bookLogic.EditBookGenre(bookToTest, "newGenre");

            // Asssert
            Assert.That(bookToTest.Genre == "newGenre");
            Assert.That(books[0].Genre == "newGenre");
        }

        [Test]
        public void Edit_BookPages_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);

            List<Book> books = bookLogic.Books;

            Book bookToTest = bookLogic.Books[0];

            bookLogic.EditBookPages(bookToTest, 999);

            // Asssert
            Assert.That(bookToTest.Pages == 999);
            Assert.That(books[0].Pages == 999);
        }
    }
     
}