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

        [SetUp]
        public void SetUp()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (Book book in db.Books)
                {
                    db.Remove(book);
                    db.SaveChanges();
                }
            }


        }

        [TearDown] public void TearDown() {
           
        }


        
        [Test]
        public void AddBook()
        {
            using (TransactionScope scope = new TransactionScope()) ;

                // Arrange
            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;
            BookLogic bookLogic = new BookLogic();

            // Act
            bookLogic.AddBook(Title, Creator, ReleaseYear, Genre, Pages);


            // Asssert
            Assert.That(bookLogic.CheckIfBookExists("testingname"));




        }
    
        [Test]
        public void GetAllBooks() {

            string Title = "testingname";
            string Creator = "tolkien";
            int ReleaseYear = 1943;
            string Genre = "fantasy";
            int Pages = 800;


            Book bookTest = new Book(Title, Creator, ReleaseYear, Genre, Pages);
            DbLogic database = new();


            ArrayList bookList = database.GetAllBooks();
            foreach (var book in bookList)
            {
                Console.WriteLine(book);
            }


            Assert.That(bookList.Contains(bookTest), Is.True);
        }
     
    }
   

}