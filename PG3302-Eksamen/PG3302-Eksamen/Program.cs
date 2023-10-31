using PG3302_Eksamen.Logic;
using PG3302_Eksamen.UI;

namespace PG3302_Eksamen
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Sample-data - for testing purposes
            BookLogic bookLogic = new();
            bookLogic.AddBook("Harry Potter", "J.K. Rowling", 1997, "Fantasy", 300);
            bookLogic.AddBook("The Lord of the Rings", "J.R.R. Tolkien", 1954, "Fantasy", 500);
            bookLogic.AddBook("The Hobbit", "J.R.R. Tolkien", 1937, "Fantasy", 300);


            ConsoleApp mainMenu = new();
            mainMenu.RunProgram();     
            
            

        }
    }
}