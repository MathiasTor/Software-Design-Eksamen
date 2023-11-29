using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.Renting;
using PG3302_Eksamen.User;
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

                foreach (RentedMedia rm in db.RentedMedia)
                {
                    db.RentedMedia.Remove(rm);
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

                foreach (RentedMedia rm in db.RentedMedia)
                {
                    db.RentedMedia.Remove(rm);
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

        [Test]
        public void GetRentable_Books_ShouldReturn1Book()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();
            RentBookDbLogic rentBookDbLogic = new();


            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);

            dbLogicBook.AddBookToDb(bookToTest);

            List<Book> rentableBooks = rentBookDbLogic.GetRentableBooks();

            // Asssert
            Assert.That(rentableBooks.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Rent_Book_ShouldBeRented()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();
            RentBookDbLogic rentBookDbLogic = new();


            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);
            SystemUser user = new("Name", "Email", "pw", false);

            dbLogicBook.AddBookToDb(bookToTest);
            rentBookDbLogic.RentBook(user, bookToTest);

            RentMediaDbLogic rentMediaDbLogic = new(user);

            rentMediaDbLogic.GetRentedMedia();

            List<RentedMedia> rentedMedia = rentMediaDbLogic.GetRentedMedia();

            // Asssert
            Assert.That(rentedMedia.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Return_Book_ShouldBeReturned()
        {
            // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new(new DbLogicBook());
            DbLogicBook dbLogicBook = new();
            RentBookDbLogic rentBookDbLogic = new();

            // Act

            Book bookToTest = new(Title, Creator, ReleaseYear, Genre, Pages);
            SystemUser user = new("Name", "Email", "pw", false);

            RentMediaDbLogic rentMediaDbLogic = new(user);

            dbLogicBook.AddBookToDb(bookToTest);
            rentBookDbLogic.RentBook(user, bookToTest);

            List<RentedMedia> rentedMedia = rentMediaDbLogic.GetRentedMedia();

            RentedMedia media = rentedMedia[0];

            rentMediaDbLogic.ReturnMedia(media);
            List<Book> rentableBooks = rentBookDbLogic.GetRentableBooks();

            // Assert
            Assert.That(rentableBooks.Count(), Is.EqualTo(1));
        }
    }
}
