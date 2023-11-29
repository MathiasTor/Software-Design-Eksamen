using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using NUnit.Framework.Internal;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using System.Collections;
using static System.Formats.Asn1.AsnWriter;
using System.Transactions;
using PG3302_Eksamen.Database;
using System.ComponentModel;

namespace PG3302_Eksamen_Tests
{
    public class Tests
    {
        [TearDown]
        public void TearDown()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (Book book in db.Books)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

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

            Book book = books[0];

            // Asssert
            Assert.IsTrue(books.Contains(book));
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
            Assert.That(books.Count(), Is.EqualTo(0));
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
            Assert.That(bookToTest.Title, Is.EqualTo("newTitle"));
            Assert.That(books[0].Title, Is.EqualTo("newTitle"));
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
            Assert.That(bookToTest.Creator, Is.EqualTo("newAuthor"));
            Assert.That(books[0].Creator, Is.EqualTo("newAuthor"));
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
            Assert.That(bookToTest.ReleaseYear, Is.EqualTo(999));
            Assert.That(books[0].ReleaseYear, Is.EqualTo(999));
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
            Assert.That(bookToTest.Genre, Is.EqualTo("newGenre"));
            Assert.That(books[0].Genre, Is.EqualTo("newGenre"));
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
            Assert.That(bookToTest.Pages, Is.EqualTo(999));
            Assert.That(books[0].Pages, Is.EqualTo(999));
        }
    }
     
}