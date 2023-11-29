using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen_Tests
{
    public class IntegrationTest
    {
        [SetUp]
        public void Setup()
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
        [TearDown] public void TearDown()
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
        public void Add_Book_ToDB_ShouldBeAdded()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();

            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);

            dbLogicBook.AddBookToDb(bookToTest);

            List<Book> books = dbLogicBook.GetAllBooks();

            Book book = books[0];

            // Asssert
            Assert.IsTrue(books.Contains(book));
        }

        [Test]
        public void Remove_Book_FromDB_ShouldBeRemoved()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;

            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();

            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);

            dbLogicBook.AddBookToDb(bookToTest);

            DbLogicBook.DeleteBookFromDb(bookToTest);

            List<Book> books = dbLogicBook.GetAllBooks();

            // Asssert
            Assert.That(books.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Edit_BookTitleInDB_ShouldBeChanged()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();

            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);

            dbLogicBook.AddBookToDb(bookToTest);

            DbLogicBook.EditBookTitle(bookToTest, "newTitle");

            List<Book> books = dbLogicBook.GetAllBooks();

            Book book = books[0];

            // Asssert
            Assert.That(book.Title, Is.EqualTo("newTitle"));
        }
    }
}
