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
          

        }

        [TearDown] public void TearDown() {

            
       

        }



        [Test]
        public void AddBook()
        {

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
        [Obsolete]
        public void GetAllMusic() {

            string Title = "testingsong";
            string Creator = "testingcomposer";
            int ReleaseYear = 1980;
            string Genre = "classical";
            int lengthInSeconds = 180;
            DbLogicMusic database = new();
            // Music song = new(Title, Creator, ReleaseYear, Genre, lengthInSeconds);
            MusicLogic musicLogic = new();


            musicLogic.AddSong(Title, Creator, ReleaseYear, Genre, lengthInSeconds);

            List<Music> musicList = database.GetAllMusic();
            foreach (var songList in musicList)
            {
                Console.WriteLine(songList);
            }


            Assert.That(musicList.Contains(song));

          
        }

        [Test]
        public void GetAllBooks()
        {

        }
     
    }
   

}